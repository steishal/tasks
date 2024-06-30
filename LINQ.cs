using Internal;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Task1");
        var clients1 = new[]
        {
            new { ClientCode = 1, Year = 2022, MonthNumber = 3, Duration = 2 },
            new { ClientCode = 2, Year = 2022, MonthNumber = 4, Duration = 1 },
            new { ClientCode = 3, Year = 2022, MonthNumber = 5, Duration = 1 },
            new { ClientCode = 4, Year = 2022, MonthNumber = 6, Duration = 3 },
            new { ClientCode = 5, Year = 2022, MonthNumber = 7, Duration = 1 }
        };

        var minDurationClient1 = clients1.OrderBy(c => c.ClientCode).Last(c => c.Duration == clients1.Min(cc => cc.Duration));
        Console.WriteLine($"{minDurationClient1.Duration} {minDurationClient1.Year} {minDurationClient1.MonthNumber}");
        Console.WriteLine();


        int P = 20;
        Console.WriteLine("Task12");
        var clients12 = new[]
        {
            new { Duration = 3, ClientCode = 1, MonthNumber = 3, Year = 2021 },
            new { Duration = 2, ClientCode = 2, MonthNumber = 4, Year = 2021 },
            new { Duration = 4, ClientCode = 3, MonthNumber = 5, Year = 2021 },
            new { Duration = 5, ClientCode = 1, MonthNumber = 6, Year = 2022 },
            new { Duration = 2, ClientCode = 2, MonthNumber = 7, Year = 2022 },
            new { Duration = 3, ClientCode = 3, MonthNumber = 8, Year = 2022 },
            new { Duration = 4, ClientCode = 3, MonthNumber = 9, Year = 2021 },
            new { Duration = 5, ClientCode = 1, MonthNumber = 10, Year = 2022 },
            new { Duration = 2, ClientCode = 2, MonthNumber = 7, Year = 2022 },
            new { Duration = 3, ClientCode = 3, MonthNumber = 3, Year = 2022 }
        };

        var result = clients12.GroupBy(c => c.Year)
                            .Select(group => new
                            {
                                Year = group.Key,
                                MonthsCount = group.GroupBy(g => g.MonthNumber)
                                                   .Count(monthGroup => monthGroup.Sum(m => m.Duration) > (P / 100.0) * group.Sum(y => y.Duration))
                            })
                            .OrderByDescending(r => r.MonthsCount)
                            .ThenBy(r => r.Year);

        foreach (var item in result)
        {
            Console.WriteLine($"{item.MonthsCount} {item.Year}");

        }
        Console.WriteLine();
        Console.WriteLine("Task23");

        var applicants23 = new[]
        {
            new { LastName = "Ivanov", AdmissionYear = 2021, SchoolNumber = 1 },
            new { LastName = "Petrov", AdmissionYear = 2021, SchoolNumber = 2 },
            new { LastName = "Sidorov", AdmissionYear = 2020, SchoolNumber = 1 },
            new { LastName = "Alekseev", AdmissionYear = 2021, SchoolNumber = 1 },
            new { LastName = "Smirnov", AdmissionYear = 2020, SchoolNumber = 2 },
            new { LastName = "Zaharov", AdmissionYear = 2020, SchoolNumber = 1 },
            new { LastName = "Ivashenko", AdmissionYear = 2021, SchoolNumber = 1 },
            new { LastName = "Nikolaev", AdmissionYear = 2021, SchoolNumber = 2 }
        };
        var result23 = applicants23.GroupBy(a => new { a.AdmissionYear, a.SchoolNumber })
                               .Select(group => new
                               {
                                   AdmissionYear = group.Key.AdmissionYear,
                                   SchoolNumber = group.Key.SchoolNumber,
                                   ApplicantsCount = group.Count()
                               })
                               .OrderByDescending(r => r.AdmissionYear) 
                               .ThenBy(r => r.SchoolNumber); 

        foreach (var item in result23)
        {
            Console.WriteLine($"Year:{item.AdmissionYear} School:{item.SchoolNumber} Count:{item.ApplicantsCount}");

        }
        Console.WriteLine();
        Console.WriteLine("Task34");

        List<(double, int, string)> debtors = new List<(double, int, string)>
        {
            (100.50, 101, "Smith"),
            (50.75, 102, "Johnson"),
            (0, 103, "Williams"),
            (75.25, 104, "Jones"),
            (120.10, 201, "Brown"),
            (0, 202, "Davis"),
            (90.30, 203, "Miller"),
            (60.80, 204, "Wilson"),
            (130.90, 301, "Moore"),
            (40.60, 302, "Taylor"),
            (85.40, 303, "Anderson"),
            (0, 304, "Thomas"),
            (110.20, 401, "Jackson"),
            (70.45, 402, "Harris"),
            (0, 403, "Martin"),
            (55.75, 404, "Thompson")
        };

        var averageDebt = debtors.Where(d => d.Item1 > 0).Average(d => d.Item1); 

        var result34 = debtors.Where(d => d.Item1 <= averageDebt)
                            .OrderByDescending(d => d.Item2 / 100) 
                            .ThenBy(d => d.Item2 % 100); 

        foreach (var debtor in result34)
        {
            Console.WriteLine($"{debtor.Item2 / 100}-й этаж, квартира {debtor.Item2 % 100}, {debtor.Item3}, задолженность {debtor.Item1:F2}");
        }
        Console.WriteLine();
        Console.WriteLine("Task45");

        List<(string, int, int, string)> gasStations = new List<(string, int, int, string)>
        {
            ("Gazprom", 450, 95, "Lenin"),
            ("Lukoil", 480, 92, "Lenin"),
            ("TNK", 500, 98, "Gagarin"),
            ("Rosneft", 460, 95, "Pushkin"),
            ("Gazprom", 470, 98, "Gorky"),
            ("Lukoil", 490, 95, "Gagarin"),
            ("Rosneft", 455, 92, "Lenin"),
            ("TNK", 510, 98, "Pushkin"),
            ("Gazprom", 480, 92, "Gorky")
        };

        var result45 = gasStations.GroupBy(g => g.Item4)
                                 .Select(g => new { Street = g.Key, Count = g.Count() })
                                 .OrderBy(g => g.Street);

        foreach (var gasStation in result45)
        {
            Console.WriteLine($"{gasStation.Street}: {gasStation.Count} АЗС");


        }
        Console.WriteLine();
        Console.WriteLine("Task56");
    }
}

