using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LearnAspDotNetCore.Data;

namespace LearnAspDotNetCore.Migrations
{
    [DbContext(typeof(LearnAspDotNetCoreContext))]
    [Migration("20170517193608_AddNameToTest")]
    partial class AddNameToTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

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
