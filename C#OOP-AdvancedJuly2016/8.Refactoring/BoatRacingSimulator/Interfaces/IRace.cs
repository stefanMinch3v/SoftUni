namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;
    using BoatRacingSimulator.Models;

    public interface IRace
    {
        int Distance { get; }

        int WindSpeed { get; }

        int OceanCurrentSpeed { get; }

        bool AllowsIBoats { get; }

        void AddParticipant(IBoat boat);

        IList<IBoat> GetParticipants();
    }
}
