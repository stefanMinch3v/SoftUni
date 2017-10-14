namespace PhotoShare.Client.Core
{
    using PhotoShare.Client.Core.Attributes;
    using PhotoShare.Client.Core.Commands;
    using PhotoShare.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandDispatcher
    {
        private readonly UserService userService;
        private readonly TownService townService;
        private readonly TagService tagService;
        private readonly PictureService pictureService;
        private readonly AlbumService albumService;
        private readonly SecurityService securityService;

        private Dictionary<string, Command> commands;

        public CommandDispatcher()
        {
            this.userService = new UserService();
            this.townService = new TownService();
            this.tagService = new TagService();
            this.pictureService = new PictureService();
            this.albumService = new AlbumService();
            this.securityService = SecurityService.Instance;
            Initialize();
        }

        public Command DispatchCommand(string[] commandParameters)
        {
            // it can be done as store in dictionary or better with reflection

            string commandType = commandParameters[0];
            string[] commandParams = commandParameters.Skip(1).ToArray();

            if (this.commands.ContainsKey(commandType))
            {
                this.commands[commandType].InsertData(commandParams);
            }
            else
            {
                throw new InvalidOperationException($"Command {commandParameters[0]} not valid!");
            }

            return this.commands[commandType];
        }

        private void Initialize()
        {
            this.commands = new Dictionary<string, Command>()
            {
                { "RegisterUser", new RegisterUserCommand(this.userService)},
                { "AddTown", new AddTownCommand(this.townService)},
                { "ModifyUser", new ModifyUserCommand(this.userService, this.townService)},
                { "DeleteUser", new DeleteUser(this.userService)},
                { "AddTag", new AddTagCommand(this.tagService)},
                { "CreateAlbum", new CreateAlbumCommand(this.albumService, this.userService, this.tagService)},
                { "AddTagTo", new AddTagToCommand(this.tagService, this.albumService)},
                { "MakeFriends", new MakeFriendsCommand(this.userService)},
                { "ListFriends", new PrintFriendsListCommand(this.userService)},
                { "ShareAlbum", new ShareAlbumCommand(this.albumService, this.userService)},
                { "UploadPicture", new UploadPictureCommand(this.pictureService, this.albumService)},
                { "Exit", new ExitCommand()},
                { "Login", new LoginInCommand(this.securityService)},
                { "Logout", new LogOutCommand(this.securityService)}
            };


            //reflection will work if all the constructors are empty
            //var types = Assembly.GetExecutingAssembly().GetTypes()
            //                     .Where(t => t.CustomAttributes.Any(attr => attr.AttributeType == typeof(CommandAttribute)));
            //foreach (var type in types)
            //{
            //    var attr = type.GetCustomAttributes(true).First() as CommandAttribute;
            //    string keyWord = attr.GetCommandString;

            //    this.commands.Add(keyWord, (Command)Activator.CreateInstance(type));
            //}
        }
    }
}
