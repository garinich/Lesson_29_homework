using System;
using System.Linq;
using ComputersDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Office
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var dbOptions = new DbContextOptionsBuilder<ComputersContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .Options;

            using (var ctx = new ComputersContext(dbOptions))
            {
                var newComp = new Computer {Name = "My New Comp"};

                newComp.Monitors.Add(new Monitor{Name = "New Monitor", Diagonal = 29});
                newComp.Printers.Add(new Printer{Name = "New Printer", Year = 2009});

                ctx.Computers.Add(newComp);

                ctx.SaveChanges();

                var comps = ctx.Computers
                    .Include(comp => comp.Monitors)
                    .Include(comp => comp.Printers)
                    .ToList();

                foreach (var comp in comps)
                {
                    Console.WriteLine($"Computer Name: {comp.Name}, Id: {comp.Id}");

                    foreach (var printer in comp.Printers)
                    {
                        Console.WriteLine($"--- Printer Name: {printer.Name}, Year: {printer.Year}");
                    }

                    foreach (var monitor in comp.Monitors)
                    {
                        Console.WriteLine($"--- Monitor Name: {monitor.Name}, Diagonal: {monitor.Diagonal}");
                    }
                }
            }
        }
    }
}
