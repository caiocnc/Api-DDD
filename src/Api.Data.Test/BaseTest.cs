using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }
        public DbTeste()
        {
            ServiceCollection serviceCollection = new();
            var _connectionString = $"Persist Security Info=True;Server=localhost;Database={dataBaseName};User=root;Password=mudar@123";
            serviceCollection.AddDbContext<MyContext>(o =>
                o.UseMySql(_connectionString,ServerVersion.AutoDetect(_connectionString)),
                    ServiceLifetime.Transient
                    );
            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
    }

}
