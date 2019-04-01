using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ShopBack.Entities.Enums.CommonEnum;

namespace ShopBack.Entities
{
    public class Permission
    {
        /// <summary>
        /// 权限编码
        /// </summary>
        [Key,Required]
        [Column(TypeName = "nvarchar(6)")]
        public string PermissionCode { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        public string MenuCode { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set; }

        /// <summary>
        /// 权限操作码
        /// </summary>
        public string ActionCode { get; set; }

        /// <summary>
        /// 图标（可选）
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 权限状态
        /// </summary>
        public Status PermissionStatus { get; set; }

        /// <summary>
        /// 权限类型（0：菜单，1：按钮/操作/功能等）
        /// </summary>
        public PermissionType PermissionType { get; set; }

        /// <summary>
        /// 创建与修改记录
        /// </summary>
        public AuditEntity AuditEntity { get; set; }

        /// <summary>
        /// 关联菜单
        /// </summary>
        public Menu Menu { get; set; }

        /// <summary>
        /// 权限所属的角色集合
        /// </summary>
        public ICollection<RolePermissionMapping> Roles { get; set; }
    }
}
