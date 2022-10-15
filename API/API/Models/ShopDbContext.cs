﻿using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        private string connectionString = @"Server=DELL-5490\MSSQLSERVER01;Database=shop;Trusted_Connection=True";

        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>().HasData(new List<Products>()
            {
                new Products(){ID=1, Name= "AA", Number=10 , Price=10000  },
                new Products(){ID=2, Name= "BB", Number=15 , Price=20000  },
                new Products(){ID=3, Name= "CC", Number=20 , Price=30000  },
                new Products(){ID=4, Name= "DD", Number=11 , Price=20000  },
                new Products(){ID=5, Name= "EE", Number=12 , Price=70000  },
                new Products(){ID=6, Name= "FF", Number=16 , Price=65000  },
                new Products(){ID=7, Name= "GG", Number=17 , Price=30000  },
                new Products(){ID=8, Name= "HH", Number=15 , Price=70000  },
            });
        }
    }
}