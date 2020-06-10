using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;

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
        public async Task<PartManifest> PinSearch(string pin)
        {
            if (pin == "-1")
                throw new ApplicationException($"Invalid pin:{0}");
            this._telemetry.TrackEvent($"PinSearch Called - {pin}");
            await SendMessageToTopic($"PinSearch Called - { pin}");
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

        [NonAction]
        public async Task SendMessageToTopic(string message)
        {
            const string ServiceBusConnectionString = "Endpoint=sb://dcgdemo1.servicebus.windows.net/;SharedAccessKeyName=policy1;SharedAccessKey=OVhIc+keVq7QSL5qGBaH/JsiKY/hCEEjI6HpWuamIf4=";
            const string TopicName = "pinsearch";
            
            ITopicClient topicClient = new TopicClient(ServiceBusConnectionString, TopicName);
            var msg = new Message(Encoding.UTF8.GetBytes(message));
            msg.CorrelationId = this._telemetry.Context.Operation.Id;
            this._telemetry.TrackTrace($"Correlation ID: {this._telemetry.Context.Operation.Id} -- Sending message {message} to Service Bus");
            await topicClient.SendAsync(msg);

        }
    }
}