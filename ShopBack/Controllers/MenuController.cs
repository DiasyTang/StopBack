using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopBack.Entities;
using ShopBack.RequestDTOs;
using ShopBack.ResponeDTOs;
using ShopBack.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShopBack.Entities.Enums.CommonEnum;

namespace ShopBack.Controllers
{
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpPost]
        [Route("api/menu/alter")]
        public ResponeDTO<string> AlterMenu(AlterMenuRequest alterMenuRequest)
        {
            if (string.IsNullOrWhiteSpace(alterMenuRequest.MenuName)
               && string.IsNullOrWhiteSpace(alterMenuRequest.MenuAlias)
               && string.IsNullOrWhiteSpace(alterMenuRequest.MenuUrl))
            {
                throw new Exception("请求接口参数有错误");
            }

            var respone = new ResponeDTO<string>();
            using (var db = new ShopDbContext())
            {
                Menu ParentMenu = null;
                if (!string.IsNullOrWhiteSpace(alterMenuRequest.ParentMenuCode))
                {
                    ParentMenu = db.Menu.FirstOrDefault(q => q.MenuCode == alterMenuRequest.ParentMenuCode);
                    if (ParentMenu == null)
                    {
                        throw new Exception("接口参数中的父级菜单参数错误");
                    }
                }

                Menu menu;
                if (!string.IsNullOrWhiteSpace(alterMenuRequest.MenuCode))
                {
                    menu = db.Menu.FirstOrDefault(q => q.MenuCode == alterMenuRequest.MenuCode);
                    if (menu == null)
                    {
                        throw new Exception("修改的菜单编码不存在");
                    }
                }
                else
                {
                    menu = new Menu();
                    menu.MenuCode = RandomFactory.GetRandomizer(6, extensiveCodes: db.Menu.Select(q => q.MenuCode).ToList());
                }
                menu.MenuName = alterMenuRequest.MenuName;
                menu.MenuStatus = alterMenuRequest.MenuStatus ? Status.Normal : Status.Forbidden;
                menu.MenuAlias = alterMenuRequest.MenuAlias;
                menu.MenuUrl = alterMenuRequest.MenuUrl;
                menu.Level = alterMenuRequest.Level;
                menu.Sort = alterMenuRequest.Sort;
                menu.MenuIcon = alterMenuRequest.MenuIcon;
                menu.IsDefaultRouter = alterMenuRequest.IsDefaultRouter;
                menu.ParentMenuCode = alterMenuRequest.ParentMenuCode;
                menu.Description = alterMenuRequest.Description;
                menu.ParentMenuName = ParentMenu == null ? "顶级菜单" : ParentMenu.MenuName;
                menu.AuditEntity = new AuditEntity()
                {
                    CreatedOn = DateTime.Now
                };

                if (string.IsNullOrWhiteSpace(alterMenuRequest.MenuCode))
                {
                    db.Menu.Add(menu);
                }
                else
                {
                    db.Menu.Update(menu);
                }
                db.SaveChanges();
                respone.Data = menu.MenuCode;
            }
            return respone;
        }
    }
}
