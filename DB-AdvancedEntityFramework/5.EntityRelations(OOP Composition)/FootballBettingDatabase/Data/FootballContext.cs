namespace Data
{
    using Data.Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FootballContext : DbContext
    {
        public FootballContext()
            : base("name=FootballContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<FootballContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FootballContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Position>()
            //                                .HasKey(p => p.PositionID)
            //                                .HasMany(p => p.Players)
            //                                .WithMany(p => p.Positions)
            //                                .Map(m =>
            //                                {
            //                                    m.ToTable("PlayerPositions");
            //                                    m.MapLeftKey("PositionID");
            //                                    m.MapRightKey("PlayerId");
            //                                });
            modelBuilder.Entity<Position>()
                                            .HasKey(p => p.PositionID)
                                            .HasMany(p => p.Players)
                                            .WithRequired(p => p.Position)
                                            .HasForeignKey(p => p.PositionId);

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<BetGame> BetGames { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Competition> Competitions { get; set; }

        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }

        public virtual DbSet<Continent> Continents { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<PlayerStatistics> PlayerStatistics { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<ResultPrediction> ResultPredictions { get; set; }

        public virtual DbSet<Round> Rounds { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<User> Users { get; set; }

    }
}