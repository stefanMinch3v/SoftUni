namespace PhotoShare.Client.Core
{
    using PhotoShare.Client.Core.Commands;
    using System;
    using System.Collections.Generic;

    public class CommandDispatcher
    {
        private Dictionary<string, Command> commands;

        public CommandDispatcher()
        {
            InitializeCommands();
        }

        public Command DispatchCommand(string[] commandParameters)
        {
            if (this.commands.ContainsKey(commandParameters[0]))
            {
                return this.commands[commandParameters[0]];
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }
        }

        private void InitializeCommands()
        {
            this.commands = new Dictionary<string, Command>
            {
                {"RegisterUser", new RegisterUserCommand(null)},
                {"AddTown", new AddTownCommand(null)},
                {"ModifyUser", new ModifyUserCommand(null)},
                {"DeleteUser", new DeleteUser(null)},
                {"AddTag", new AddTagCommand(null)},
                {"CreateAlbum", new CreateAlbumCommand(null)},
                {"AddTagTo", new AddTagToCommand(null)},
                {"MakeFriends", new MakeFriendsCommand(null)},
                {"ListFriends", new PrintFriendsListCommand(null)},
                {"ShareAlbum", new ShareAlbumCommand(null)},
                {"UploadPicture", new UploadPictureCommand(null)},
                {"Exit", new ExitCommand(null)},
            };

        }
    }
}
