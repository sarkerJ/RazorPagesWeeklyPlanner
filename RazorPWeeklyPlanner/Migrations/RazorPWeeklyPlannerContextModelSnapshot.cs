﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPWeeklyPlanner.Data;

namespace RazorPWeeklyPlanner.Migrations
{
    [DbContext(typeof(RazorPWeeklyPlannerContext))]
    partial class RazorPWeeklyPlannerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RazorPWeeklyPlanner.Models.WeekDay", b =>
                {
                    b.Property<int>("WeekDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Day")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeekDayId");

                    b.ToTable("WeekDay");
                });
#pragma warning restore 612, 618
        }
    }
}
