/*
 * IoT Historian API
 *
 * Sample API for keeping a history of IoT devices.
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using TemperatureHistorian.Models;
using ServiceStore;

namespace TemperatureHistorian.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultApiController : Controller
    {
        private readonly IStore store;
        private readonly ILogger logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="store">The store</param>
        /// <param name="logger">The logger to log events</param>
        public DefaultApiController(IStore store, ILogger<DefaultApiController> logger)
        {
            this.store = store;
            this.logger = logger;
        }
        
        /// <summary>
        /// Add data to the device history
        /// </summary>
        /// <remarks>Adds a data point from an IoT device. Once saved, calculates the running average of the existing data, saves it idempotentently and returns it.</remarks>
        /// <param name="deviceId">Device Id</param>
        /// <param name="dataPointId">Each data point needs to have a unique ID</param>
        /// <param name="timestamp">Timestamp when received from the device.</param>
        /// <param name="value">Value registered by the device.</param>
        /// <response code="201">Data added successfully.</response>
        /// <response code="400">Invalid input parameter.</response>
        /// <response code="500">An unexpected error occurred.</response>
        [HttpPost]
        [Route("/v1/deviceData/{deviceId}")]
        [SwaggerOperation("AddDeviceData")]
        [SwaggerResponse(200, type: typeof(float?))]
        public virtual IActionResult AddDeviceData([FromRoute]string deviceId, [FromQuery]string dataPointId, [FromQuery]DateTime? timestamp, [FromQuery]float? value)
        {
             var key = $"{deviceId};{dataPointId}";

            if (!this.store.Exists(key) && value.HasValue)
            {
                this.store.Add(key, value.Value);
                this.logger.LogInformation($"Added {value.Value} for {key} to the store at {timestamp}.");
            }

            if (!value.HasValue)
            {
                this.logger.LogError($"No value found for {key}.");
                return BadRequest($"No data value for device: {deviceId} and datapoint {dataPointId}");
            }

            var average = this.store.GetAll().Where(i => i.Key.StartsWith(deviceId)).Average(v => v.Value);

            this.logger.LogInformation($"Returning {average}.");
            return Created("", average);
        }
    }
}
