﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using garbage_collection.Data;

#nullable disable

namespace garbage_collection.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("garbage_collection.Models.CollectionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bin_id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Collection_time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("collections");
                });
#pragma warning restore 612, 618
        }
    }
}
