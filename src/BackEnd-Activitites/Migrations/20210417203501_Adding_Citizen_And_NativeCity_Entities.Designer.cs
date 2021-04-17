﻿// <auto-generated />
using System;
using BackEndActivitites.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndActivitites.Migrations
{
    [DbContext(typeof(NewContext))]
    [Migration("20210417203501_Adding_Citizen_And_NativeCity_Entities")]
    partial class Adding_Citizen_And_NativeCity_Entities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndActivitites.Models.Citizen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdNAtiveCity")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NativeCityId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NativeCityId");

                    b.ToTable("Citizen");
                });

            modelBuilder.Entity("BackEndActivitites.Models.NativeCity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NativeCity");
                });

            modelBuilder.Entity("BackEndActivitites.Models.Citizen", b =>
                {
                    b.HasOne("BackEndActivitites.Models.NativeCity", "NativeCity")
                        .WithMany("Citizens")
                        .HasForeignKey("NativeCityId");
                });
#pragma warning restore 612, 618
        }
    }
}
