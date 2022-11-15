//----------------------------------------------------------------------------------------------
// <copyright file="AvatarDTO.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------

namespace StickersTemplate.Configuration.Providers.Replicate
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model describing the <see cref="Photo2cartoonReq"/> object.
    /// </summary>
    public class Photo2cartoonReq
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty("version")]
        public string version { get; set; }

        /// <summary>
        /// Gets or sets the input.
        /// </summary>
        [JsonProperty("input")]
        public Photo2cartoonInput input { get; set; }
    }
}
