using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentApp.Controllers
{
	public class EquipmentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AddEquipment()
		{
			return View();
		}
		public IActionResult UpdateEquipment()
		{
			return View();
		}
		public IActionResult DeleteEquipment()
		{
			return View();
		}
	}
}
