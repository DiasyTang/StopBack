using Newtonsoft.Json;
using ShopBack.Entities;
using ShopBack.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.ResponeDTOs
{
    public class MenuRespone
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
        [JsonProperty("parentMenuName")]
        public string ParentMenuName { get; set; }
        [JsonProperty("level")]
        public uint Level { get; set; }
        [JsonProperty("sort")]
        public uint Sort { get; set; }
        [JsonProperty("menuStatus")]
        public int MenuStatus { get; set; }
        [JsonProperty("isDefaultRouter")]
        public bool IsDefaultRouter { get; set; }
        [JsonProperty("desc")]
        public string Description { get; set; }
        [JsonProperty("createdOn")]
        public string CreatedOn { get; set; }
        [JsonProperty("creatorId")]
        public Guid? CreatorId { get; set; }
        [JsonProperty("creatorName")]
        public string CreatorName { get; set; }
        [JsonProperty("modifiedOn")]
        public string ModifiedOn { get; set; }
        [JsonProperty("modifiedByUserId")]
        public Guid? ModifiedByUserId { get; set; }
        [JsonProperty("modifiedByUserName")]
        public string ModifiedByUserName { get; set; }
    }

    public class MenuTreeRespone
    {
        [JsonProperty("menuCode")]
        public string MenuCode { get; set; }
        [JsonProperty("menuName")]
        public string MenuName { get; set; }
        [JsonProperty("menuAlias")]
        public string MenuAlias { get; set; }
        [JsonProperty("children")]
        public List<MenuTreeRespone> Children { get; set; }
    }
}
