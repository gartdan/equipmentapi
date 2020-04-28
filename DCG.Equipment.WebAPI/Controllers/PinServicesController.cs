using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DCG.Equipment.WebAPI.Controllers
{
    [ApiController]
    public class PinServicesController : ControllerBase
    {
        private TelemetryClient _telemetry;

        public PinServicesController(TelemetryClient telemetry)
        {
            this._telemetry = telemetry;
        }

        [HttpPost("pin/search")]
        public PartManifest PinSearch(string pin)
        {
            if (pin == "-1")
                throw new ApplicationException($"Invalid pin:{0}");
            this._telemetry.TrackEvent($"PinSearch Called - {pin}");
            var manifest = new PartManifest() { Pin = pin };
            manifest.ModelNumber = "6215R";
            manifest.MachineType = "Row Crop Tractors";
            var parts = new List<string>()
            {
                "Part A",
                "Part B",
                "Part C",
                "Pard D",
                "Engine Type",
                "Transmission"
            };
            manifest.Parts = parts;
            return manifest;
        }
    }
}