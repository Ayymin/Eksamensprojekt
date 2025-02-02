﻿using DAL.Context;
using DAL.Mappers;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respositories
{
    public class FerryRepository
    {
        public static Ferry GetFerry(int id)
        {
            using (FerryContext context = new FerryContext())
            {
                Eksamensprojekt.Model.Ferry ferry = context.Ferries.Find(id);
                return FerryMapper.Map(context.Ferries.Find(id));
            }
        }

        public static void AddFerries(Ferry ferry)
        {
            using (FerryContext context = new FerryContext())
            {

                context.Ferries.Add(FerryMapper.Map(ferry));
                context.SaveChanges();
            }
        }


        public static List<Ferry> GetAllFerries()
        {
            using (FerryContext context = new FerryContext())
            {
                return context.Ferries.Select(FerryMapper.Map).ToList();
            }
        }

        public static Ferry UpdateFerry(Ferry ferry)
        {
            using (FerryContext context = new FerryContext())
            {
                var existingFerry = context.Ferries.Find(ferry.Id);
                if (existingFerry != null)
                {
                    existingFerry.AmountofPassengers = ferry.AmountofPassengers;
                    existingFerry.AmountofCars = ferry.AmountofCars;
                    context.SaveChanges();
                    return FerryMapper.Map(existingFerry); 
                }
                return null; 
            }
        }

        public static void UpdateFerryObject(Ferry ferry)
        {
            using (FerryContext context = new FerryContext())
            {
                var existingFerry = context.Ferries.Find(ferry.Id);

                existingFerry.FerryName = ferry.FerryName;
                existingFerry.GuestPrice = ferry.GuestPrice;
                existingFerry.CarPrice = ferry.CarPrice;

                context.SaveChanges();
            }
        }




    }
}
