namespace CarDealer.Services
{
    using Data.Models;
    using Models;
    using System;
    using System.Collections.Generic;

    public interface ILoggerService
    {
        void Create(string username, OperationCode operation, string table, DateTime time);

        void DeleteAll();

        IEnumerable<LoggerModel> All();

        int Total();
    }
}
