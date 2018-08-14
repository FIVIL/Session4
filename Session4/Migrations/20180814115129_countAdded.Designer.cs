﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Session4.Models;

namespace Session4.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20180814115129_countAdded")]
    partial class countAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Session4.Models.Faculty", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("ID");

                    b.ToTable("f");
                });

            modelBuilder.Entity("Session4.Models.Proffoser", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(40);

                    b.Property<Guid>("FacultyID");

                    b.Property<string>("LastName")
                        .HasMaxLength(20);

                    b.Property<string>("Mobile")
                        .HasMaxLength(13);

                    b.Property<int>("MratabelEmli");

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<int>("PersonalID");

                    b.Property<string>("Phone")
                        .HasMaxLength(13);

                    b.Property<DateTime>("SaleVorudBeDaneshgah");

                    b.Property<int>("ShomarePersoneli");

                    b.HasKey("ID");

                    b.HasIndex("FacultyID");

                    b.HasIndex("ShomarePersoneli")
                        .IsUnique();

                    b.ToTable("Proffosers");
                });

            modelBuilder.Entity("Session4.Models.Student", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Avg");

                    b.Property<string>("Email")
                        .HasMaxLength(40);

                    b.Property<int>("Enrolled");

                    b.Property<Guid>("FacultyID");

                    b.Property<string>("LastName")
                        .HasMaxLength(20);

                    b.Property<string>("Mobile")
                        .HasMaxLength(13);

                    b.Property<string>("Name")
                        .HasMaxLength(20);

                    b.Property<int>("Passed");

                    b.Property<int>("PersonalID");

                    b.Property<string>("Phone")
                        .HasMaxLength(13);

                    b.Property<int>("StudentNumber");

                    b.Property<int>("Type");

                    b.HasKey("ID");

                    b.HasIndex("FacultyID");

                    b.HasIndex("StudentNumber", "PersonalID")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Session4.Models.Proffoser", b =>
                {
                    b.HasOne("Session4.Models.Faculty", "Faculty")
                        .WithMany("Proffosers")
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Session4.Models.Student", b =>
                {
                    b.HasOne("Session4.Models.Faculty", "Faculty")
                        .WithMany("Students")
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
