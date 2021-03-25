using System.Collections.Generic;
using System.Linq;
using EquipmentAPI.Models.Repository;
using System;
using System.Threading.Tasks;

namespace EquipmentAPI.Models.DataManager
{
	public class EquipmentManager : IDataRepository<Equipment>
	{
        readonly EquipmentContext _equipmentContext;
        public EquipmentManager(EquipmentContext context)
        {
            _equipmentContext = context;
        }
        public IEnumerable<Equipment> GetAll()
        {
            return _equipmentContext.Equipments.ToList();
        }
        public Equipment Get(long id)
        {
            return _equipmentContext.Equipments
                  .FirstOrDefault(e => e.EquipmentId == id);
        }
        public void Add(Equipment entity)
        {
            _equipmentContext.Equipments.Add(entity);
            _equipmentContext.SaveChanges();
        }
        public void Update(Equipment equipment, Equipment entity)
        {
            equipment.EquipmentId = entity.EquipmentId;
            equipment.EquipmentName = entity.EquipmentName;
            equipment.EquipmentAmount = entity.EquipmentAmount;
            equipment.EquipmentPurchaseDate = entity.EquipmentPurchaseDate;
            _equipmentContext.SaveChanges();
        }
        public void Delete(Equipment equipment)
        {
            _equipmentContext.Equipments.Remove(equipment);
            _equipmentContext.SaveChanges();
        }
    }
}
