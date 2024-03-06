using Microsoft.EntityFrameworkCore;
using System;

namespace DB
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> Options) :base(Options)
        {

        }

        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
    }
}
