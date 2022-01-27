using BandAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.DbContexts
{
    public class AlbumContext : DbContext
    {
        public AlbumContext(DbContextOptions<AlbumContext> options) : base(options)
        {
        }
        public DbSet<Album> Albums { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    Id = Guid.Parse("d18cafff-321f-4845-9c20-49a122146dc2"),
                    Title = "Master Of Puppets",
                    Description = "One of the best heavy metal albums ever",
                    BandId = Guid.Parse("0f77b12f-f92a-4952-9f69-8d080d6dc8eb")
                }, new Album
                {
                    Id = Guid.Parse("c341073e-6caa-4bef-a46b-a2249f347d2f"),
                    Title = "Master Of Puppets",
                    Description = "One of the best heavy metal albums ever",
                    BandId = Guid.Parse("331e5dc4-36e9-4a83-bec9-bff6629d5645")
                }, new Album
                {
                    Id = Guid.Parse("6eda6309-67b0-49c1-a56d-830dabd4d5ce"),
                    Title = "Master Of Puppets",
                    Description = "One of the best heavy metal albums ever",
                    BandId = Guid.Parse("91103959-751c-4c50-8bf4-d12f0f2a4734")
                }, new Album
                {
                    Id = Guid.Parse("79d9f693-0fb4-4452-90a3-bfe603371357"),
                    Title = "Master Of Puppets",
                    Description = "One of the best heavy metal albums ever",
                    BandId = Guid.Parse("883695e5-82c5-4c70-ad7c-1ae5ea0a753c")
                }, new Album
                {
                    Id = Guid.Parse("9c6957a4-953c-49d7-9496-49ea153be6e6"),
                    Title = "Master Of Puppets",
                    Description = "One of the best heavy metal albums ever",
                    BandId = Guid.Parse("1760af5f-89d9-4fcd-8314-71862dc74579")
                });

            base.OnModelCreating(modelBuilder);
        }
    }

}
