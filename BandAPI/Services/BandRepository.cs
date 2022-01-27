using BandAPI.DbContexts;
using BandAPI.Entities;
using BandAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Services
{
    public class BandRepository : IBandRepository
    {     
        private readonly BandAlbumContext _context;

        public BandRepository(BandAlbumContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
        public void AddBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _context.Bands.Add(band);
        }
        public bool BandExists(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Bands.Any(b => b.Id == bandId);
        }
        public void DeleteBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _context.Bands.Remove(band);
        }
        public Band GetBand(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Bands.FirstOrDefault(b => b.Id == bandId);
        }

        public IEnumerable<Band> GetBands()
        {
            return _context.Bands.ToList();
        }

        public IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds)
        {
            if (bandIds == null)
                throw new ArgumentNullException(nameof(bandIds));

            return _context.Bands.Where(b => bandIds.Contains(b.Id))
                            .OrderBy(b => b.Name).ToList();
        }

        //public IEnumerable<Band> GetBands(string mainGenre, string searchQuery)
        public IEnumerable<Band> GetBands(BandsResourceParameters bandsResourceParameters)
        {
            if (bandsResourceParameters == null)
                throw new ArgumentNullException(nameof(bandsResourceParameters));

            if (string.IsNullOrWhiteSpace(bandsResourceParameters.MainGenre) && string.IsNullOrWhiteSpace(bandsResourceParameters.SearchQuery))
                return GetBands();
            var collection = _context.Bands as IQueryable<Band>;
            if (!string.IsNullOrWhiteSpace(bandsResourceParameters.MainGenre))
            {
                var mainGenre = bandsResourceParameters.MainGenre.Trim();
                collection = collection.Where(b => b.MainGenre == mainGenre);
            }
            if (!string.IsNullOrWhiteSpace(bandsResourceParameters.SearchQuery))
            {
                var searchQuery = bandsResourceParameters.SearchQuery.Trim();
                collection = collection.Where(b => b.Name.Contains(searchQuery));
            }
            //mainGenre = mainGenre.Trim();
            //return _context.Bands.Where(a => a.MainGenre == mainGenre).ToList();
            return collection.ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void UpdateBand(Band band)
        {
            //not implemented
        }
    }
}
