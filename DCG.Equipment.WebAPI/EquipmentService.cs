using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCG.Equipment.WebAPI
{
    public class EquipmentService
    {
        public IList<Equipment> equipment = new List<Equipment>()
        {
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="1023E", EngineHorsePower="23hp", Category="1 Series Tractor" },
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="1025R", EngineHorsePower="23hp", Category="1 Series Tractor" },
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="2025R", EngineHorsePower="24.2hp", Category="2 Series Tractor" },
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="2032R", EngineHorsePower="23hp", Category="2 Series Tractor" },
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="2038R", EngineHorsePower="36.7hp", Category="2 Series Tractor" },
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="3025D", EngineHorsePower="24.7hp", Category="3 Series Tractor" },
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="3046R", EngineHorsePower="43hp", Category="3 Series Tractor" },
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="4044M", EngineHorsePower="43.1hp", Category="4 Series Tractor" },
            new Equipment() { MachineType = "Compact Tractors", ModelNumber="4052M", EngineHorsePower="65.9hp", Category="4 Series Tractor" },
            new Equipment() { MachineType = "Row Crop Tractors", ModelNumber="6145M", EngineHorsePower="145hp", Category="6 Series Tractor" },
            new Equipment() { MachineType = "Row Crop Tractors", ModelNumber="6155M", EngineHorsePower="155hp", Category="6 Series Tractor" },
            new Equipment() { MachineType = "Row Crop Tractors", ModelNumber="6215R", EngineHorsePower="410hp", Category="6 Series Tractor" },
        };

        public IList<Equipment> Equipment
        {
            get
            {
                return this.equipment;
            }
        }

        public EquipmentService()
        {

        }


        public IList<Equipment> GetEquipmentByType(string machineType)
        {
            return this.equipment.Where(x => x.MachineType.ToLower() == machineType.ToLower()).ToList();
        }

        public Equipment GetByModelNumber(string modelNumber)
        {
            var item = this.equipment.Where(x => x.ModelNumber.ToLower() == modelNumber.ToLower()).SingleOrDefault();
            return item ??
                new Equipment()
                {
                    ModelNumber = modelNumber,
                    Category = "7 Series Tractor",
                    MachineType = "Row Crop Tractor",
                    EngineHorsePower = "42hp"
                };
        }

        public Equipment GetRandomEquipment()
        {
            return this.equipment[new Random().Next(this.equipment.Count())];
        }
    }
}
