using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double lat, double longi) 
        {
            List<Venue> venues = new List<Venue>();
            var url = VenueRoot.GenerateUrl(lat, longi);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var jsonVersion = await response.Content.ReadAsStringAsync();

                var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(jsonVersion);

                venues = venueRoot.response.venues as List<Venue>;
            }

            return venues;
        }
    }
}
