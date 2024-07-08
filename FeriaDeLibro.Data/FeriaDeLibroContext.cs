using FeriaDeLibro.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaDeLibro.Data
{
    public class FeriaDeLibroContext : DbContext 
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Course> Courses { get; set; }

        public FeriaDeLibroContext(DbContextOptions<FeriaDeLibroContext> options) : base(options)
        {
        }
    }
}
