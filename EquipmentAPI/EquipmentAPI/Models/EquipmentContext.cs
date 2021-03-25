using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentAPI.Models
{
	public class EquipmentContext :DbContext
	{
            public EquipmentContext(DbContextOptions options)
                : base(options)
            {
            }
            public DbSet<Equipment> Equipments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().HasData(new Equipment
            {
                EquipmentId = 1,
                EquipmentName = "Titan",
                EquipmentAmount=77777,
                EquipmentPurchaseDate = new DateTime(1979, 04, 25),
            }, new Equipment
            {
                EquipmentId = 2,
                EquipmentName = "Tony",
                EquipmentAmount = 11111,
                EquipmentPurchaseDate = new DateTime(1981, 07, 13),
            });
        }
    }

}