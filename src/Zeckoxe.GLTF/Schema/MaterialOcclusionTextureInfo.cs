﻿// Copyright (c) 2019-2020 Faber Leonardo. All Rights Reserved. https://github.com/FaberSanZ
// This code is licensed under the MIT license (MIT) (http://opensource.org/licenses/MIT)


/*=============================================================================
	MaterialOcclusionTextureInfo.cs
=============================================================================*/


using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zeckoxe.GLTF.Schema
{
    public class MaterialOcclusionTextureInfo
    {

        [JsonPropertyName("index")]
        public int Index { get; set; }



        [JsonPropertyName("texCoord")]
        public int TexCoord { get; set; }



        [JsonPropertyName("strength")]
        public float Strength { get; set; }



        [JsonPropertyName("extensions")]
        public Dictionary<string, object> Extensions { get; set; }



        [JsonPropertyName("extras")]
        public Extras Extras { get; set; }

    }
}
