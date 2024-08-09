﻿// <auto-generated />
using System;
using Cengaver.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cengaver.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240807080642_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cengaver.Domain.CommunicationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CommunicationTypes");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDuty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfAssignment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GuardAssignedByUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WardenUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WardenUserId");

                    b.ToTable("GuardDuties");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDutyBreak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfClaim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("GuardDutieBreaks");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDutyBreakType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("GuardDutyBreakTypes");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDutyNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuardDutyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("NoteTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuardDutyId");

                    b.HasIndex("NoteTypeId");

                    b.ToTable("GuardDutyNotes");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDutyNoteType", b =>
                {
                    b.Property<int>("NoteTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoteTypeId"));

                    b.Property<string>("NoteTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoteTypeId");

                    b.ToTable("GuardDutyNoteType");
                });

            modelBuilder.Entity("Cengaver.Domain.Permission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserPermission")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleId", "UserPermission");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Cengaver.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Cengaver.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TeamLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Cengaver.Domain.TeamTransactionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamTransactionLogs");
                });

            modelBuilder.Entity("Cengaver.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SicilNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UserRegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cengaver.Domain.UserCommunication", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CommunicationTypeId")
                        .HasColumnType("int");

                    b.Property<string>("CommunicationString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "CommunicationTypeId");

                    b.HasIndex("CommunicationTypeId");

                    b.ToTable("UserCommunications");
                });

            modelBuilder.Entity("Cengaver.Domain.UserIsInTeamRelation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("UserIsInTeamRelations");
                });

            modelBuilder.Entity("Cengaver.Domain.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Cengaver.Domain.UserTransactionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserTransactionLogs");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDuty", b =>
                {
                    b.HasOne("Cengaver.Domain.User", "WardenUser")
                        .WithMany("GuardDuties")
                        .HasForeignKey("WardenUserId");

                    b.Navigation("WardenUser");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDutyBreak", b =>
                {
                    b.HasOne("Cengaver.Domain.GuardDutyBreakType", "GuardDutyBreakType")
                        .WithMany("GuardDutyBreaks")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cengaver.Domain.User", "User")
                        .WithMany("GuardDutyBreaks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuardDutyBreakType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDutyNote", b =>
                {
                    b.HasOne("Cengaver.Domain.GuardDuty", "GuardDuty")
                        .WithMany("GuardDutyNotes")
                        .HasForeignKey("GuardDutyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cengaver.Domain.GuardDutyNoteType", "NoteType")
                        .WithMany("GuardDutyNotes")
                        .HasForeignKey("NoteTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuardDuty");

                    b.Navigation("NoteType");
                });

            modelBuilder.Entity("Cengaver.Domain.Permission", b =>
                {
                    b.HasOne("Cengaver.Domain.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Cengaver.Domain.TeamTransactionLog", b =>
                {
                    b.HasOne("Cengaver.Domain.Team", "Team")
                        .WithMany("TeamTransactionLogs")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Cengaver.Domain.UserCommunication", b =>
                {
                    b.HasOne("Cengaver.Domain.CommunicationType", "CommunicationType")
                        .WithMany("UserCommunications")
                        .HasForeignKey("CommunicationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cengaver.Domain.User", "User")
                        .WithMany("UserCommunications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommunicationType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cengaver.Domain.UserIsInTeamRelation", b =>
                {
                    b.HasOne("Cengaver.Domain.Team", "Team")
                        .WithMany("UserIsInTeamRelations")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cengaver.Domain.User", "User")
                        .WithMany("UserIsInTeamRelations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cengaver.Domain.UserRole", b =>
                {
                    b.HasOne("Cengaver.Domain.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cengaver.Domain.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cengaver.Domain.UserTransactionLog", b =>
                {
                    b.HasOne("Cengaver.Domain.User", "User")
                        .WithMany("UserTransactionLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cengaver.Domain.CommunicationType", b =>
                {
                    b.Navigation("UserCommunications");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDuty", b =>
                {
                    b.Navigation("GuardDutyNotes");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDutyBreakType", b =>
                {
                    b.Navigation("GuardDutyBreaks");
                });

            modelBuilder.Entity("Cengaver.Domain.GuardDutyNoteType", b =>
                {
                    b.Navigation("GuardDutyNotes");
                });

            modelBuilder.Entity("Cengaver.Domain.Role", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Cengaver.Domain.Team", b =>
                {
                    b.Navigation("TeamTransactionLogs");

                    b.Navigation("UserIsInTeamRelations");
                });

            modelBuilder.Entity("Cengaver.Domain.User", b =>
                {
                    b.Navigation("GuardDuties");

                    b.Navigation("GuardDutyBreaks");

                    b.Navigation("UserCommunications");

                    b.Navigation("UserIsInTeamRelations");

                    b.Navigation("UserRoles");

                    b.Navigation("UserTransactionLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
