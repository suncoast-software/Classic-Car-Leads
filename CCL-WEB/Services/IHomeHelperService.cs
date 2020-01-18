using CCL_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCL_WEB.Services
{
    public interface IHomeHelperService
    {
        public List<string> GetYears();
        public List<string> GetMakes();
        public List<string> GetModels();
        public IEnumerable<Listing> GetAllListings();
        public List<Listing> Search(string year, string make, string model);
    }
}
