using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Session4.LinQSample.Models;

namespace Session4.LinQSample.Logic
{
    public class Engine
    {
        public List<Foo> Foos { get; set; }
        public List<Bar> Bars { get; set; }
        public Engine()
        {
            Foos = new List<Foo>()
            {
                new Foo
                {
                    ID=1,
                    Ch='a',
                    Data=1.2,
                    Name="A",
                    Time=DateTime.Now,
                    City="tehran"
                },
                 new Foo
                {
                    ID=2,
                    Ch='b',
                    Data=1.3,
                    Name="B",
                    Time=DateTime.Now.AddDays(-1),
                    City="tehran"
                },
                  new Foo
                {
                    ID=3,
                    Ch='a',
                    Data=1.2,
                    Name="C",
                    Time=DateTime.Now.AddDays(1),
                    City="NYC"
                },
                   new Foo
                {
                    ID=1,
                    Ch='a',
                    Data=1.2,
                    Name="A",
                    Time=DateTime.Now,
                    City="tehran"
                },
                    new Foo
                {
                    ID=4,
                    Ch='e',
                    Data=1.2,
                    Name="A",
                    Time=DateTime.Now,
                    City="LA"
                },
                     new Foo
                {
                    ID=5,
                    Ch='a',
                    Data=1.2,
                    Name="A",
                    Time=DateTime.Now,
                    City="Sanfrancisco"
                },
            };

            Bars = new List<Bar>()
            {
                new Bar
                {
                    ID=1,
                     Age=10,
                     City="tehran",
                     Flag=true
                },
                                new Bar
                {
                    ID=2,
                     Age=11,
                     City="Isfahan",
                     Flag=true
                },
                                                new Bar
                {
                    ID=1,
                     Age=15,
                     City="NYC",
                     Flag=true
                },
                                                                new Bar
                {
                    ID=1,
                     Age=30,
                     City="LA",
                     Flag=true

                },
                                                                                new Bar
                {
                    ID=1,
                     Age=40,
                     City="London",
                     Flag=true
                },
            };
        }

        public void Sample1()
        {
            var q = Foos
                .Where(x => x.Name == "A")
                .Select(x => new
                {
                    x.Name,
                    x.Ch,
                    x.ID,
                })
                .OrderBy(x => x.Ch)
                .ThenBy(x => x.Name);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(q,Newtonsoft.Json.Formatting.Indented));

        }
        public void Sample2()
        {
            var q2 = Bars
                .Skip(1)
                .Take(3)
                .Average(x => x.Age);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(q2, Newtonsoft.Json.Formatting.Indented));
        }
        public void Sample3()
        {
            var q3 = Foos.Join(Bars,
                Foo => Foo.City,
                Bar => Bar.City,
                (foo, bar) => new
                {
                    FooID = foo.ID,
                    foo.Name,
                    BarID = bar.ID,
                    bar.Age,
                    bar.City
                });
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(q3, Newtonsoft.Json.Formatting.Indented));
        }
        public void Sample4()
        {
            var q4 = Foos.GroupBy(x => x.City)
                        .OrderBy(G => G.Key);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(q4, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
