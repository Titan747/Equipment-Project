using EquipmentAPI.Models;
using EquipmentAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentAPI.Controllers
{
	[Route("api/equipment")]
	[ApiController]
	public class EquipmentController : ControllerBase
	{
		private readonly IDataRepository<Equipment> _dataRepository;
        public EquipmentController(IDataRepository<Equipment> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Equipment
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Equipment> equipments = _dataRepository.GetAll();
            return Ok(equipments);
        }
        // GET: api/Equipment/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Equipment equipment = _dataRepository.Get(id);
            if (equipment == null)
            {
                return NotFound("The Equipment record couldn't be found.");
            }
            return Ok(equipment);
        }
        // POST: api/Equipment
        [HttpPost]
        public IActionResult Post([FromBody] Equipment equipment)
        {
            if (equipment == null)
            {
                return BadRequest("Equipment is null.");
            }
            _dataRepository.Add(equipment);
            return CreatedAtRoute(
                  "Get", 
                  new { Id = equipment.EquipmentId },
                  equipment);
        }
        // PUT: api/Equipment/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Equipment equipment)
        {
            if (equipment == null)
            {
                return BadRequest("Equipment is null.");
            }
            Equipment equipmentToUpdate = _dataRepository.Get(id);
            if (equipmentToUpdate == null)
            {
                return NotFound("The Equipment record couldn't be found.");
            }
            _dataRepository.Update(equipmentToUpdate, equipment);
            return NoContent();
        }
        // DELETE: api/Equipment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Equipment equipment = _dataRepository.Get(id);
            if (equipment == null)
            {
                return NotFound("The Equipment record couldn't be found.");
            }
            _dataRepository.Delete(equipment);
            return NoContent();
        }
	}
}
