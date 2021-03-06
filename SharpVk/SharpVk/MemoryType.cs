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
    /// Structure specifying memory type.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct MemoryType
    {
        /// <summary>
        /// 
        /// </summary>
        public MemoryType(MemoryPropertyFlags propertyFlags, uint heapIndex)
        {
            this.PropertyFlags = propertyFlags;
            this.HeapIndex = heapIndex;
        }
        
        /// <summary>
        /// pname:propertyFlags is a bitmask of properties for this memory
        /// type. The bits specified in pname:propertyFlags are: + --
        /// </summary>
        public MemoryPropertyFlags PropertyFlags; 
        
        /// <summary>
        /// pname:heapIndex describes which memory heap this memory type
        /// corresponds to, and must: be less than pname:memoryHeapCount from
        /// the sname:VkPhysicalDeviceMemoryProperties structure.
        /// </summary>
        public uint HeapIndex; 
        
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("MemoryType");
            builder.AppendLine("{");
            builder.AppendLine($"PropertyFlags: {this.PropertyFlags}");
            builder.AppendLine($"HeapIndex: {this.HeapIndex}");
            builder.Append("}");
            return builder.ToString();
        }
    }
}
