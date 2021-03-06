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
    /// Structure specifying memory requirements.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MemoryRequirements
    {
        /// <summary>
        /// 
        /// </summary>
        public MemoryRequirements(DeviceSize size, DeviceSize alignment, uint memoryTypeBits)
        {
            this.Size = size;
            this.Alignment = alignment;
            this.MemoryTypeBits = memoryTypeBits;
        }
        
        /// <summary>
        /// pname:size is the size, in bytes, of the memory allocation
        /// required: for the resource.
        /// </summary>
        public DeviceSize Size; 
        
        /// <summary>
        /// pname:alignment is the alignment, in bytes, of the offset within
        /// the allocation required: for the resource.
        /// </summary>
        public DeviceSize Alignment; 
        
        /// <summary>
        /// pname:memoryTypeBits is a bitmask and contains one bit set for
        /// every supported memory type for the resource. Bit `i` is set if and
        /// only if the memory type `i` in the
        /// sname:VkPhysicalDeviceMemoryProperties structure for the physical
        /// device is supported for the resource.
        /// </summary>
        public uint MemoryTypeBits; 
        
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("MemoryRequirements");
            builder.AppendLine("{");
            builder.AppendLine($"Size: {this.Size}");
            builder.AppendLine($"Alignment: {this.Alignment}");
            builder.AppendLine($"MemoryTypeBits: {this.MemoryTypeBits}");
            builder.Append("}");
            return builder.ToString();
        }
    }
}
