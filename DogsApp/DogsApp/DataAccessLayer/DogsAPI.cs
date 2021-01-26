using DogsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DogsApp.DataAccessLayer
{
    class DogsAPI
    {
        const string ApiURL = @"https://storagekaamelot.blob.core.windows.net/kaamlotcontainer/dogs.json";

        public async Task<List<Dogs>> GetDogsAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                string result = await client.GetStringAsync(ApiURL);

                List<Dogs> listDogs = JsonConvert.DeserializeObject<List<Dogs>>(result);

                return listDogs;
            }
            catch (Exception ex)
            {
                return new List<Dogs>();
            }
        }
    }
}
