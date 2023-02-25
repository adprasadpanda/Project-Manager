﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_Manager.dbcontext;

#nullable disable

namespace Project_Manager.Migrations
{
    [DbContext(typeof(ProjectsContext))]
    partial class ProjectsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Project_Manager.models.Issues", b =>
                {
                    b.Property<int>("issueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ProjectsprojectId")
                        .HasColumnType("int");

                    b.Property<int>("assignee")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<int>("reporter")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("issueId");

                    b.HasIndex("ProjectsprojectId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Project_Manager.models.Projects", b =>
                {
                    b.Property<int>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("creator")
                        .HasColumnType("int");

                    b.Property<string>("projectDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("projectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Project_Manager.models.Users", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project_Manager.models.Issues", b =>
                {
                    b.HasOne("Project_Manager.models.Projects", null)
                        .WithMany("listOfIssues")
                        .HasForeignKey("ProjectsprojectId");
                });

            modelBuilder.Entity("Project_Manager.models.Projects", b =>
                {
                    b.Navigation("listOfIssues");
                });
#pragma warning restore 612, 618
        }
    }
}