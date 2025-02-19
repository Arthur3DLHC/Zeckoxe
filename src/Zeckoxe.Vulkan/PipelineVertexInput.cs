﻿// Copyright (c) 2019-2020 Faber Leonardo. All Rights Reserved. https://github.com/FaberSanZ
// This code is licensed under the MIT license (MIT) (http://opensource.org/licenses/MIT)

/*=============================================================================
	PipelineVertexInput.cs
=============================================================================*/



using System.Collections.Generic;
using Vortice.Vulkan;

namespace Zeckoxe.Vulkan
{
    public class VertexInputBinding
    {
        public VertexInputBinding()
        {

        }

        public int Binding { get; set; }
        public int Stride { get; set; }
        public VkVertexInputRate InputRate { get; set; }
    }



    public class VertexInputAttribute
    {
        public VertexInputAttribute()
        {

        }

        public int Location { get; set; }
        public int Binding { get; set; }
        public VkFormat Format { get; set; }
        public int Offset { get; set; }
    }


    public class PipelineVertexInput
    {
        public PipelineVertexInput()
        {

        }

        public List<VertexInputBinding> VertexBindingDescriptions { get; set; } = new List<VertexInputBinding>();
        public List<VertexInputAttribute> VertexAttributeDescriptions { get; set; } = new List<VertexInputAttribute>();
    }
}
