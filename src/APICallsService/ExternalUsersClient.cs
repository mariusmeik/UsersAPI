using Core.Contracts;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace APICallsService
{
    public class ExternalUsersClient : IExternalUsersClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExternalUsersClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<UserEntity>> GetUsersFromAPIAsync()
        {
            var ratesObject = await FetchDataFromAPIAsync();
            return ratesObject;//MapDataToEntity(ratesObject);
            
        }

        public async Task<List<UserEntity>?> FetchDataFromAPIAsync()
        {
            var ratesObject = new List<UserEntity>();

            using (var client = _httpClientFactory.CreateClient("UsersClient"))
            {
                //client.BaseAddress = new UriBuilder();
                var data = await client.GetAsync("", HttpCompletionOption.ResponseHeadersRead);
                var jsonString = await data.Content.ReadAsStringAsync();

                var jsonDocument = JsonDocument.Parse(jsonString);
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                ratesObject = jsonDocument.RootElement.Deserialize<List<UserEntity>>(serializeOptions);

            }
            return ratesObject;
        }

        private static List<UserEntity> MapDataToEntity(List<RawUserObject> ratesObject)
        {
            var currencyExchangeRateDTOs = new List<UserEntity>();

            foreach (var prop in ratesObject)
            {

                currencyExchangeRateDTOs.Add(new UserEntity
                {
                    Id = prop.id,
                    Name = prop.name,
                    Username = prop.username,
                    Email = prop.email,
                    Street = prop.address.street,
                    City = prop.address.city,
                });

            }
            return currencyExchangeRateDTOs;
        }


    }
}
