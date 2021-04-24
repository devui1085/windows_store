using System;
using System.Collections.Generic;

namespace Store.Portal.Models
{
    public static class Demo
    {
        public static IEnumerable<StoreApp> RecomendedApps
        {
            get
            {
                var apps = new List<StoreApp>();
                for (int i = 0; i < 12; i++)
                {
                    apps.Add(new StoreApp()
                    {
                        Guid = Guid.NewGuid(),
                        Name = "برنامه آزمایشی " + i.ToString(),
                        Price = 0,
                        Version = "1.0.0"
                    });
                }

                return apps;
            }
        }

        public static IEnumerable<StoreApp> SpecialApps
        {
            get
            {
                var apps = new List<StoreApp>();
                for (int i = 0; i < 8; i++)
                {
                    apps.Add(new StoreApp()
                    {
                        Guid = Guid.NewGuid(),
                        Name = "برنامه ویژه " + i.ToString(),
                        Price = 0,
                        Version = "1.0.0"
                    });
                }

                return apps;
            }
        }
        public static IEnumerable<StoreApp> NewApps
        {
            get
            {
                var apps = new List<StoreApp>();
                for (int i = 0; i < 8; i++)
                {
                    apps.Add(new StoreApp()
                    {
                        Guid = Guid.NewGuid(),
                        Name = "برنامه جدید " + i.ToString(),
                        Price = 0,
                        Version = "1.0.0"
                    });
                }

                return apps;
            }
        }
    }
}