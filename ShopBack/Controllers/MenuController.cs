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
                throw new ArgumentException("请求接口参数有错误");
            }

            var respone = new ResponeDTO<string>();
            using (var db = new ShopDbContext())
            {
                Menu parentMenu = null;
                if (!string.IsNullOrWhiteSpace(alterMenuRequest.ParentMenuCode))
                {
                    parentMenu = db.Menu.FirstOrDefault(q => q.MenuCode == alterMenuRequest.ParentMenuCode);
                    if (parentMenu == null)
                    {
                        throw new ArgumentException("接口参数错误");
                    }
                }

                Menu menu;
                if (!string.IsNullOrWhiteSpace(alterMenuRequest.MenuCode))
                {
                    menu = db.Menu.FirstOrDefault(q => q.MenuCode == alterMenuRequest.MenuCode);
                    if (menu == null)
                    {
                        throw new ArgumentException("修改的菜单编码不存在");
                    }
                }
                else
                {
                    menu = new Menu();
                    menu.MenuCode = RandomFactory.GetRandomizer(6, extensiveCodes: db.Menu.Select(q => q.MenuCode).ToList());
                }
                menu.MenuName = alterMenuRequest.MenuName;
                menu.MenuStatus = (Status)alterMenuRequest.MenuStatus;
                menu.MenuAlias = alterMenuRequest.MenuAlias;
                menu.MenuUrl = alterMenuRequest.MenuUrl;
                menu.Level = alterMenuRequest.Level;
                menu.Sort = alterMenuRequest.Sort;
                menu.MenuIcon = alterMenuRequest.MenuIcon;
                menu.IsDefaultRouter = alterMenuRequest.IsDefaultRouter;
                menu.ParentMenuCode = alterMenuRequest.ParentMenuCode;
                menu.Description = alterMenuRequest.Description;
                menu.ParentMenuName = parentMenu == null ? "顶级菜单" : parentMenu.MenuName;
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

        [HttpGet]
        [Route("api/menu/delete")]
        public ResponeDTO<string> DeleteMenus(string deleteMenuIds)
        {
            if (string.IsNullOrWhiteSpace(deleteMenuIds))
            {
                throw new ArgumentException("请求接口参数有错误");
            }

            var menuIds = deleteMenuIds.Split(",");
            if (menuIds.Length <= 0)
            {
                throw new ArgumentException("请求接口参数有错误");
            }

            var respone = new ResponeDTO<string>();
            using (var db = new ShopDbContext())
            {
                var menus = db.Menu.Where(q => menuIds.Any(x => x == q.MenuCode)).ToList();
                if (menuIds.Length == menus.Count)
                {
                    db.Menu.RemoveRange(menus);
                    db.SaveChanges();
                    respone.Data = "";
                    respone.Message = "删除菜单成功";
                }
                else
                {
                    throw new ArgumentException("请求接口参数有错误");
                }
            }
            return respone;
        }

        [HttpPost]
        [Route("api/menu/changemenustatus")]
        public ResponeDTO<string> ChangeMenuStatus(ChangeMenuStatusRequest menuStatusRequest)
        {
            if (string.IsNullOrWhiteSpace(menuStatusRequest.MenuIds))
            {
                throw new ArgumentException("请求接口参数有错误");
            }

            var menuIds = menuStatusRequest.MenuIds.Split(",");
            if (menuIds.Length <= 0)
            {
                throw new ArgumentException("请求接口参数有错误");
            }

            var respone = new ResponeDTO<string>();

            using (var db = new ShopDbContext())
            {
                var menus = db.Menu.Where(q => menuIds.Any(x => x == q.MenuCode)).ToList();
                if (menuIds.Length == menus.Count())
                {
                    foreach (var menu in menus)
                    {
                        menu.MenuStatus = (Status)menuStatusRequest.Status;
                    }
                    db.Menu.UpdateRange(menus);
                    db.SaveChanges();
                    respone.Data = "";
                    respone.Message = "修改菜单状态成功";
                }
                else
                {
                    throw new ArgumentException("请求接口参数有错误");
                }
            }

            return respone;
        }

        [HttpPost]
        [Route("api/menu/list")]
        public ResponeDTO<MenuRespone[]> Menus(RequestDTO<MenusRequest> menusRequest)
        {
            if (string.IsNullOrWhiteSpace(menusRequest.TimeStamp))
            {
                throw new ArgumentException("请求接口参数有错误");
            }

            var respone = new ResponeDTO<MenuRespone[]>();
            using (var db = new ShopDbContext())
            {
                var query = db.Menu.AsQueryable();
                if (menusRequest.Parameter.IsDefaultRouter != null)
                {
                    query = query.Where(q => q.IsDefaultRouter == menusRequest.Parameter.IsDefaultRouter);
                }

                if (!string.IsNullOrWhiteSpace(menusRequest.Parameter.MenuAlias))
                {
                    query = query.Where(q => q.MenuAlias.Trim().ToUpper().Contains(menusRequest.Parameter.MenuAlias.Trim().ToUpper()));
                }

                if (!string.IsNullOrWhiteSpace(menusRequest.Parameter.MenuName))
                {
                    query = query.Where(q => q.MenuName.Trim().ToUpper().Contains(menusRequest.Parameter.MenuName.Trim().ToUpper()));
                }

                if (!string.IsNullOrWhiteSpace(menusRequest.Parameter.ParentMenuName))
                {
                    query = query.Where(q => q.ParentMenuName.Trim().ToUpper().Contains(menusRequest.Parameter.ParentMenuName.Trim().ToUpper()));
                }

                if (menusRequest.Parameter.MenuStatus != null && menusRequest.Parameter.MenuStatus > 0)
                {
                    query = query.Where(q => q.MenuStatus == (Status)menusRequest.Parameter.MenuStatus);
                }

                if (!string.IsNullOrWhiteSpace(menusRequest.Parameter.MenuUrl))
                {
                    query = query.Where(q => q.MenuUrl.Trim().ToUpper().Contains(menusRequest.Parameter.MenuUrl.Trim().ToUpper()));
                }

                respone.Data = query.Select(q => new MenuRespone()
                {
                    MenuUrl = q.MenuUrl,
                    MenuName = q.MenuName,
                    MenuIcon = q.MenuIcon,
                    IsDefaultRouter = q.IsDefaultRouter,
                    MenuStatus = (int)q.MenuStatus,
                    MenuAlias = q.MenuAlias,
                    ParentMenuCode = q.ParentMenuCode,
                    ParentMenuName = q.ParentMenuName,
                    CreatedOn = q.AuditEntity.CreatedOn.ToString(),
                    CreatorName = q.AuditEntity.CreatorName,
                    CreatorId = q.AuditEntity.CreatorId
                }).ToArray();
                respone.TimeStamp = menusRequest.TimeStamp;
            }
            return respone;
        }
    }
}
