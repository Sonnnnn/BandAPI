using AutoMapper;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/bands/{bandId}/albums")]
  
    public class AlbumsController : ControllerBase
    {
        // private readonly IBandAlbumRepository _bandAlbumRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IBandRepository _bandRepository;
        private readonly IMapper _mapper;

        //public AlbumsController(IBandAlbumRepository bandAlbumRepository, IMapper mapper)
        public AlbumsController(IAlbumRepository albumRepository, IBandRepository bandRepository, IMapper mapper)
        {
            //_bandAlbumRepository = bandAlbumRepository ??
            _albumRepository = albumRepository ??
                 throw new ArgumentNullException(nameof(albumRepository));
            //throw new ArgumentNullException(nameof(bandAlbumRepository));
            _bandRepository = bandRepository ??
            throw new ArgumentNullException(nameof(bandRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlbumsDto>> GetAlbumsForBand(Guid albumId)
        {
            // if (!_bandAlbumRepository.BandExists(bandId))
            if (!_albumRepository.AlbumExists(albumId))
                return NotFound();

            //var albumsFromRepo = _bandAlbumRepository.GetAlbums(bandId);
            var albumsFromRepo = _albumRepository.GetAlbums(albumId);
            return Ok(_mapper.Map<IEnumerable<AlbumsDto>>(albumsFromRepo));
        }

        [HttpGet("{albumId}", Name = "GetAlbumForBand")]
        [ResponseCache(Duration = 120)]
        public ActionResult<AlbumsDto> GetAlbumForBand(Guid bandId, Guid albumId)
        {
            //if (!_bandAlbumRepository.BandExists(bandId))
            if (!_bandRepository.BandExists(bandId))
                return NotFound();

            //var albumFromRepo = _bandAlbumRepository.GetAlbum(bandId, albumId);
            var albumFromRepo = _albumRepository.GetAlbum(bandId, albumId);
            if (albumFromRepo == null)
                return NotFound();

            return Ok(_mapper.Map<AlbumsDto>(albumFromRepo));
        }
        [HttpPost]
        public ActionResult<AlbumsDto> CreateAlbumForBand(Guid bandId, [FromBody] AlbumForCreatingDto album)
        {
            //if (!_bandAlbumRepository.BandExists(bandId))
            if (!_bandRepository.BandExists(bandId))
                return NotFound();

            var albumEntity = _mapper.Map<Entities.Album>(album);
            //_bandAlbumRepository.AddAlbum(bandId, albumEntity);
            _albumRepository.AddAlbum(bandId, albumEntity);
            //_bandAlbumRepository.Save();
            _albumRepository.Save();

            var albumToReturn = _mapper.Map<AlbumsDto>(albumEntity);
            return CreatedAtRoute("GetAlbumForBand", new { bandId = bandId, albumId = albumToReturn.Id }, albumToReturn);
        }
        [HttpPut("{albumId}")]
        public ActionResult UpdateAlbumForBand(Guid bandId, Guid albumId,[FromBody] AlbumForUpdatingDto album)
        {
            //if (!_bandAlbumRepository.BandExists(bandId))
            if (!_bandRepository.BandExists(bandId))
                return NotFound();

            //var albumFromRepo = _bandAlbumRepository.GetAlbum(bandId, albumId);
            var albumFromRepo = _albumRepository.GetAlbum(bandId, albumId);
            if (albumFromRepo == null)
            {
                var albumToAdd = _mapper.Map<Entities.Album>(album);
                albumToAdd.Id = albumId;
                //_bandAlbumRepository.AddAlbum(bandId, albumToAdd);
                _albumRepository.AddAlbum(bandId, albumToAdd);
                // _bandAlbumRepository.Save();
                _albumRepository.Save();

                var albumToReturn = _mapper.Map<AlbumsDto>(albumToAdd);

                return CreatedAtRoute("GetAlbumForBand", new { bandId = bandId, 
                    albumId = albumToReturn.Id }, albumToReturn);
            }

            _mapper.Map(album, albumFromRepo);
            //_bandAlbumRepository.UpdateAlbum(albumFromRepo);
            _albumRepository.UpdateAlbum(albumFromRepo);
            //_bandAlbumRepository.Save();
            _albumRepository.Save();

            return NoContent();
        }
        [HttpPatch("{albumId}")]
        public ActionResult PartiallyUpdateAlbumForBand(Guid bandId, Guid albumId,
           [FromBody] JsonPatchDocument<AlbumForUpdatingDto> patchDocument)
        {
            //if (!_bandAlbumRepository.BandExists(bandId))
            if (!_bandRepository.BandExists(bandId))
                return NotFound();
            //var albumFromRepo = _bandAlbumRepository.GetAlbum(bandId, albumId);
            var albumFromRepo = _albumRepository.GetAlbum(bandId, albumId);
            if (albumFromRepo == null)
                return NotFound();

            var albumToPatch = _mapper.Map<AlbumForUpdatingDto>(albumFromRepo);
            patchDocument.ApplyTo(albumToPatch, ModelState);
            
            if (!TryValidateModel(albumToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(albumToPatch, albumFromRepo);
            // _bandAlbumRepository.UpdateAlbum(albumFromRepo);
            _albumRepository.UpdateAlbum(albumFromRepo);
            // _bandAlbumRepository.Save();
            _albumRepository.Save();

            return NoContent();
        }

        [HttpDelete("{albumId}")]
        public ActionResult DeleteAlbumForBand(Guid bandId, Guid albumId)
        {
            //if (!_bandAlbumRepository.BandExists(bandId))
            if (!_bandRepository.BandExists(bandId))
                return NotFound();

            //var albumFromRepo = _bandAlbumRepository.GetAlbum(bandId, albumId);
            var albumFromRepo = _albumRepository.GetAlbum(bandId, albumId);

            if (albumFromRepo == null)
                return NotFound();

            //_bandAlbumRepository.DeleteAlbum(albumFromRepo);
            _albumRepository.DeleteAlbum(albumFromRepo);
            //_bandAlbumRepository.Save();
            _albumRepository.Save();
            return NoContent();
        }
    }
}