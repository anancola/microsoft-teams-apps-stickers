//----------------------------------------------------------------------------------------------
// <copyright file="AvatarDTO.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------

namespace StickersTemplate.Configuration.Providers.Serialization
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model describing the <see cref="AvatarDTO"/> object.
    /// </summary>
    public class AvatarDTO
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        [JsonProperty("user")]
        public string user { get; set; }

        /// <summary>
        /// Gets or sets the image extension.
        /// </summary>
        [JsonProperty("type")]
        public string type { get; set; }

        /// <summary>
        /// Gets or sets the file in base64 string.
        /// </summary>
        [JsonProperty("file")]
        public string file { get; set; }
    }
}
