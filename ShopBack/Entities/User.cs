using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static ShopBack.Entities.Enums.CommonEnum;

namespace ShopBack.Entities
{
    public class User
    {
        /// <summary>
        /// 角色编码
        /// </summary>
        [Key,Required]
        [Column(TypeName = "nvarchar(6)")]
        public string UserCode { get; set; }

        /// <summary>
        /// 登陆名称
        /// </summary>
        [Required]
        public string LoginName { get; set; }

        /// <summary>
        /// 登陆之后显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public Status UserStatus { get; set; }

        /// <summary>
        /// 是否被锁定
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 是否登陆
        /// </summary>
        public bool IsLogined { get; set; }

        /// <summary>
        /// 用户描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 创建与修改记录
        /// </summary>
        public AuditEntity AuditEntity { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        [Required]
        public string RoleCode { get; set; }

        public Role Role { get; set; }
    }
}
