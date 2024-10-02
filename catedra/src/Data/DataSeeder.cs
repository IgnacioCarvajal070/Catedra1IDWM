using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bogus;
using catedra.src.Models;


namespace catedra.src.Data
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDBContext>();
                int rutCounter = 100000000;
                if(!context.Users.Any())
                {
                    var userFaker = new Faker<User>()
                        .RuleFor(u => u.Rut, f => rutCounter++)
                        .RuleFor(u => u.Nombre, f => f.Name.FullName())
                        .RuleFor(u => u.Correo, f => f.Internet.Email())
                        .RuleFor(u => u.Genero, f => f.PickRandom("M", "F"))
                        .RuleFor(u => u.Fecha, f => f.Date.Past().ToString("yyyy-MM-dd"));

                    var users1 = userFaker.Generate(10);
                    context.Users.AddRange(users1);
                    context.SaveChanges();
                }
                context.SaveChanges();
            }
            }
    }
}