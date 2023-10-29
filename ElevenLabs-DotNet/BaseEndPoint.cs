// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace ElevenLabs
{
    public abstract class BaseEndPoint
    {
        internal BaseEndPoint(ElevenLabsClient api) => Api = api;

        protected readonly ElevenLabsClient Api;

        /// <summary>
        /// The root endpoint address.
        /// </summary>
        protected abstract string Root { get; }

        /// <summary>
        /// Gets the full formatted url for the API endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint url.</param>
        /// <param name="queryParameters">Optional, parameters to add to the endpoint.</param>
        protected string GetUrl(string endpoint = "", Dictionary<string, string> queryParameters = null)
        {
            var result = string.Format(Api.ElevenLabsClientSettings.BaseRequestUrlFormat, $"{Root}{endpoint}");

            if (queryParameters is { Count: not 0 })
            {
                result += $"?{string.Join("&", queryParameters.Select(parameter => $"{parameter.Key}={parameter.Value}"))}";
            }

            return result;
        }

        /// <summary>
        /// Enables or disables the logging of all http responses of header and body information for this endpoint.<br/>
        /// WARNING! Enabling this in your production build, could potentially leak sensitive information!
        /// </summary>
        public bool EnableDebug { get; set; }
    }
}
