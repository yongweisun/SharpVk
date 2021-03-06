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

namespace SharpVk.Interop.Khronos.Experimental
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BindBufferMemoryInfo
    {
        /// <summary>
        /// The type of this structure.
        /// </summary>
        public SharpVk.StructureType SType; 
        
        /// <summary>
        /// Null or an extension-specific structure.
        /// </summary>
        public void* Next; 
        
        /// <summary>
        /// The buffer to be attached to memory.
        /// </summary>
        public SharpVk.Interop.Buffer Buffer; 
        
        /// <summary>
        /// A DeviceMemory object describing the device memory to attach.
        /// </summary>
        public SharpVk.Interop.DeviceMemory Memory; 
        
        /// <summary>
        /// The start offset of the region of memory which is to be bound to
        /// the buffer. The number of bytes returned in the
        /// MemoryRequirements.size member in memory, starting from
        /// memoryOffset bytes, will be bound to the specified buffer.
        /// </summary>
        public DeviceSize MemoryOffset; 
        
        /// <summary>
        /// The number of elements in DeviceIndices.
        /// </summary>
        public uint DeviceIndexCount; 
        
        /// <summary>
        /// An array of device indices.
        /// </summary>
        public uint* DeviceIndices; 
    }
}
