using Android.Accounts;
using PonVenueMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonVenueMobile.Services
{
    public class VenueService
    {

        readonly string controller = "/api/venue";
        public async Task<List<Venue>> Get()
        {
            try
            {
                using var client = new RestService();
                var response = await client.GetAsync($"{controller}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<List<Venue>>();
                    return result;
                }
                else
                    throw new SystemException(await client.Error(response));
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}
