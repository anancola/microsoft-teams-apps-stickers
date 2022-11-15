//----------------------------------------------------------------------------------------------
// <copyright file="AvatarDTO.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
//----------------------------------------------------------------------------------------------

namespace StickersTemplate.Configuration.Providers.Replicate
{
    using Newtonsoft.Json;

    /// <summary>
    /// Model describing the <see cref="StyleganNadaInput"/> object.
    /// </summary>
    public class StyleganNadaInput
    {
        /// <summary>
        /// Gets or sets the base64 string for stylegan-nada.
        /// </summary>
        [JsonProperty("input")]
        public string input { get; set; }

        /// <summary>
        /// Gets or sets the output_style.
        /// </summary>
        [JsonProperty("output_style")]
        public string output_style { get; set; }

        /// <summary>
        /// Gets or sets the style_list.
        /// </summary>
        [JsonProperty("style_list")]
        public string style_list { get; set; }

        /// <summary>
        /// Gets or sets the generate_video.
        /// </summary>
        [JsonProperty("generate_video")]
        public bool generate_video { get; set; }

        /// <summary>
        /// Gets or sets the with_editing.
        /// </summary>
        [JsonProperty("with_editing")]
        public bool with_editing { get; set; }
    }
}
