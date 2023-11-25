﻿// <auto-generated />
using System;
using ChallengeBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChallengeBackend.API.Migrations
{
    [DbContext(typeof(ChallengeBackendContext))]
    partial class ChallengeBackendContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChallengeBackend.Infrastructure.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmployeeForename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PermissionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PermissionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("PermissionTypeId")
                        .IsUnique();

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("ChallengeBackend.Infrastructure.Entities.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermissionTypes");
                });

            modelBuilder.Entity("ChallengeBackend.Infrastructure.Entities.Permission", b =>
                {
                    b.HasOne("ChallengeBackend.Infrastructure.Entities.PermissionType", "PermissionType")
                        .WithOne()
                        .HasForeignKey("ChallengeBackend.Infrastructure.Entities.Permission", "PermissionTypeId");

                    b.Navigation("PermissionType");
                });
#pragma warning restore 612, 618
        }
    }
}
