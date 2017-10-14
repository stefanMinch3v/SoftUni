 namespace BookLy.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using AutoMapper;

    using BookLy.Models;
    using BookLy.ViewModels.Account;
    using BookLy.ViewModels.Article;
    using BookLy.ViewModels.Book;
    using BookLy.ViewModels.Comment;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterMapping();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void RegisterMapping()
        {
            Mapper.Initialize(
                cfg =>
                    {
                        cfg.CreateMap<RegisterViewModel, ApplicationUser>();
                        cfg.CreateMap<BookCreateViewModel, Book>();
                        cfg.CreateMap<CommentCreateViewModel, Comment>();
                        cfg.CreateMap<ApplicationUser, AccountDetailsViewModel>();
                    });

        }
    }
}
