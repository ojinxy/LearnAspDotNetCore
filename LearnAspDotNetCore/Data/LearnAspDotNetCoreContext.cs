using System;
using DatabaseObjects;
using LearnAspDotNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAspDotNetCore.Data
{
    public class LearnAspDotNetCoreContext : DbContext
    {
        

		public LearnAspDotNetCoreContext(DbContextOptions<LearnAspDotNetCoreContext> options) : base(options)
        {
		}

		public LearnAspDotNetCoreContext()
		{
		}

		public DbSet<Test> Test { get; set; }
        public DbSet<Person> Person { get; set; }

    }
}
