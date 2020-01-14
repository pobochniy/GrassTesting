﻿// <auto-generated />
using System;
using GrassTesting.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GrassTesting.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200114132005_TravianPlayers")]
    partial class TravianPlayers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GrassTesting.Entity.TravianPlayerHistory", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Clan");

                    b.Property<string>("CountPopulation");

                    b.Property<int>("CountVillages");

                    b.Property<string>("Name");

                    b.Property<string>("Nation");

                    b.Property<string>("PointAtt");

                    b.Property<string>("PointDef");

                    b.Property<int>("Rank");

                    b.Property<string>("RankAtt");

                    b.Property<string>("RankDef");

                    b.Property<string>("RankPopulation");

                    b.Property<string>("VillagesJson");

                    b.HasKey("Id", "Date");

                    b.ToTable("TravianPlayersHistory");
                });

            modelBuilder.Entity("GrassTesting.Entity.TravianPlayerId", b =>
                {
                    b.Property<int>("Id");

                    b.HasKey("Id");

                    b.ToTable("TravianPlayersId");
                });
#pragma warning restore 612, 618
        }
    }
}