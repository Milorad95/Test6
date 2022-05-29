using Test6.Models;

namespace Test6.Data
{
    public class DbInitializer
    {
        public static void Initalize(DataContext context)
        {
            var created = context.Database.EnsureCreated();
            if (!created)
            {
                return;
            }
            var smerovi = new Smer[]
            {
                new Smer {  NazivSmera = "Informatika", Aktivan = true },
                new Smer {  NazivSmera = "Menadzment", Aktivan = true },
                new Smer {  NazivSmera = "Porezi i carine", Aktivan = true },
                new Smer {  NazivSmera = "Javna uprava", Aktivan = true },
            };
            context.AddRange(smerovi);
            context.SaveChanges();

            var studenti = new Student[]
            {
                    new Student {
                        Ime = "Jovan",
                        Prezime = "Jovanovic",
                        BrojIndeksa = "1i1/0001/15",
                        Smer = context.Smerovi.FirstOrDefault(s => s.SmerID == 1),
                        Aktivan = true
                    },
                    new Student {
                        Ime = "Milan",
                        Prezime = "Milovanovic",
                        BrojIndeksa = "1i1/0015/18",
                        Smer = context.Smerovi.FirstOrDefault(s => s.SmerID ==3),
                        Aktivan = true
                    },
                    new Student {
                        Ime = "Sanja",
                        Prezime = "Nikolic",
                        BrojIndeksa = "1i1/0115/22",
                        Smer = context.Smerovi.FirstOrDefault(s => s.SmerID == 2),
                        Aktivan = true
                    },
                    new Student {
                        Ime = "Nikola",
                        Prezime = "Petrovic",
                        BrojIndeksa = "1i1/0081/14",
                        Smer = context.Smerovi.FirstOrDefault(s => s.SmerID == 1),
                        Aktivan = true
                    },
                    new Student {
                        Ime = "Pera",
                        Prezime = "Petrovic",
                        BrojIndeksa = "1i1/0105/20",
                        Smer = context.Smerovi.FirstOrDefault(s => s.SmerID == 4),
                        Aktivan = true
                    },
            };
            context.AddRange(studenti);
            context.SaveChanges();
        }
    }
}
