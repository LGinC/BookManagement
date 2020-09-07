using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace BookManagement
{
    public class BookManagementWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<BookManagementWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}