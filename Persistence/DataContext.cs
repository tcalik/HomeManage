using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
    }
}