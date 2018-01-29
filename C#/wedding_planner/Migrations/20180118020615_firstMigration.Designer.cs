﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using wedding_planner.Models;

namespace wedding_planner.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20180118020615_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("wedding_planner.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatorUserId");

                    b.Property<int>("Creator_Id");

                    b.Property<DateTime>("Event_Date");

                    b.Property<DateTime>("UpdatedAT");

                    b.Property<string>("WedderOne");

                    b.Property<string>("WedderTwo");

                    b.HasKey("EventId");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("wedding_planner.Models.Guests", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("UpdatedAT");

                    b.Property<int>("UserId");

                    b.Property<int>("WeddingId");

                    b.HasKey("EventId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("wedding_planner.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAT");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("wedding_planner.Models.Event", b =>
                {
                    b.HasOne("wedding_planner.Models.User", "Creator")
                        .WithMany("Weddings")
                        .HasForeignKey("CreatorUserId");
                });

            modelBuilder.Entity("wedding_planner.Models.Guests", b =>
                {
                    b.HasOne("wedding_planner.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("wedding_planner.Models.Event", "Wedding")
                        .WithMany("Guests")
                        .HasForeignKey("WeddingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
