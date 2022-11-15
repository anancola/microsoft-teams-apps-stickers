//----------------------------------------------------------------------------------------------
// <copyright file="AvatarDTO.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------

namespace StickersTemplate.Configuration.Providers.Replicate
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model describing the <see cref="Photo2cartoonInput"/> object.
    /// </summary>
    public class Photo2cartoonInput
    {
        /// <summary>
        /// Gets or sets the base64 string for stylegan-nada.
        /// </summary>
        [JsonProperty("photo")]
        public string photo { get; set; }

    }
}
