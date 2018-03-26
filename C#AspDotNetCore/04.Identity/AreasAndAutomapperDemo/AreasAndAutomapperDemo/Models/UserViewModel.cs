using AreasAndAutomapperDemo.Infrastructure.Mapping;
using AutoMapper;

namespace AreasAndAutomapperDemo.Models
{
    public class UserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string MailAddress { get; set; }

        public void ConfigureMapping(Profile profile)
            => profile
                .CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(u => u.MailAddress, cfg => cfg.MapFrom(u => u.Email));
    }
}
