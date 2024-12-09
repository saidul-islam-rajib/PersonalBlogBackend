﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sober.Infrastructure.Persistence;

#nullable disable

namespace Sober.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    partial class BlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sober.Domain.Aggregates.PostAggregate.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostAbstract")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PostTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Posts", (string)null);
                });

            modelBuilder.Entity("Sober.Domain.Aggregates.PostAggregate.Post", b =>
                {
                    b.OwnsMany("Sober.Domain.Aggregates.PostAggregate.Entities.PostSection", "Sections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("SectionId");

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("SectionDescription")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)");

                            b1.Property<string>("SectionTitle")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id", "PostId");

                            b1.HasIndex("PostId");

                            b1.ToTable("Sections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");

                            b1.OwnsMany("Sober.Domain.Aggregates.PostAggregate.Entities.PostItem", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier")
                                        .HasColumnName("PostItemId");

                                    b2.Property<Guid>("SectionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("PostId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("PostItemDescription")
                                        .IsRequired()
                                        .HasMaxLength(500)
                                        .HasColumnType("nvarchar(500)");

                                    b2.Property<string>("PostItemImageLink")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("PostItemTitle")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("Id", "SectionId", "PostId");

                                    b2.HasIndex("SectionId", "PostId");

                                    b2.ToTable("PostItems", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("SectionId", "PostId");
                                });

                            b1.Navigation("Items");
                        });

                    b.OwnsMany("Sober.Domain.Aggregates.PostAggregate.Entities.PostTopic", "TopicIds", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("TopicId");

                            b1.Property<Guid>("PostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("TopicTitle")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id", "PostId");

                            b1.HasIndex("PostId");

                            b1.ToTable("Topics", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });

                    b.Navigation("Sections");

                    b.Navigation("TopicIds");
                });
#pragma warning restore 612, 618
        }
    }
}
