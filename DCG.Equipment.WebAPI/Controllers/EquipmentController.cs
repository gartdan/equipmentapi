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
    public class EquipmentController : ControllerBase
    {

        private EquipmentService _equipmentService = new EquipmentService();
        private TelemetryClient _telemetry;

        public EquipmentController(TelemetryClient telemetry)
        {
            this._telemetry = telemetry;
        }


        [HttpGet("equipment/hello")]
        public string Hello()
        {
            this._telemetry.TrackEvent("Hello");
            return "Hello";
        }

        [HttpGet("equipment/nearestdealer")]
        public Dealer NearestDealer(string latitude = "41.881832", string longitude = "-87.623177", string range = "5m")
        {
            this._telemetry.TrackEvent("NearestDealer");
            this._telemetry.TrackTrace($"Searching for nearest dealer: {latitude}, {longitude}");
            return Dealer.GetRandomDealer();
        }

        [HttpPost("equipment/topseller")]
        public Equipment GetTopSeller(string dealerId)
        {
            this._telemetry.TrackEvent("GetTopSeller", new Dictionary<string, string>() { { "GetTopSeller", dealerId } });
            this._telemetry.TrackTrace($"Searching for Top Seller: {dealerId}");
            return GetEquipmentDetails(dealerId);
        }

        [HttpPost("equipment/bytype")]
        public IList<Equipment> GetEquipmentByType(string equipmentType)
        {
            this._telemetry.TrackEvent("GetEquipmentByType", new Dictionary<string, string>() { { "EquipmentType", equipmentType } });
            this._telemetry.TrackTrace($"GetEquipmentByType: {equipmentType}");
            return _equipmentService.GetEquipmentByType(equipmentType);
        }

        

        [HttpPost("equiment/details")]
        public Equipment GetEquipmentDetails(string modelNumber)
        {
            if (modelNumber == "-1")
                throw new ApplicationException($"Invalid Model Number {0}");
            return _equipmentService.GetByModelNumber(modelNumber);
        }

        [HttpPost("equipment/similar")]
        public Equipment GetSimilarMachine(string modelNumber)
        {
            if (modelNumber == "-1")
                throw new ApplicationException($"Invalid Model Number {0}");
            this._telemetry.TrackEvent("GetSimilarMachine");
            this._telemetry.TrackTrace($"GetSimilarMachine: {modelNumber}");
            return _equipmentService.GetRandomEquipment();
        }
    }
}