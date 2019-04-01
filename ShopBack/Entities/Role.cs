using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ShopBack.Entities.Enums.CommonEnum;

namespace ShopBack.Entities
{
    public class Role
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Key,Required]
        [Column(TypeName = "nvarchar(6)")]
        public string RoleCode { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 角色状态
        /// </summary>
        public Status RoleStatus { get; set; }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        public bool IsSuperAdminstrator { get; set; }

        /// <summary>
        /// 是否是内置角色（内置角色不允许删除，修改操作）
        /// </summary>
        public bool IsBuiltin { get; set; }

        /// <summary>
        /// 角色拥有的用户集合
        /// </summary>
        public ICollection<User> Users { get; set; }

        /// <summary>
        /// 角色拥有的权限集合
        /// </summary>
        public ICollection<RolePermissionMapping> RolePermissions { get; set; }

        /// <summary>
        /// 创建与修改记录
        /// </summary>
        public AuditEntity AuditEntity { get; set; }
    }
}
