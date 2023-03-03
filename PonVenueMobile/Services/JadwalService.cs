using Android.Accounts;
using PonVenueMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonVenueMobile.Services
{
    public class JadwalService
    {

        readonly string controller = "/api/jadwal";
        public async Task<List<Jadwal>> GetByDate(DateTime start, DateTime enddate)
        {
            try
            {
                using var client = new RestService();
                var response = await client.GetAsync($"{controller}/bydate?start={start.Ticks}&enddate={enddate.Ticks}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.GetResult<List<Jadwal>>();
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
