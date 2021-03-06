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
using System.Runtime.InteropServices;
using System.Text;

namespace SharpVk
{
    /// <summary>
    /// Structure describing a supported swapchain format-color space pair.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct SurfaceFormat
    {
        /// <summary>
        /// 
        /// </summary>
        public SurfaceFormat(Format format, ColorSpace colorSpace)
        {
            this.Format = format;
            this.ColorSpace = colorSpace;
        }
        
        /// <summary>
        /// pname:format is a ename:VkFormat that is compatible with the
        /// specified surface.
        /// </summary>
        public Format Format; 
        
        /// <summary>
        /// pname:colorSpace is a presentation ename:VkColorSpaceKHR that is
        /// compatible with the surface.
        /// </summary>
        public ColorSpace ColorSpace; 
        
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("SurfaceFormat");
            builder.AppendLine("{");
            builder.AppendLine($"Format: {this.Format}");
            builder.AppendLine($"ColorSpace: {this.ColorSpace}");
            builder.Append("}");
            return builder.ToString();
        }
    }
}
