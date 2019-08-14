﻿// <auto-generated />
using CarOrder.Aggregate.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarOrder.Aggregate.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarOrder.Aggregate.Model.Models.User", b =>
                {
                    b.Property<string>("EmailId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("EmailId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            EmailId = "rkv@gmail.com",
                            Password = "pass@word1",
                            UserId = 0
                        },
                        new
                        {
                            EmailId = "shiv@gmail.com",
                            Password = "pass@word2",
                            UserId = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
