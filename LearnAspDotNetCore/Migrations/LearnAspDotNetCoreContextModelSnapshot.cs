using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LearnAspDotNetCore.Data;

namespace LearnAspDotNetCore.Migrations
{
    [DbContext(typeof(LearnAspDotNetCoreContext))]
    partial class LearnAspDotNetCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("DatabaseObjects.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dob");

                    b.Property<string>("fName");

                    b.Property<string>("lName");

                    b.Property<string>("title");

                    b.HasKey("ID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("LearnAspDotNetCore.Models.Test", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.ToTable("Test");
                });
        }
    }
}
