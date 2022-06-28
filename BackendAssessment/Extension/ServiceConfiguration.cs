using CustomerOnboarder.Core.Implementation.Services;
using CustomerOnboarder.Core.Services.Implementation;
using CustomerOnboarder.Core.Services.Interface;
using CustomerOnboarder.Core.Utility;
using CustomerOnboarder.Infrastructure.Repositories.Implementation;
using CustomerOnboarder.Infrastructure.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerOnboarder.Extension
{
    public static class ServiceConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IAuthenticationServices, AuthenticationServices>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IConfirmStateLGA, ConfirmStateLGA>();
            service.AddScoped<IGetBankServices, GetBankServices>();
        }
    }
}
