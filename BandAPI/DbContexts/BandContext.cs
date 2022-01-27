using BandAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.DbContexts
{
    public class BandContext : DbContext
    {
       public BandContext(DbContextOptions<BandContext> options) : base(options)
        {
        }

        public DbSet<Band> Bands { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(
            new Band
            {
                Id = Guid.Parse("0f77b12f-f92a-4952-9f69-8d080d6dc8eb"),
                Name = "Metallica",
                Founded = new DateTime(1980, 1, 1),
                MainGenre = "Heavy Metal 1"
            },
            new Band
            {
                Id = Guid.Parse("331e5dc4-36e9-4a83-bec9-bff6629d5645"),
                Name = "Guns N Roses",
                Founded = new DateTime(1985, 2, 1),
                MainGenre = "Rock"
            }, new Band
            {
                Id = Guid.Parse("91103959-751c-4c50-8bf4-d12f0f2a4734"),
                Name = "ABBA",
                Founded = new DateTime(1997, 3, 1),
                MainGenre = "Disco"
            }, new Band
            {
                Id = Guid.Parse("883695e5-82c5-4c70-ad7c-1ae5ea0a753c"),
                Name = "Oasis",
                Founded = new DateTime(1999, 5, 8),
                MainGenre = "Alternative"
            }, new Band
            {
                Id = Guid.Parse("1760af5f-89d9-4fcd-8314-71862dc74579"),
                Name = "A-ha",
                Founded = new DateTime(2000, 7, 7),
                MainGenre = "Pop"
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
