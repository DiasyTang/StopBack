﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopBack.Entities;

namespace ShopBack.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20190403100443_add-isdeleted-menu")]
    partial class addisdeletedmenu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShopBack.Entities.Menu", b =>
                {
                    b.Property<string>("MenuCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDefaultRouter");

                    b.Property<bool>("IsDeleted");

                    b.Property<long>("Level");

                    b.Property<string>("MenuAlias")
                        .IsRequired();

                    b.Property<string>("MenuIcon");

                    b.Property<string>("MenuName")
                        .IsRequired();

                    b.Property<int>("MenuStatus");

                    b.Property<string>("MenuUrl")
                        .IsRequired();

                    b.Property<string>("ParentMenuCode")
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("ParentMenuName");

                    b.Property<long>("Sort");

                    b.HasKey("MenuCode");

                    b.HasIndex("MenuCode")
                        .IsUnique();

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("ShopBack.Entities.Permission", b =>
                {
                    b.Property<string>("PermissionCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("ActionCode");

                    b.Property<string>("Description");

                    b.Property<string>("Icon");

                    b.Property<string>("MenuCode");

                    b.Property<string>("PermissionName");

                    b.Property<int>("PermissionStatus");

                    b.Property<int>("PermissionType");

                    b.HasKey("PermissionCode");

                    b.HasIndex("MenuCode");

                    b.HasIndex("PermissionCode")
                        .IsUnique();

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("ShopBack.Entities.Role", b =>
                {
                    b.Property<string>("RoleCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Description");

                    b.Property<bool>("IsBuiltin");

                    b.Property<bool>("IsSuperAdminstrator");

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.Property<int>("RoleStatus");

                    b.HasKey("RoleCode");

                    b.HasIndex("RoleCode")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ShopBack.Entities.RolePermissionMapping", b =>
                {
                    b.Property<string>("PermissionCode")
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("RoleCode")
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("PermissionCode", "RoleCode");

                    b.HasIndex("RoleCode");

                    b.ToTable("RolePermissionMapping");
                });

            modelBuilder.Entity("ShopBack.Entities.User", b =>
                {
                    b.Property<string>("UserCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Avatar");

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<bool>("IsLocked");

                    b.Property<bool>("IsLogined");

                    b.Property<string>("LoginName")
                        .IsRequired();

                    b.Property<string>("Password");

                    b.Property<string>("RoleCode")
                        .IsRequired();

                    b.Property<int>("UserStatus");

                    b.HasKey("UserCode");

                    b.HasIndex("RoleCode");

                    b.HasIndex("UserCode")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("ShopBack.Entities.Menu", b =>
                {
                    b.OwnsOne("ShopBack.Entities.AuditEntity", "AuditEntity", b1 =>
                        {
                            b1.Property<string>("MenuCode");

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnName("CreatedOn");

                            b1.Property<Guid?>("CreatorId")
                                .HasColumnName("CreatorId");

                            b1.Property<string>("CreatorName")
                                .HasColumnName("CreatorName");

                            b1.Property<Guid?>("ModifiedByUserId")
                                .HasColumnName("ModifiedByUserId");

                            b1.Property<string>("ModifiedByUserName")
                                .HasColumnName("ModifiedByUserName");

                            b1.Property<DateTime?>("ModifiedOn")
                                .HasColumnName("ModifiedOn");

                            b1.HasKey("MenuCode");

                            b1.ToTable("Menu");

                            b1.HasOne("ShopBack.Entities.Menu")
                                .WithOne("AuditEntity")
                                .HasForeignKey("ShopBack.Entities.AuditEntity", "MenuCode")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ShopBack.Entities.Permission", b =>
                {
                    b.HasOne("ShopBack.Entities.Menu", "Menu")
                        .WithMany("Permissions")
                        .HasForeignKey("MenuCode");

                    b.OwnsOne("ShopBack.Entities.AuditEntity", "AuditEntity", b1 =>
                        {
                            b1.Property<string>("PermissionCode");

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnName("CreatedOn");

                            b1.Property<Guid?>("CreatorId")
                                .HasColumnName("CreatorId");

                            b1.Property<string>("CreatorName")
                                .HasColumnName("CreatorName");

                            b1.Property<Guid?>("ModifiedByUserId")
                                .HasColumnName("ModifiedByUserId");

                            b1.Property<string>("ModifiedByUserName")
                                .HasColumnName("ModifiedByUserName");

                            b1.Property<DateTime?>("ModifiedOn")
                                .HasColumnName("ModifiedOn");

                            b1.HasKey("PermissionCode");

                            b1.ToTable("Permission");

                            b1.HasOne("ShopBack.Entities.Permission")
                                .WithOne("AuditEntity")
                                .HasForeignKey("ShopBack.Entities.AuditEntity", "PermissionCode")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ShopBack.Entities.Role", b =>
                {
                    b.OwnsOne("ShopBack.Entities.AuditEntity", "AuditEntity", b1 =>
                        {
                            b1.Property<string>("RoleCode");

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnName("CreatedOn");

                            b1.Property<Guid?>("CreatorId")
                                .HasColumnName("CreatorId");

                            b1.Property<string>("CreatorName")
                                .HasColumnName("CreatorName");

                            b1.Property<Guid?>("ModifiedByUserId")
                                .HasColumnName("ModifiedByUserId");

                            b1.Property<string>("ModifiedByUserName")
                                .HasColumnName("ModifiedByUserName");

                            b1.Property<DateTime?>("ModifiedOn")
                                .HasColumnName("ModifiedOn");

                            b1.HasKey("RoleCode");

                            b1.ToTable("Role");

                            b1.HasOne("ShopBack.Entities.Role")
                                .WithOne("AuditEntity")
                                .HasForeignKey("ShopBack.Entities.AuditEntity", "RoleCode")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("ShopBack.Entities.RolePermissionMapping", b =>
                {
                    b.HasOne("ShopBack.Entities.Permission", "Permission")
                        .WithMany("Roles")
                        .HasForeignKey("PermissionCode")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ShopBack.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleCode")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ShopBack.Entities.User", b =>
                {
                    b.HasOne("ShopBack.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleCode")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("ShopBack.Entities.AuditEntity", "AuditEntity", b1 =>
                        {
                            b1.Property<string>("UserCode");

                            b1.Property<DateTime>("CreatedOn")
                                .HasColumnName("CreatedOn");

                            b1.Property<Guid?>("CreatorId")
                                .HasColumnName("CreatorId");

                            b1.Property<string>("CreatorName")
                                .HasColumnName("CreatorName");

                            b1.Property<Guid?>("ModifiedByUserId")
                                .HasColumnName("ModifiedByUserId");

                            b1.Property<string>("ModifiedByUserName")
                                .HasColumnName("ModifiedByUserName");

                            b1.Property<DateTime?>("ModifiedOn")
                                .HasColumnName("ModifiedOn");

                            b1.HasKey("UserCode");

                            b1.ToTable("User");

                            b1.HasOne("ShopBack.Entities.User")
                                .WithOne("AuditEntity")
                                .HasForeignKey("ShopBack.Entities.AuditEntity", "UserCode")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
