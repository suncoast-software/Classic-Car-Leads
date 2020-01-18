using CCL_WEB.Models;
using CCL_WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCL_WEB.Helpers
{
    public class ListingHelper : IListingHelperService
    {
        private readonly CCLdbContext context;

        public ListingHelper(CCLdbContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Listing> GetAll()
        {
            throw new NotImplementedException();
        }

        public Listing GetListing(int? id)
        {
            var listing = context.Listing.Find(id);

            return listing;
        }
    }
}
