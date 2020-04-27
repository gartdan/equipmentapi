using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DCG.Equipment.WebAPI
{
    public class PartManifest
    {
        public string Pin { get; set; }
        public string MachineType { get; set; }
        public string ModelNumber { get; set; }
        public List<string> Parts { get; set; }
    }
}
