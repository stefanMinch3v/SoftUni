namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BetGames",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        BetId = c.Int(nullable: false),
                        ResultPredictionId = c.Int(),
                    })
                .PrimaryKey(t => new { t.GameId, t.BetId })
                .ForeignKey("dbo.Bets", t => t.BetId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.ResultPredictions", t => t.ResultPredictionId)
                .Index(t => t.GameId)
                .Index(t => t.BetId)
                .Index(t => t.ResultPredictionId);
            
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        BetId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAndTimeOfBet = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BetId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        FullName = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(),
                        AwayTeamId = c.Int(),
                        RoundId = c.Int(),
                        CompetitionId = c.Int(),
                        HomeGoals = c.Int(nullable: false),
                        AwayGoals = c.Int(nullable: false),
                        DateAndTimeOfGames = c.DateTime(nullable: false),
                        HomeTeamWinBetRate = c.Single(nullable: false),
                        AwayTeamWinBetRate = c.Single(nullable: false),
                        DrawGameBetRate = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId)
                .ForeignKey("dbo.Rounds", t => t.RoundId)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.RoundId)
                .Index(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TownId = c.Int(),
                        PrimaryKitColorId = c.Int(),
                        SecondaryKitColorId = c.Int(),
                        Name = c.String(),
                        Logo = c.String(),
                        Initials = c.String(maxLength: 3),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Colors", t => t.PrimaryKitColorId)
                .ForeignKey("dbo.Colors", t => t.SecondaryKitColorId)
                .ForeignKey("dbo.Towns", t => t.TownId)
                .Index(t => t.TownId)
                .Index(t => t.PrimaryKitColorId)
                .Index(t => t.SecondaryKitColorId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(),
                        PositionId = c.String(nullable: false, maxLength: 2),
                        Name = c.String(),
                        SquadNumber = c.Int(nullable: false),
                        IsCurrentlyInjured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.PlayerStatistics",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        ScoredGoals = c.Int(nullable: false),
                        PlayerAssists = c.String(),
                        PlayedMinutesDuringGame = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameId, t.PlayerId })
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionID = c.String(nullable: false, maxLength: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PositionID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        TownId = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TownId)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Continents",
                c => new
                    {
                        ContinentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ContinentId);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type_CompetitionTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.CompetitionId)
                .ForeignKey("dbo.CompetitionTypes", t => t.Type_CompetitionTypeId)
                .Index(t => t.Type_CompetitionTypeId);
            
            CreateTable(
                "dbo.CompetitionTypes",
                c => new
                    {
                        CompetitionTypeId = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompetitionTypeId);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        RoundId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoundId);
            
            CreateTable(
                "dbo.ResultPredictions",
                c => new
                    {
                        PredictionId = c.Int(nullable: false, identity: true),
                        Prediction = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PredictionId);
            
            CreateTable(
                "dbo.ContinentCountries",
                c => new
                    {
                        Continent_ContinentId = c.Int(nullable: false),
                        Country_CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Continent_ContinentId, t.Country_CountryId })
                .ForeignKey("dbo.Continents", t => t.Continent_ContinentId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId, cascadeDelete: true)
                .Index(t => t.Continent_ContinentId)
                .Index(t => t.Country_CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BetGames", "ResultPredictionId", "dbo.ResultPredictions");
            DropForeignKey("dbo.Games", "RoundId", "dbo.Rounds");
            DropForeignKey("dbo.Games", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Competitions", "Type_CompetitionTypeId", "dbo.CompetitionTypes");
            DropForeignKey("dbo.BetGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "TownId", "dbo.Towns");
            DropForeignKey("dbo.Towns", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ContinentCountries", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.ContinentCountries", "Continent_ContinentId", "dbo.Continents");
            DropForeignKey("dbo.Teams", "SecondaryKitColorId", "dbo.Colors");
            DropForeignKey("dbo.Teams", "PrimaryKitColorId", "dbo.Colors");
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Players", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.PlayerStatistics", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.PlayerStatistics", "GameId", "dbo.Games");
            DropForeignKey("dbo.BetGames", "BetId", "dbo.Bets");
            DropForeignKey("dbo.Bets", "UserId", "dbo.Users");
            DropIndex("dbo.ContinentCountries", new[] { "Country_CountryId" });
            DropIndex("dbo.ContinentCountries", new[] { "Continent_ContinentId" });
            DropIndex("dbo.Competitions", new[] { "Type_CompetitionTypeId" });
            DropIndex("dbo.Towns", new[] { "CountryId" });
            DropIndex("dbo.PlayerStatistics", new[] { "PlayerId" });
            DropIndex("dbo.PlayerStatistics", new[] { "GameId" });
            DropIndex("dbo.Players", new[] { "PositionId" });
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "SecondaryKitColorId" });
            DropIndex("dbo.Teams", new[] { "PrimaryKitColorId" });
            DropIndex("dbo.Teams", new[] { "TownId" });
            DropIndex("dbo.Games", new[] { "CompetitionId" });
            DropIndex("dbo.Games", new[] { "RoundId" });
            DropIndex("dbo.Games", new[] { "AwayTeamId" });
            DropIndex("dbo.Games", new[] { "HomeTeamId" });
            DropIndex("dbo.Bets", new[] { "UserId" });
            DropIndex("dbo.BetGames", new[] { "ResultPredictionId" });
            DropIndex("dbo.BetGames", new[] { "BetId" });
            DropIndex("dbo.BetGames", new[] { "GameId" });
            DropTable("dbo.ContinentCountries");
            DropTable("dbo.ResultPredictions");
            DropTable("dbo.Rounds");
            DropTable("dbo.CompetitionTypes");
            DropTable("dbo.Competitions");
            DropTable("dbo.Continents");
            DropTable("dbo.Countries");
            DropTable("dbo.Towns");
            DropTable("dbo.Colors");
            DropTable("dbo.Positions");
            DropTable("dbo.PlayerStatistics");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Games");
            DropTable("dbo.Users");
            DropTable("dbo.Bets");
            DropTable("dbo.BetGames");
        }
    }
}
