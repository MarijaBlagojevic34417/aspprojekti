﻿// <auto-generated />
using System;
using ASP.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.DataAccess.Migrations
{
    [DbContext(typeof(TheContext))]
    [Migration("20240904094702_ContactMigration")]
    partial class ContactMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NameCategory")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdParentComment")
                        .HasColumnType("int");

                    b.Property<int>("IdRecipe")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdParentComment");

                    b.HasIndex("IdRecipe");

                    b.HasIndex("IdUser");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ASP.Domain.Entities.ErrorLog", b =>
                {
                    b.Property<Guid>("ErrorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("StrackTrace")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ErrorId");

                    b.ToTable("ErrorLogs");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("KcalPer100gr")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameFood")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NameFood")
                        .IsUnique();

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("ASP.Domain.Entities.ImageFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("ImageFiles");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRecipe")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("NameRate")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdRecipe");

                    b.HasIndex("IdUser");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameReaction")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("NameReaction")
                        .IsUnique();

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int>("IdImageFile")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TitleRecipe")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("TotalKcal")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdImageFile");

                    b.HasIndex("IdUser");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("ASP.Domain.Entities.RecipeCategory", b =>
                {
                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdRecipe")
                        .HasColumnType("int");

                    b.HasKey("IdCategory", "IdRecipe");

                    b.HasIndex("IdRecipe");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("ASP.Domain.Entities.RecipeFood", b =>
                {
                    b.Property<int>("IdRecipe")
                        .HasColumnType("int");

                    b.Property<int>("IdFood")
                        .HasColumnType("int");

                    b.Property<int>("Gram")
                        .HasColumnType("int");

                    b.HasKey("IdRecipe", "IdFood");

                    b.HasIndex("IdFood");

                    b.ToTable("RecipeFoods");
                });

            modelBuilder.Entity("ASP.Domain.Entities.UseCaseLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExecutedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UseCaseData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UseCaseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Username", "UseCaseName", "ExecutedAt");

                    SqlServerIndexBuilderExtensions.IncludeProperties(b.HasIndex("Username", "UseCaseName", "ExecutedAt"), new[] { "UseCaseData" });

                    b.ToTable("UseCaseLogs");
                });

            modelBuilder.Entity("ASP.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("IdImageFile")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FirstName");

                    b.HasIndex("IdImageFile");

                    b.HasIndex("LastName");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ASP.Domain.Entities.UserCommentReaction", b =>
                {
                    b.Property<int>("IdComment")
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.Property<int>("IdReaction")
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.HasKey("IdComment", "IdReaction", "IdUser");

                    b.HasIndex("IdReaction");

                    b.HasIndex("IdUser");

                    b.ToTable("UserCommentReactions");
                });

            modelBuilder.Entity("ASP.Domain.Entities.UserRecipeReaction", b =>
                {
                    b.Property<int>("IdRecipe")
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.Property<int>("IdReaction")
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.HasKey("IdRecipe", "IdReaction", "IdUser");

                    b.HasIndex("IdReaction");

                    b.HasIndex("IdUser");

                    b.ToTable("UserRecipeReactions");
                });

            modelBuilder.Entity("ASP.Domain.Entities.UserUseCase", b =>
                {
                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("IdUseCase")
                        .HasColumnType("int");

                    b.Property<int>("IdUserUseCase")
                        .HasColumnType("int");

                    b.HasKey("IdUser", "IdUseCase");

                    b.ToTable("UserUseCases");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Comment", b =>
                {
                    b.HasOne("ASP.Domain.Entities.Comment", "ParentComment")
                        .WithMany("ChildrenComments")
                        .HasForeignKey("IdParentComment")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ASP.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("IdRecipe")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParentComment");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Rate", b =>
                {
                    b.HasOne("ASP.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Rates")
                        .HasForeignKey("IdRecipe")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.User", "User")
                        .WithMany("Rates")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Recipe", b =>
                {
                    b.HasOne("ASP.Domain.Entities.ImageFile", "ImageFiles")
                        .WithMany("Recipes")
                        .HasForeignKey("IdImageFile")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ImageFiles");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASP.Domain.Entities.RecipeCategory", b =>
                {
                    b.HasOne("ASP.Domain.Entities.Category", "Category")
                        .WithMany("RecipeCategories")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeCategories")
                        .HasForeignKey("IdRecipe")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("ASP.Domain.Entities.RecipeFood", b =>
                {
                    b.HasOne("ASP.Domain.Entities.Food", "Food")
                        .WithMany("RecipeFoods")
                        .HasForeignKey("IdFood")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.Recipe", "Recipe")
                        .WithMany("RecipeFoods")
                        .HasForeignKey("IdRecipe")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("ASP.Domain.Entities.User", b =>
                {
                    b.HasOne("ASP.Domain.Entities.ImageFile", "ImageFiles")
                        .WithMany("Users")
                        .HasForeignKey("IdImageFile")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ImageFiles");
                });

            modelBuilder.Entity("ASP.Domain.Entities.UserCommentReaction", b =>
                {
                    b.HasOne("ASP.Domain.Entities.Comment", "Comment")
                        .WithMany("UserCommentReactions")
                        .HasForeignKey("IdComment")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.Reaction", "Reaction")
                        .WithMany("UserCommentReactions")
                        .HasForeignKey("IdReaction")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.User", "User")
                        .WithMany("UserCommentReactions")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("Reaction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASP.Domain.Entities.UserRecipeReaction", b =>
                {
                    b.HasOne("ASP.Domain.Entities.Reaction", "Reaction")
                        .WithMany("UserRecipeReactions")
                        .HasForeignKey("IdReaction")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.Recipe", "Recipe")
                        .WithMany("UserRecipeReactions")
                        .HasForeignKey("IdRecipe")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASP.Domain.Entities.User", "User")
                        .WithMany("UserRecipeReaction")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Reaction");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASP.Domain.Entities.UserUseCase", b =>
                {
                    b.HasOne("ASP.Domain.Entities.User", "User")
                        .WithMany("UserUseCases")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Category", b =>
                {
                    b.Navigation("RecipeCategories");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Comment", b =>
                {
                    b.Navigation("ChildrenComments");

                    b.Navigation("UserCommentReactions");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Food", b =>
                {
                    b.Navigation("RecipeFoods");
                });

            modelBuilder.Entity("ASP.Domain.Entities.ImageFile", b =>
                {
                    b.Navigation("Recipes");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Reaction", b =>
                {
                    b.Navigation("UserCommentReactions");

                    b.Navigation("UserRecipeReactions");
                });

            modelBuilder.Entity("ASP.Domain.Entities.Recipe", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Rates");

                    b.Navigation("RecipeCategories");

                    b.Navigation("RecipeFoods");

                    b.Navigation("UserRecipeReactions");
                });

            modelBuilder.Entity("ASP.Domain.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Rates");

                    b.Navigation("Recipes");

                    b.Navigation("UserCommentReactions");

                    b.Navigation("UserRecipeReaction");

                    b.Navigation("UserUseCases");
                });
#pragma warning restore 612, 618
        }
    }
}
