﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace blendnet.api.proxy.Common
{
    /// <summary>
    /// Http Helper
    /// </summary>
    public static class HttpHelper
    {
        public static JsonSerializerOptions _jsonSerializerOptions = Utilties.GetJsonSerializerOptions();

        /// <summary>
        /// Performs the get operation via HttpClient
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<O> Get<O>(this HttpClient httpClient, string url, string accessToken="")
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);
            }
            
            var httpResponse = await httpClient.GetAsync(url);

            httpResponse.EnsureSuccessStatusCode();

            var successResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<O>(successResponse, _jsonSerializerOptions);
        }
    }
}
