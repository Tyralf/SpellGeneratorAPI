using Microsoft.EntityFrameworkCore;
using SpellGenerator.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Spell> Spells { get; set; }
        public DbSet<AddOn> AddOns { get; set; }
        public DbSet<Mastery> Masteries { get; set; }
        public DbSet<Magic> Magics { get; set; }
        public DbSet<SpellBook> SpellBooks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spell>()
               .HasMany(s => s.AddOns)
               .WithMany(a => a.Spells)
               .UsingEntity<Dictionary<string, object>>(
                   "SpellAddOn",
                   j => j
                       .HasOne<AddOn>()
                       .WithMany()
                       .HasForeignKey("AddOnId"),
                   j => j
                       .HasOne<Spell>()
                       .WithMany()
                       .HasForeignKey("SpellId"));

            modelBuilder.Entity<SpellBook>()
                .HasMany(sb => sb.StoredSpells)
                .WithMany(s => s.SpellBooks)
                .UsingEntity<Dictionary<string, object>>(
                    "SpellBookSpell",
                    j => j
                        .HasOne<Spell>()
                        .WithMany()
                        .HasForeignKey("SpellId"),
                    j => j
                        .HasOne<SpellBook>()
                        .WithMany()
                        .HasForeignKey("SpellBookId"));

            modelBuilder.Entity<User>()
                .HasOne(u => u.SpellBook)
                .WithOne(sb => sb.User)
                .HasForeignKey<User>(sb => sb.SpellBookId);

            modelBuilder.Entity<Spell>()
                .HasMany(sb => sb.RequieredMagics)
                .WithMany(s => s.Spells)
                .UsingEntity<Dictionary<string, object>>(
                    "SpellMagics",
                    s => s
                        .HasOne<Magic>()
                        .WithMany()
                        .HasForeignKey("MagicId"),
                    m => m
                        .HasOne<Spell>()
                        .WithMany()
                        .HasForeignKey("SpellId"));

            modelBuilder.Entity<Spell>()
                .HasMany(sb => sb.RequieredMasteries)
                .WithMany(s => s.Spells)
                .UsingEntity<Dictionary<string, object>>(
                    "SpellMasteries",
                    s => s
                        .HasOne<Mastery>()
                        .WithMany()
                        .HasForeignKey("MasteryId"),
                    m => m
                        .HasOne<Spell>()
                        .WithMany()
                        .HasForeignKey("SpellId"));

            modelBuilder.Entity<User>()
                .HasMany(sb => sb.KnownMagics)
                .WithMany(s => s.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserMagics",
                    s => s
                        .HasOne<Magic>()
                        .WithMany()
                        .HasForeignKey("MagicId"),
                    m => m
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(sb => sb.KnownMasteries)
                .WithMany(s => s.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserMasteries",
                    s => s
                        .HasOne<Mastery>()
                        .WithMany()
                        .HasForeignKey("MasteryId"),
                    m => m
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId"));

            // Seed data for Masteries
        modelBuilder.Entity<Mastery>().HasData(
            new Mastery { Id = 1, Name = "Evocation" },
            new Mastery { Id = 2, Name = "Infusion" },
            new Mastery { Id = 3, Name = "Renforcement" },
            new Mastery { Id = 4, Name = "Psychique" },
            new Mastery { Id = 5, Name = "Invocation", ParentMasteryId = 1 },
            new Mastery { Id = 6, Name = "Transformation", ParentMasteryId = 2 },
            new Mastery { Id = 7, Name = "Transmogrification", ParentMasteryId = 3 },
            new Mastery { Id = 8, Name = "Illusion", ParentMasteryId = 4 },
            new Mastery { Id = 9, Name = "Conjuration", ParentMasteryId = 5 },
            new Mastery { Id = 10, Name = "Techno-Magie", ParentMasteryId = 6 },
            new Mastery { Id = 11, Name = "Corporalki", ParentMasteryId = 7 },
            new Mastery { Id = 12, Name = "Projection", ParentMasteryId = 8 }
        );

        // Seed data for Magics
        modelBuilder.Entity<Magic>().HasData(
            new Magic { Id = 1, Name = "Incendiaire" },
            new Magic { Id = 2, Name = "Terrestre" },
            new Magic { Id = 3, Name = "Aérienne" },
            new Magic { Id = 4, Name = "Aquatique" },
            new Magic { Id = 5, Name = "Lumineuse" },
            new Magic { Id = 6, Name = "Lunaire" },
            new Magic { Id = 7, Name = "Ténébreuse" },
            new Magic { Id = 8, Name = "Chaotique" }
        );

        }

    }
}
