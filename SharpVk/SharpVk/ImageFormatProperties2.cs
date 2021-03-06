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

using System;

namespace SharpVk
{
    /// <summary>
    /// <para>
    /// Structure specifying a image format properties.
    /// </para>
    /// <para>
    /// If the combination of parameters to
    /// fname:vkGetPhysicalDeviceImageFormatProperties2KHR is not supported by
    /// the implementation for use in flink:vkCreateImage, then all members of
    /// pname:imageFormatProperties will be filled with zero.
    /// </para>
    /// </summary>
    public struct ImageFormatProperties2
    {
        /// <summary>
        /// pname:imageFormatProperties is an instance of a
        /// slink:VkImageFormatProperties structure in which capabilities are
        /// returned.
        /// </summary>
        public ImageFormatProperties ImageFormatProperties
        {
            get;
            set;
        }
        
        internal static unsafe ImageFormatProperties2 MarshalFrom(Interop.ImageFormatProperties2* value)
        {
            ImageFormatProperties2 result = new ImageFormatProperties2();
            result.ImageFormatProperties = value->ImageFormatProperties;
            return result;
        }
    }
}
