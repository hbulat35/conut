﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ConutBackend.Database;
using ConutBackend.Database.Models.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConutBackend.Migrations.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230904112430_AddArticleDescription")]
    partial class AddArticleDescription
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConutBackend.Database.Models.Articles.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<ArticleComment>>("Comments")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HtmlContent")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserInfoId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ConutBackend.Database.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShortName")
                        .IsUnique();

                    b.ToTable("Links");
                });

            modelBuilder.Entity("ConutBackend.Database.Models.Users.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Professions")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortInfo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SignImageUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ConutBackend.Database.Models.Users.UserLink", b =>
                {
                    b.Property<int>("UserInfoId")
                        .HasColumnType("integer");

                    b.Property<int>("LinkId")
                        .HasColumnType("integer");

                    b.Property<string>("UserProfileUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserInfoId", "LinkId");

                    b.HasIndex("LinkId");

                    b.ToTable("UserLinks");
                });

            modelBuilder.Entity("ConutBackend.Database.Models.Articles.Article", b =>
                {
                    b.HasOne("ConutBackend.Database.Models.Users.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("ConutBackend.Database.Models.Users.UserInfo", b =>
                {
                    b.OwnsOne("ConutBackend.Database.Structures.FullName", "FullName", b1 =>
                        {
                            b1.Property<int>("UserInfoId")
                                .HasColumnType("integer");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("LastName")
                                .HasColumnType("text");

                            b1.Property<string>("SurName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("UserInfoId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserInfoId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("ConutBackend.Database.Models.Users.UserLink", b =>
                {
                    b.HasOne("ConutBackend.Database.Models.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConutBackend.Database.Models.Users.UserInfo", "UserInfo")
                        .WithMany("Links")
                        .HasForeignKey("UserInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("ConutBackend.Database.Models.Users.UserInfo", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
