using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using T9.Classes;

namespace T9.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IKeypad, T9Keypad>();
            services.AddSingleton(File.OpenText("./Input/C-large-practice.in"));
            services.AddSingleton(File.AppendText("./Output/C-large-practice.out"));
            services.AddTransient<FileParser>();
            services.AddTransient<IMessageTranslator, T9MessageTranslator>();

            var serviceProvider = services.BuildServiceProvider();

            var parser = serviceProvider.GetService<FileParser>();
            parser.Start();
        }
    }
}