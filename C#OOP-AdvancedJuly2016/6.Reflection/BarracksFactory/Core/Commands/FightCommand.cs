﻿namespace BarracksFactory.Core.Commands
{
    using Contracts;
    using System;

    public class FightCommand : Command
    {
        public FightCommand(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }
}
