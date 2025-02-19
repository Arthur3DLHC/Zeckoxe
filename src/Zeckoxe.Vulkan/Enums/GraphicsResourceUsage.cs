﻿// Copyright (c) 2019-2020 Faber Leonardo. All Rights Reserved. https://github.com/FaberSanZ
// This code is licensed under the MIT license (MIT) (http://opensource.org/licenses/MIT)


/*=============================================================================
	GraphicsResourceUsage.cs
=============================================================================*/


namespace Zeckoxe.Vulkan
{
    public enum GraphicsResourceUsage
    {
        Default = unchecked(0),

        Immutable = unchecked(1),

        Dynamic = unchecked(2),

        Staging = unchecked(3),
    }
}