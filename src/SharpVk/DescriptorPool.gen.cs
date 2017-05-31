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
    /// 
    /// </summary>
    public partial class DescriptorPool
    {
        internal readonly SharpVk.Interop.DescriptorPool handle; 
        
        internal DescriptorPool(SharpVk.Interop.DescriptorPool handle)
        {
            this.handle = handle;
        }
        
        internal unsafe void Destroy(AllocationCallbacks allocator)
        {
            try
            {
                Interop.AllocationCallbacks* marshalledAllocator = default(Interop.AllocationCallbacks*);
                marshalledAllocator = (Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<Interop.AllocationCallbacks>());
                allocator.MarshalTo(marshalledAllocator);
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        internal unsafe void Reset(DescriptorPoolResetFlags flags)
        {
            try
            {
                DescriptorPoolResetFlags marshalledFlags = default(DescriptorPoolResetFlags);
                marshalledFlags = flags;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        internal unsafe void FreeDescriptorSets(DescriptorSet[] descriptorSets)
        {
            try
            {
                uint marshalledDescriptorSetCount = default(uint);
                Interop.DescriptorSet* marshalledDescriptorSets = default(Interop.DescriptorSet*);
                marshalledDescriptorSetCount = (uint)(descriptorSets?.Length ?? 0);
                if (descriptorSets != null)
                {
                    var fieldPointer = (Interop.DescriptorSet*)(Interop.HeapUtil.AllocateAndClear<Interop.DescriptorSet>(descriptorSets.Length).ToPointer());
                    for(int index = 0; index < descriptorSets.Length; index++)
                    {
                        fieldPointer[index] = descriptorSets[index].handle;
                    }
                    marshalledDescriptorSets = fieldPointer;
                }
                else
                {
                    marshalledDescriptorSets = null;
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
    }
}
