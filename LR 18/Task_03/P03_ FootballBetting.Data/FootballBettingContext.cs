using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P03__FootballBetting.Data.Models;

namespace P03__FootballBetting.Data
{
    internal class FootballBettingContext:DbContext
    {
        public FootballBettingContext() { }
        public FootballBettingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatitic> PlayerStatitics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DI6V8K1\\SQLEXPRESS;Database=FootballBetting;Trusted_Connection=True;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatitic>().HasKey(ps => new {ps.PlayerId, ps.GameId});
            modelBuilder.Entity<User>().Property(u => u.Balance).HasPrecision(18, 2);
            modelBuilder.Entity<Team>().Property(t => t.Budget).HasPrecision(18, 2);
            modelBuilder.Entity<Game>().Property(g => g.AwayTeamBetRate).HasPrecision(18, 2);
            modelBuilder.Entity<Game>().Property(g => g.DrawBetRate).HasPrecision(18, 2);
            modelBuilder.Entity<Game>().Property(g => g.HomeTeamBetRate).HasPrecision(18, 2);
            modelBuilder.Entity<Bet>().Property(b => b.Amount).HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
