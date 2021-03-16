using CsvAnalyser.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CsvAnalyser.Application
{
    class Program
    {
        private static ServiceProvider _serviceProvider;


        static void Main(string[] args)
        {
            SetupApp();

            _serviceProvider.GetService<IApp>()?.Run();
        }

        private static void SetupApp()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IApp, App>();
            serviceCollection.AddCsvAnalyser();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
