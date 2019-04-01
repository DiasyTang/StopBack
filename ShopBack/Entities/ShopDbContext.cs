using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBack.Entities
{
    public class ShopDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<Role> Role { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<Menu> Menu { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public DbSet<Permission> Permission { get; set; }

        /// <summary>
        /// 角色-权限多对多映射
        /// </summary>
        public DbSet<RolePermissionMapping> RolePermissionMapping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(x => x.RoleCode).IsUnique();
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasIndex(x => x.MenuCode).IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(x => x.UserCode).IsUnique();

                entity.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleCode);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasIndex(x => x.PermissionCode).IsUnique();

                entity.HasOne(x => x.Menu)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.MenuCode);
            });

            modelBuilder.Entity<RolePermissionMapping>(entity =>
            {
                entity.HasKey(x => new
                {
                    x.PermissionCode,
                    x.RoleCode
                });

                entity.HasOne(x => x.Role)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x=>x.RoleCode)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Permission)
                .WithMany(x => x.Roles)
                .HasForeignKey(x=>x.PermissionCode)
                .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
