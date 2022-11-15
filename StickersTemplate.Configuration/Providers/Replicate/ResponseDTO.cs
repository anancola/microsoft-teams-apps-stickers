//----------------------------------------------------------------------------------------------
// <copyright file="AvatarDTO.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------

namespace StickersTemplate.Configuration.Providers.Replicate
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model describing the <see cref="ResponseDTO"/> object.
    /// </summary>
    public class ResponseDTO
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty("id")]
        public string id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty("version")]
        public string version { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        [JsonProperty("status")]
        public string status { get; set; }
        
        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        [JsonProperty("output")]
        public ResponseFileDTO[] output { get; set; }
        
    }
}
