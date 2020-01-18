using CCL_WEB.Models;
using CCL_WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCL_WEB.Helpers
{
    public class HomeHelper : IHomeHelperService
    {
        //private readonly variable to hold the context for the database
        private readonly CCLdbContext context;

        //constructor with context for database
        public HomeHelper(CCLdbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Listing> GetAllListings()
        {
            throw new NotImplementedException();
        }

        public List<string> GetMakes()
        {
            var makes = context.Listing.Select(m => m.Make).Distinct().ToList();
            makes.Sort();
            return makes;
        }

        public List<string> GetModels()
        {
            var models = context.Listing.Select(m => m.Model).Distinct().ToList();
            models.Sort();
            return models;
        }

        public List<string> GetYears()
        {
            List<string> yList = new List<string>();
            var years = context.Listing.Select(x => x.Year).Distinct().ToList();
            var yearList = from y in years
                           orderby y descending
                           select y;

            foreach (string year in yearList)
            {
                if (year.Length > 4 || year.StartsWith("9"))
                {

                }
                else
                {
                    yList.Add(year);
                }
            }

            return yList;
        }

        public List<Listing> Search(string year, string make, string model)
        {
            List<Listing> listings = new List<Listing>();
            if (year != null && make != null && model != null)
            {
                listings = context.Listing.Where(x => x.Year.Equals(year)
                                        && x.Make.ToLower().Equals(make.ToLower())
                                         && x.Model.ToLower().Equals(model.ToLower())).Take(30).ToList();
            }

            return listings;
        }
    }
}
