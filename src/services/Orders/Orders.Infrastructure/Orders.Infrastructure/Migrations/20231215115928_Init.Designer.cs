﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Orders.Infrastructure;

#nullable disable

namespace Orders.Infrastructure.Migrations
{
    [DbContext(typeof(OrdersDbContext))]
    [Migration("20231215115928_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Orders.Domain.StateMachines.OrderState", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CorrelationId");

                    b.ToTable("OrderState");
                });
#pragma warning restore 612, 618
        }
    }
}