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
    public class UsersClient : IExternalUsersClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsersClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<UserEntity>> GetUsersFromAPIAsync()
        {
            var ratesObject = await FetchDataFromAPIAsync();
            return MapDataToEntity(ratesObject);
            
        }

        public async Task<List<UserJsonModel>?> FetchDataFromAPIAsync()
        {
            var ratesObject = new List<UserJsonModel>();

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
                ratesObject = jsonDocument.RootElement.Deserialize<List<UserJsonModel>>(serializeOptions);

            }
            return ratesObject;
        }

        private static List<UserEntity> MapDataToEntity(List<UserJsonModel> ratesObject)
        {
            var currencyExchangeRateDTOs = new List<UserEntity>();

            foreach (var prop in ratesObject)
            {

                currencyExchangeRateDTOs.Add(new UserEntity
                {
                    Id = prop.Id,
                    Name = prop.Name,
                    Username = prop.Username,
                    Email = prop.Email,
                    Street = prop?.Address?.Street,
                    City = prop?.Address?.City,
                });

            }
            return currencyExchangeRateDTOs;
        }


    }
}
