using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Demo_LogAPI.DTOs
{
    
    public class MessageRecord
    {
        [JsonPropertyName("fields")]
        public MessageDTO Message { get; set; }
    }

    public class MessageDTO
    {
        //Both camel & pascal casings can be seen in response object.

        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("Summary")]
        public string Title { get; set; } 
        [JsonPropertyName("Message")]
        public string Text { get; set; } 
        [JsonPropertyName("receivedAt")]
        public string ReceivedAt { get; set; }

    }
}
