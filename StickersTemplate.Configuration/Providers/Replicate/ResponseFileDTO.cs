//----------------------------------------------------------------------------------------------
// <copyright file="AvatarDTO.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------

namespace StickersTemplate.Configuration.Providers.Replicate
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model describing the <see cref="ResponseFileDTO"/> object.
    /// </summary>
    public class ResponseFileDTO
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty("file")]
        public string file { get; set; }
        
    }
}
