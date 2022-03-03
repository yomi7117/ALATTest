using ALATTest.Domain.ViewModel;
using ALATTest.Repository.Interface;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ALATTest.Repository.Repository
{
    public class BankRepository : IBank
    {
        public BankRepository()
        {

        }
        public async Task<BankResponse> GetAllBanks()
        {
            try
            {
                
                var url = $"https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Ocp-Apim-Subscription-Key", "e2561f969d5c4941a5cd7ffb0aaa274a");
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/json");
                IRestResponse response = await client.ExecuteAsync(request);
                var content = response.Content;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var model = JsonConvert.DeserializeObject<BankResponse>(content);
                    return model;
                }
                return new BankResponse();
            }
            catch (Exception ex)
            {

                throw ex;
               
            }
        }
    }
}
