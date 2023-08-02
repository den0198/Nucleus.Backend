﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nucleus.DAL.EntityFramework;

#nullable disable

namespace Nucleus.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_claims_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("claim_value");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("role_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_claims_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("claim_value");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_claims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("provider_display_name");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("user_providers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("user_tokens", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.AddOn", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("add_on_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)")
                        .HasColumnName("price");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("add_ons", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Parameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("parameter_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("parameters", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.ParameterValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("parameter_value_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<long>("ParameterId")
                        .HasColumnType("bigint")
                        .HasColumnName("parameter_id");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("ParameterId");

                    b.ToTable("parameter_values", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CountDislike")
                        .HasColumnType("bigint")
                        .HasColumnName("count_dislike");

                    b.Property<long>("CountLike")
                        .HasColumnType("bigint")
                        .HasColumnName("count_like");

                    b.Property<long>("CountSale")
                        .HasColumnType("bigint")
                        .HasColumnName("count_sale");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<bool>("IsSale")
                        .HasColumnType("bit")
                        .HasColumnName("is_sale");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<long>("StoreId")
                        .HasColumnType("bigint")
                        .HasColumnName("store_id");

                    b.Property<long>("SubCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("sub_category_id");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[normalized_name] IS NOT NULL");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Seller", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("seller_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("sellers", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Store", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("store_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<long>("SellerId")
                        .HasColumnType("bigint")
                        .HasColumnName("seller_id");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("stores", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.SubCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("sub_category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("sub_categories", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.SubProduct", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("sub_product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)")
                        .HasColumnName("price");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("sub_products", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.SubProductParameterValue", b =>
                {
                    b.Property<long>("SubProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("sub_product_id");

                    b.Property<long>("ParameterId")
                        .HasColumnType("bigint")
                        .HasColumnName("parameter_id");

                    b.Property<long>("ParameterValueId")
                        .HasColumnType("bigint")
                        .HasColumnName("parameter_value_id");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.HasKey("SubProductId", "ParameterId", "ParameterValueId");

                    b.HasIndex("ParameterId");

                    b.HasIndex("ParameterValueId");

                    b.ToTable("sub_product_parameter_values", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("concurrency_stamp");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_created");

                    b.Property<DateTime>("DateTimeModified")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_time_modified");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("is_lockout");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("lockout_end");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("middle_name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("normalized_username");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[normalized_username] IS NOT NULL");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.SqlQueryResults.ProductInCatalog", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nucleus.ModelsLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.AddOn", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Product", "Product")
                        .WithMany("AddOns")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Parameter", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Product", "Product")
                        .WithMany("Parameters")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.ParameterValue", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Parameter", "Parameter")
                        .WithMany("ParameterValues")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Product", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nucleus.ModelsLayer.Entities.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Store");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Seller", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.User", "User")
                        .WithOne("Seller")
                        .HasForeignKey("Nucleus.ModelsLayer.Entities.Seller", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Store", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Seller", "Seller")
                        .WithMany("Stores")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.SubCategory", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.SubProduct", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Product", "Product")
                        .WithMany("SubProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.SubProductParameterValue", b =>
                {
                    b.HasOne("Nucleus.ModelsLayer.Entities.Parameter", "Parameter")
                        .WithMany("SubProductParameterValues")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Nucleus.ModelsLayer.Entities.ParameterValue", "ParameterValue")
                        .WithMany("SubProductParameterValues")
                        .HasForeignKey("ParameterValueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Nucleus.ModelsLayer.Entities.SubProduct", "SubProduct")
                        .WithMany("SubProductParameterValues")
                        .HasForeignKey("SubProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Parameter");

                    b.Navigation("ParameterValue");

                    b.Navigation("SubProduct");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Parameter", b =>
                {
                    b.Navigation("ParameterValues");

                    b.Navigation("SubProductParameterValues");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.ParameterValue", b =>
                {
                    b.Navigation("SubProductParameterValues");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Product", b =>
                {
                    b.Navigation("AddOns");

                    b.Navigation("Parameters");

                    b.Navigation("SubProducts");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Seller", b =>
                {
                    b.Navigation("Stores");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.Store", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.SubCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.SubProduct", b =>
                {
                    b.Navigation("SubProductParameterValues");
                });

            modelBuilder.Entity("Nucleus.ModelsLayer.Entities.User", b =>
                {
                    b.Navigation("Seller");
                });
#pragma warning restore 612, 618
        }
    }
}