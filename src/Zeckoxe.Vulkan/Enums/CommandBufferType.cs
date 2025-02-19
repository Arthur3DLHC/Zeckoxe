﻿// Copyright (c) 2019-2020 Faber Leonardo. All Rights Reserved. https://github.com/FaberSanZ
// This code is licensed under the MIT license (MIT) (http://opensource.org/licenses/MIT)


/*=============================================================================
	CommandBufferType.cs
=============================================================================*/

namespace Zeckoxe.Vulkan
{
    public enum CommandBufferType
    {
        Generic,

        AsyncGraphics,

        AsyncCompute,

        AsyncTransfer,

        Count
    }
}
