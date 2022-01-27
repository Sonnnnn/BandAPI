using BandAPI.Entities;
using BandAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Services
{
    public interface IBandRepository
    {
        IEnumerable<Band> GetBands();
        Band GetBand(Guid bandId);
        IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds);
        IEnumerable<Band> GetBands(BandsResourceParameters bandsResourceParameters);
        //IEnumerable<Band> GetBands(string mainGenre, string searchQuery);
        void AddBand(Band band);
        void UpdateBand(Band band);
        void DeleteBand(Band band);

        bool BandExists(Guid BandId);
        bool Save();
    }
}
