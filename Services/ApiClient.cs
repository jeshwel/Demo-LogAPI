using Demo_LogAPI.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo_LogAPI.Services
{
    public class ApiClient
    {
        private readonly HttpClient client;
        public ApiClient(HttpClient client,
                         IConfiguration configuration)
        {
            this.client = client;
            this.client.BaseAddress = new Uri(configuration["AirApi:BaseUrl"]);
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["AirApi:Key"]);
        }


        public async Task<List<MessageDTO>> GetLogMessages()
        {
            //"Messages?maxRecords=3"
            //To get all messages, maxRecords avoided from query param.
            var response = await client.GetAsync("Messages");
            if (!response.IsSuccessStatusCode)
            {
                dynamic err = response.Content.ReadAsStringAsync().Result;
                throw new Exception(err);
            }
            else
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return GetMessageFields(responseData);
            }
        }


        public async Task<List<MessageDTO>> SaveLogMessage(MessageDTO Message)
        {

            List<MessageRecord> msgRecords = new List<MessageRecord>();
            var msgRecord = new MessageRecord
            {
                Message = Message
            };
            msgRecords.Add(msgRecord);
            var response = await client.PostAsJsonAsync("Messages", new { records = msgRecords });
            if (!response.IsSuccessStatusCode)
            {
                dynamic err = response.Content.ReadAsStringAsync().Result;
                throw new Exception(err);
            }
            else
            {
                var responseData = await response.Content.ReadAsStringAsync();
                return GetMessageFields(responseData);
            }
        }

        private static List<MessageDTO> GetMessageFields(string data)
        {
            using (JsonDocument document = JsonDocument.Parse(data))
            {
                var records = JsonSerializer.Deserialize<List<MessageRecord>>(document.RootElement.GetProperty("records").ToString());
                //select all the message fields
                if (records != null)
                    return records.Select(p => p.Message).ToList();
                return null;
            }
        }
    }
}
