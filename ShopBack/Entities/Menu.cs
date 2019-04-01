using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ShopBack.Entities.Enums.CommonEnum;

namespace ShopBack.Entities
{
    /// <summary>
    /// 菜单实体
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Key,Required]
        [Column(TypeName = "nvarchar(6)")]
        public string MenuCode { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单链接地址
        /// </summary>
        [Required]
        public string MenuUrl { get; set; }

        /// <summary>
        /// 菜单别名
        /// </summary>
        [Required]
        public string MenuAlias { get; set; }

        /// <summary>
        /// 菜单图标可选
        /// </summary>
        public string MenuIcon { get; set; }

        /// <summary>
        /// 父级菜单
        /// </summary>
        [Column(TypeName = "nvarchar(6)")]
        public string ParentMenuCode { get; set; }

        /// <summary>
        /// 父级菜单名称
        /// </summary>
        public string ParentMenuName { get; set; }

        /// <summary>
        /// 菜单层级深度
        /// </summary>
        public uint Level { get; set; }

        /// <summary>
        /// 菜单描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public uint Sort { get; set; }

        /// <summary>
        /// 菜单状态
        /// </summary>
        public Status MenuStatus { get; set; } 

        /// <summary>
        /// 是否为默认路由
        /// </summary>
        public bool IsDefaultRouter { get; set; } 

        /// <summary>
        /// 创建与修改记录
        /// </summary>
        public AuditEntity AuditEntity { get; set; }

        /// <summary>
        /// 菜单拥有的权限列表
        /// </summary>
        public ICollection<Permission> Permissions { get; set; }
    }
}
