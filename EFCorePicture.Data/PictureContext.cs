using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCorePicture.Data
{
    public class PictureContext : DbContext
    {
        private readonly string _connectionString;
        public PictureContext(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        public DbSet<Picture> Picture { get; set; }
    }
}
