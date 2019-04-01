using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.Entities.Enums
{
    public class CommonEnum
    {
        /// <summary>
        /// 用户状态
        /// </summary>
        public enum Status
        {
            /// <summary>
            /// 未指定
            /// </summary>
            All = -1,
            /// <summary>
            /// 已禁用
            /// </summary>
            Forbidden = 0,
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 1,
            /// <summary>
            /// 已删除
            /// </summary>
            Deleted=2
        }

        /// <summary>
        /// 权限类型
        /// </summary>
        public enum PermissionType
        {
            /// <summary>
            /// 菜单
            /// </summary>
            Menu = 0,
            /// <summary>
            /// 按钮/操作/功能
            /// </summary>
            Action = 1
        }
    }
}
