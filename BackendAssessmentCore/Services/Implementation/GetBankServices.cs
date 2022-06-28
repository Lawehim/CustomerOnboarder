using CustomerOnboarder.Core.DTO.Response;
using CustomerOnboarder.Core.Services.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Core.Services.Implementation
{
    public class GetBankServices:IGetBankServices
    {
        private readonly IConfiguration _configuration;
        public GetBankServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response<ListGetbankDto>> GetbankRequest()
        {
            var client = new HttpClient();

            // RequestMessage headers
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(_configuration["Getbanks:uri"]),
                Method = HttpMethod.Get,
                Headers =
                {
                    { "Ocp-Apim-Subscription-Key", _configuration["Getbanks:key"] }
                },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var serializer = new JsonSerializer();
                using var stringReader = new StringReader(res);
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    jsonReader.SupportMultipleContent = true;
                    ListGetbankDto result = serializer.Deserialize<ListGetbankDto>(jsonReader);
                    return new Response<ListGetbankDto>
                    {
                        Data = result,
                        IsSuccessFul = true,
                        Message = "Successful",
                        ResponseCode = HttpStatusCode.OK
                    };
                }
            }
            throw new Exception("Server Error");
        }
    }
}
