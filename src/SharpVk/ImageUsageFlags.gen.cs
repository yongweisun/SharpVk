// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2017
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This file was automatically generated and should not be edited directly.

namespace SharpVk
{
    /// <summary>
    /// Bitmask specifying intended usage of an image.
    /// </summary>
    [System.Flags]
    public enum ImageUsageFlags
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0, 
        
        /// <summary>
        /// Indicates that the image can be used as the source of a transfer
        /// command.
        /// </summary>
        TransferSource = 1 << 0, 
        
        /// <summary>
        /// Indicates that the image can be used as the destination of a
        /// transfer command.
        /// </summary>
        TransferDestination = 1 << 1, 
        
        /// <summary>
        /// Indicates that the image can be used to create a ImageView suitable
        /// for occupying a DescriptorSet slot either of type
        /// VK_DESCRIPTOR_TYPE_SAMPLED_IMAGE or
        /// VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER, and be sampled by a
        /// shader.
        /// </summary>
        Sampled = 1 << 2, 
        
        /// <summary>
        /// Indicates that the image can be used to create a ImageView suitable
        /// for occupying a DescriptorSet slot of type
        /// VK_DESCRIPTOR_TYPE_STORAGE_IMAGE.
        /// </summary>
        Storage = 1 << 3, 
        
        /// <summary>
        /// Indicates that the image can be used to create a ImageView suitable
        /// for use as a color or resolve attachment in a Framebuffer.
        /// </summary>
        ColorAttachment = 1 << 4, 
        
        /// <summary>
        /// Indicates that the image can be used to create a ImageView suitable
        /// for use as a depth/stencil attachment in a Framebuffer.
        /// </summary>
        DepthStencilAttachment = 1 << 5, 
        
        /// <summary>
        /// Indicates that the memory bound to this image will have been
        /// allocated with the VK_MEMORY_PROPERTY_LAZILY_ALLOCATED_BIT (see
        /// &lt;&lt;memory for more detail). This bit can be set for any image
        /// that can be used to create a ImageView suitable for use as a color,
        /// resolve, depth/stencil, or input attachment.
        /// </summary>
        TransientAttachment = 1 << 6, 
        
        /// <summary>
        /// Indicates that the image can be used to create a ImageView suitable
        /// for occupying DescriptorSet slot of type
        /// VK_DESCRIPTOR_TYPE_INPUT_ATTACHMENT; be read from a shader as an
        /// input attachment; and be used as an input attachment in a
        /// framebuffer.
        /// </summary>
        InputAttachment = 1 << 7, 
    }
}
