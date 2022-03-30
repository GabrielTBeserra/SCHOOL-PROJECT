﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCHOOL_PROJECT_INFRASTRUCTURE.Models;

#nullable disable

namespace SCHOOL_PROJECT_INFRASTRUCTURE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220329022654_AddTeacher")]
    partial class AddTeacher
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.Audit.LogEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("LogTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValue(new DateTime(2022, 3, 28, 23, 26, 54, 158, DateTimeKind.Local).AddTicks(1958))
                        .HasColumnName("log_time");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("type_name");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.School.SchoolEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("School");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.Student.StudentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Registration")
                        .HasColumnType("int")
                        .HasColumnName("registration");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.Teacher.TeacherEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("code");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.User.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("lastname");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser.SchoolUserRelationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<bool>("IsAdministrator")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("administrator");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int")
                        .HasColumnName("school_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.HasIndex("UserId");

                    b.ToTable("SchoolUser");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.Student.StudentEntity", b =>
                {
                    b.HasOne("SCHOOL_PROJECT_DOMAIN.Entities.User.UserEntity", "User")
                        .WithMany("Students")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.Teacher.TeacherEntity", b =>
                {
                    b.HasOne("SCHOOL_PROJECT_DOMAIN.Entities.User.UserEntity", "User")
                        .WithMany("Teachers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Relationships.SchoolUser.SchoolUserRelationship", b =>
                {
                    b.HasOne("SCHOOL_PROJECT_DOMAIN.Entities.School.SchoolEntity", "School")
                        .WithMany("Users")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SCHOOL_PROJECT_DOMAIN.Entities.User.UserEntity", "User")
                        .WithMany("Schools")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.School.SchoolEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("SCHOOL_PROJECT_DOMAIN.Entities.User.UserEntity", b =>
                {
                    b.Navigation("Schools");

                    b.Navigation("Students");

                    b.Navigation("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
