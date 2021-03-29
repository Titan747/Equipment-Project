using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentApp.Models
{
	public class Equipment
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long EquipmentId { get; set; }
        [Required]
        public string EquipmentName { get; set; }
        [DataType(DataType.Currency)]
        public int EquipmentAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime EquipmentPurchaseDate { get; set; }
    }
}
