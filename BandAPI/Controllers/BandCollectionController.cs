using AutoMapper;
using BandAPI.Helpers;
using BandAPI.Models;
using BandAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Controllers
{
    [ApiController]
    [Route("api/bandcollections")]
    public class BandCollectionsController : ControllerBase
    {
        private readonly IBandRepository _bandRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public BandCollectionsController(IBandRepository bandRepository,IAlbumRepository albumRepository, IMapper mapper)
        {
            _bandRepository = bandRepository ??
                throw new ArgumentNullException(nameof(bandRepository));
            _albumRepository = albumRepository ??
                throw new ArgumentNullException(nameof(albumRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("{ids}", Name = "GetBandCollection")]
        public IActionResult GetBandCollection([FromRoute]
               [ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            if (ids == null)
                return BadRequest();

            var bandEntities = _bandRepository.GetBands(ids);

            if (ids.Count() != bandEntities.Count())
                return NotFound();

            var bandsToReturn = _mapper.Map<IEnumerable<BandDto>>(bandEntities);

            return Ok(bandsToReturn);
        }

        [HttpPost]
        public ActionResult<IEnumerable<BandDto>> CreateBandCollection([FromBody] IEnumerable<BandForCreatingDto> bandCollection)
        {
            var bandEntities = _mapper.Map<IEnumerable<Entities.Band>>(bandCollection);

            foreach (var band in bandEntities)
            {
                _bandRepository.AddBand(band);
            }

            _bandRepository.Save();
            var bandCollectionToReturn = _mapper.Map<IEnumerable<BandDto>>(bandEntities);
            var IdsString = string.Join(",", bandCollectionToReturn.Select(a => a.Id));

            return CreatedAtRoute("GetBandCollection", new { ids = IdsString }, bandCollectionToReturn);
        }

    }

}