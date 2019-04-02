using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.ResponeDTOs
{
    public class ResponeDTO<T>
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; } = true;
        [JsonProperty("responeCode")]
        public int StatusCode { get; set; } = 200;
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("trace")]
        public string Trace { get; set; }
        [JsonProperty("exception")]
        public string Exception { get; set; }
        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}
