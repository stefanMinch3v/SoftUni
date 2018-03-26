namespace CarDealer.Services.Implementations
{
    using Data;
    using Data.Models;
    using Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LoggerService : ILoggerService
    {
        private readonly CarDealerDbContext db;

        public LoggerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string username, OperationCode operation, string table, DateTime time)
        {
            var log = new Logger
            {
                Username = username,
                Operation = operation,
                ModifiedTable = table,
                Time = time
            };

            this.db.Logs.Add(log);
            this.db.SaveChanges();
        }

        public void DeleteAll()
        {
            var all = this.db.Logs.AsQueryable();

            this.db.Logs.RemoveRange(all);
            this.db.SaveChanges();
        }

        public IEnumerable<LoggerModel> All()
            => this.db.Logs
                .OrderByDescending(l => l.Time)
                .Select(l => new LoggerModel
                {
                    Username = l.Username,
                    Operation = l.Operation.ToString(),
                    ModifiedTable = l.ModifiedTable,
                    DateAdded = l.Time
                })
                .ToList();

        public int Total() => this.db.Logs.Count();
    }
}
