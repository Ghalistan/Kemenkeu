using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kemenkeu.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KemenkeuContext(
                serviceProvider.GetRequiredService<DbContextOptions<KemenkeuContext>>()
                ))
            {
                // Look for data
                if (context.Pjpk.Any())
                {
                    return; // Db has been seeded
                }

                context.Pjpk.AddRange(
                    new Pjpk
                    {
                        Id = 0,
                        Judul = "Pengertian PJPK",
                        Detail = "Detail dari pengertian PJPK",
                        Foto =
                        @"[{'JSON':'String','Untuk':'Kebaikan bersama','Dan':'Nyimpan foto'}]",
                        TanggalDitambahkan = DateTime.Now,
                        TanggalDiedit = DateTime.Now
                    },

                    new Pjpk
                    {
                        Id = 1,
                        Judul = "Kerjasama Pemerintah dengan Badan Usaha (KPBU)",
                        Detail = "Detail KPBU",
                        Foto =
                        @"[{'JSON':'String','Untuk':'Kebaikan bersama','Dan':'Nyimpan foto'}]",
                        TanggalDitambahkan = DateTime.Now,
                        TanggalDiedit = DateTime.Now
                    });
                context.SaveChanges();
            }
        }
    }
}
