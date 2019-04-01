using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.RequestDTOs
{
    public class AlterMenuRequest
    {
        [JsonProperty("menuCode")]
        public string MenuCode { get; set; }
        [JsonProperty("menuName")]
        public string MenuName { get; set; }
        [JsonProperty("menuAlias")]
        public string MenuAlias { get; set; }
        [JsonProperty("menuIcon")]
        public string MenuIcon { get; set; }
        [JsonProperty("menuUrl")]
        public string MenuUrl { get; set; }
        [JsonProperty("parentMenuCode")]
        public string ParentMenuCode { get; set; }
        [JsonProperty("level")]
        public uint Level { get; set; }
        [JsonProperty("sort")]
        public uint Sort { get; set; }
        [JsonProperty("menuStatus")]
        public bool MenuStatus { get; set; }
        [JsonProperty("isDefaultRouter")]
        public bool IsDefaultRouter { get; set; }
        [JsonProperty("desc")]
        public string Description { get; set; }
    }
}
