using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.RequestDTOs
{
    public class RequestDTO<T>
    {
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
        [JsonProperty("parameter")]
        public T Parameter { get; set; }
        [JsonProperty("timeStamp")]
        public string TimeStamp { get; set; }
    }
}
