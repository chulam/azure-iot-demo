// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace ServiceClients
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;

    /// <summary>
    /// Extension methods for TemperatureHistorian.
    /// </summary>
    public static partial class TemperatureHistorianExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceId'>
            /// </param>
            /// <param name='dataPointId'>
            /// </param>
            /// <param name='timestamp'>
            /// </param>
            /// <param name='value'>
            /// </param>
            public static float? AddDeviceData(this ITemperatureHistorian operations, string deviceId, string dataPointId = default(string), DateTime? timestamp = default(DateTime?), float? value = default(float?))
            {
                return Task.Factory.StartNew(s => ((ITemperatureHistorian)s).AddDeviceDataAsync(deviceId, dataPointId, timestamp, value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceId'>
            /// </param>
            /// <param name='dataPointId'>
            /// </param>
            /// <param name='timestamp'>
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<float?> AddDeviceDataAsync(this ITemperatureHistorian operations, string deviceId, string dataPointId = default(string), DateTime? timestamp = default(DateTime?), float? value = default(float?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.AddDeviceDataWithHttpMessagesAsync(deviceId, dataPointId, timestamp, value, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
