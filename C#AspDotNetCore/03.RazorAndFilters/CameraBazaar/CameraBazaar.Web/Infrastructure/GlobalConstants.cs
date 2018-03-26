namespace CameraBazaar.Web.Infrastructure
{
    public class GlobalConstants
    {
        public const string AdministratorRole = "Administrator";
        public const string RegisteredRole = "Registered";
        public const string AdminOrUser = AdministratorRole + "," + RegisteredRole;
        public const string RestrictedRole = "RestrictedToAddCameras";
    }
}
