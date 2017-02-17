using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TodoList.Infrastructure.Data.Context;

namespace TodoList.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodoList.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("TodoList.Domain.Entities.Comment.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommentParentIdentifier");

                    b.Property<DateTime>("DateTime");

                    b.Property<int?>("EventId");

                    b.Property<string>("FullComment");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TodoList.Domain.Entities.Event", b =>
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

            modelBuilder.Entity("TodoList.Domain.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("TodoList.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TodoList.Domain.Entities.City", b =>
                {
                    b.HasOne("TodoList.Domain.Entities.Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("TodoList.Domain.Entities.Comment.Comment", b =>
                {
                    b.HasOne("TodoList.Domain.Entities.Event")
                        .WithMany("Comments")
                        .HasForeignKey("EventId");

                    b.HasOne("TodoList.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TodoList.Domain.Entities.Event", b =>
                {
                    b.HasOne("TodoList.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("TodoList.Domain.Entities.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");
                });
        }
    }
}
