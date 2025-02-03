using System;
using Balynor_DB.Models;
using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

namespace Balynor_DB.Data
{
	public class AppDbContext: DbContext
	{

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DataModel> DataModels { get; set; }
    }
}