List<(string, string, string, int)> students = new List<(string, string, string, int)>
        {
            ("Smith", "J.D.", "95 85 75", 101),
            ("Johnson", "A.K.", "80 92 98", 102),
            ("Williams", "R.L.", "70 88 95", 103),
            ("Jones", "P.A.", "85 90 82", 104),
            ("Brown", "C.D.", "92 79 88", 101),
            ("Davis", "E.S.", "78 85 92", 102),
            ("Miller", "T.R.", "97 85 79", 103),
            ("Anderson", "G.F.", "88 92 84", 104),
            ("Moore", "S.N.", "94 86 88", 101),
            ("Taylor", "L.M.", "80 94 96", 102),
            ("Anderson", "G.F.", "91 85 94", 103),
            ("Thomas", "I.O.", "80 80 81", 104)
        };

var result = students.Where(s => s.Item3.Split().Any(score => int.Parse(score) > 90))
                      .OrderBy(s => s.Item1)
                      .ThenBy(s => s.Item2)
                      .ThenBy(s => s.Item4);

if (result.Any())
{
    foreach (var student in result)
    {
        Console.WriteLine($"{student.Item1} {student.Item2} {student.Item4}");
    }
}
else
{
    Console.WriteLine("Требуемые учащиеся не найдены");
}

Console.WriteLine();
Console.WriteLine("Task67");

List<(int, string, string, string, int)> grades = new List<(int, string, string, string, int)>
        {
            (10, "Алгебра", "Smith", "J.D.", 2),
            (10, "Геометрия", "Smith", "J.D.", 4),
            (10, "Информатика", "Smith", "J.D.", 5),
            (11, "Алгебра", "Johnson", "A.K.", 5),
            (11, "Геометрия", "Johnson", "A.K.", 3),
            (11, "Информатика", "Johnson", "A.K.", 4),
            (10, "Алгебра", "Brown", "C.D.", 4),
            (10, "Геометрия", "Brown", "C.D.", 2),
            (10, "Информатика", "Brown", "C.D.", 2),
            (11, "Алгебра", "Davis", "E.S.", 5),
            (11, "Геометрия", "Davis", "E.S.", 5),
            (11, "Информатика", "Davis", "E.S.", 5)
        };

var result67 = grades.GroupBy(g => g.Item3 + g.Item4)
                    .Where(g => g.Any(x => x.Item5 == 2))
                    .OrderByDescending(g => g.First().Item1)
                    .ThenBy(g => g.First().Item3)
                    .ThenBy(g => g.First().Item4)
                    .Select(g => new
                    {
                        Class = g.First().Item1,
                        LastName = g.First().Item3,
                        Initials = g.First().Item4,
                        NumberOfTwos = g.Count(x => x.Item5 == 2)
                    });

if (result67.Any())
{
    foreach (var student in result67)
    {
        Console.WriteLine($"{student.Class} {student.LastName} {student.Initials}, {student.NumberOfTwos}");
    }
}
else
{
    Console.WriteLine("Требуемые учащиеся не найдены");
}

