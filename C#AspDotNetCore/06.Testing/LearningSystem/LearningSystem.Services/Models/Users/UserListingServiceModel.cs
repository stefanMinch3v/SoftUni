namespace LearningSystem.Services.Models.Users
{
    using Common.Mapping;
    using Data.Models;
    using System;
    using AutoMapper;

    public class UserListingServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Username { get; set; }

        public string Name { get; set; }

        public int NumOfCourses { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<User, UserListingServiceModel>()
                .ForMember(u => u.NumOfCourses, cfg => cfg.MapFrom(u => u.Courses.Count));
    }
}
