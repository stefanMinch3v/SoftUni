namespace SystemSplit.Interfaces
{
    public interface IDatabase
    {
        void AddHardware(Hardware h);

        void Destroy(string hardwareName);

        void PrintAnalyzeCommand();

        void PrintSystemSplitCommand();

        void Dump(string hardwareName);

        void Restore(string hardwareName);

        void PrintDumpAnalyzeCommand();
    }
}
