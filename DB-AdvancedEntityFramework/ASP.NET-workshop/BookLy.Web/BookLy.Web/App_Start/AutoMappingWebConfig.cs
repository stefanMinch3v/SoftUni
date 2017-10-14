namespace BookLy.Web.App_Start
{
    using AutoMapper;
    using BookLy.Models;
    using BookLy.Web.ViewModels.Account;
    using System.IO;
    using System.Web;

    public static class AutoMappingWebConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, ApplicationUser>()
                         .ForMember(dest => dest.UserName, mo => mo.MapFrom(src => src.Username))
                         .ForMember(dest => dest.ProfilePicture, mo => mo.MapFrom(src => GetBytesFromFile(src.Image)));
                cfg.CreateMap<ApplicationUser, AccountDetailsViewModel>();
            });
        }

        private static byte[] GetBytesFromFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return new byte[0];
            }

            MemoryStream stream = new MemoryStream();
            file.InputStream.CopyTo(stream);
            byte[] data = stream.ToArray();

            return data;
        }
    }
}