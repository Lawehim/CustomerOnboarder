using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOnboarder.Core.Utility
{
    public class ConfirmStateLGA:IConfirmStateLGA
    {
        private readonly string db = Path.Combine(Environment.CurrentDirectory, @"db\");
        private readonly string json = "StateLGA.json";

        public async Task<bool> Confirmation(string state, string lga)
        {
            var check = await CheckStateAndLGA();
            foreach(var res in check)
            {
                if(res.State.ToLower() == state.ToLower() && res.LGA.ToLower() == lga.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        private async Task<IEnumerable<StateLGA>> CheckStateAndLGA()
        {
            var readText = await File.ReadAllTextAsync(db + json);
            var serializer = new JsonSerializer();
            using var stringReader = new StringReader(readText);
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                jsonReader.SupportMultipleContent = true;
                IList<StateLGA> result = serializer.Deserialize<List<StateLGA>>(jsonReader);
                return result;
            }
        }
    }
}
