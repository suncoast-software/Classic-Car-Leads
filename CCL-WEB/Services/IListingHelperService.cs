using CCL_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCL_WEB.Services
{
    public interface IListingHelperService
    {
        public Listing GetListing(int? id);
        public List<Listing> GetAll();
        public void Delete(int id);
    }
}
