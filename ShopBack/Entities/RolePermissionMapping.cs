using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.Entities
{
    public class RolePermissionMapping
    {
        /// <summary>
        /// 权限编码
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(6)")]
        public string PermissionCode { get; set; }

        /// <summary>
        /// 角色编码
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(6)")]
        public string RoleCode { get; set; }

        /// <summary>
        /// 角色实体
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// 权限实体
        /// </summary>
        public Permission Permission { get; set; }
    }

    
}
