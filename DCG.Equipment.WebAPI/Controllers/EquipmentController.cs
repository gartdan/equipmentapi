using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCG.Equipment.WebAPI.Controllers
{
    [ApiController]
    public class EquipmentController : ControllerBase
    {

        private EquipmentService _equipmentService = new EquipmentService();

        [HttpGet("equipment/hello")]
        public string Hello()
        {
            return "Hello";
        }

        [HttpPost("equipment/bytype")]
        public IList<Equipment> GetEquipmentByType(string equipmentType)
        {
            return _equipmentService.GetEquipmentByType(equipmentType);
        }

        [HttpPost("equiment/details")]
        public Equipment GetEquipmentDetails(string modelNumber)
        {
            return _equipmentService.GetByModelNumber(modelNumber);
        }

        [HttpPost("equipment/similar")]
        public Equipment GetSimilarMachine(string modelNumber)
        {
            return _equipmentService.GetRandomEquipment();
        }
    }
}