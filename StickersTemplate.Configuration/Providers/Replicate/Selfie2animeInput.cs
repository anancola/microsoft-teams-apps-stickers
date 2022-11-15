//----------------------------------------------------------------------------------------------
// <copyright file="AvatarDTO.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------

namespace StickersTemplate.Configuration.Providers.Replicate
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model describing the <see cref="Selfie2animeInput"/> object.
    /// </summary>
    public class Selfie2animeInput
    {
        /// <summary>
        /// Gets or sets the base64 string for stylegan-nada.
        /// </summary>
        [JsonProperty("image")]
        public string image { get; set; }

    }
}
