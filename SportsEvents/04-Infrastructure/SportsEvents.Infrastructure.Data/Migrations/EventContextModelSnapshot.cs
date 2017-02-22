using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SportsEvents.Infrastructure.Data.Context;
using SportsEvents.Domain.Entities;

namespace SportsEvents.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsEvents.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SportsEvents.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CommentType");

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("EventId");

                    b.Property<string>("FullComment");

                    b.Property<string>("ParentIdentifier");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SportsEvents.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CityId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SportsEvents.Domain.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("SportsEvents.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SportsEvents.Domain.Entities.City", b =>
                {
                    b.HasOne("SportsEvents.Domain.Entities.Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("SportsEvents.Domain.Entities.Comment", b =>
                {
                    b.HasOne("SportsEvents.Domain.Entities.Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId");

                    b.HasOne("SportsEvents.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SportsEvents.Domain.Entities.Event", b =>
                {
                    b.HasOne("SportsEvents.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("SportsEvents.Domain.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");
                });
        }
    }
}
