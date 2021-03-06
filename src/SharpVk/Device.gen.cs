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
    /// Opaque handle to a device object.
    /// </summary>
    public partial class Device
        : IProcLookup
    {
        internal readonly SharpVk.Interop.Device handle; 
        
        internal readonly CommandCache commandCache; 
        
        internal readonly SharpVk.PhysicalDevice parent; 
        
        internal Device(SharpVk.PhysicalDevice parent, SharpVk.Interop.Device handle)
        {
            this.handle = handle;
            this.parent = parent;
            this.commandCache = new CommandCache(this, "device", parent.commandCache);
        }
        
        /// <summary>
        /// Return a function pointer for a command.
        /// </summary>
        public unsafe IntPtr GetProcedureAddress(string name)
        {
            try
            {
                IntPtr result = default(IntPtr);
                result = Interop.Commands.vkGetDeviceProcAddr(this.handle, Interop.HeapUtil.MarshalTo(name));
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Destroy a logical device.
        /// </summary>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe void Destroy(SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Interop.Commands.vkDestroyDevice(this.handle, marshalledAllocator);
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Get a queue handle from a device.
        /// </summary>
        public unsafe SharpVk.Queue GetQueue(uint queueFamilyIndex, uint queueIndex)
        {
            try
            {
                SharpVk.Queue result = default(SharpVk.Queue);
                SharpVk.Interop.Queue marshalledQueue = default(SharpVk.Interop.Queue);
                Interop.Commands.vkGetDeviceQueue(this.handle, queueFamilyIndex, queueIndex, &marshalledQueue);
                result = new SharpVk.Queue(this, marshalledQueue);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Wait for a device to become idle.
        /// </summary>
        public unsafe void WaitIdle()
        {
            try
            {
                Result methodResult = Interop.Commands.vkDeviceWaitIdle(this.handle);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Allocate GPU memory.
        /// </summary>
        /// <param name="allocationSize">
        /// The size of the allocation in bytes
        /// </param>
        /// <param name="memoryTypeIndex">
        /// The memory type index, which selects the properties of the memory
        /// to be allocated, as well as the heap the memory will come from.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.DeviceMemory AllocateMemory(DeviceSize allocationSize, uint memoryTypeIndex, SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.DeviceMemory result = default(SharpVk.DeviceMemory);
                SharpVk.Interop.MemoryAllocateInfo* marshalledAllocateInfo = default(SharpVk.Interop.MemoryAllocateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.DeviceMemory marshalledMemory = default(SharpVk.Interop.DeviceMemory);
                marshalledAllocateInfo = (SharpVk.Interop.MemoryAllocateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.MemoryAllocateInfo>());
                marshalledAllocateInfo->SType = StructureType.MemoryAllocateInfo;
                marshalledAllocateInfo->Next = null;
                marshalledAllocateInfo->AllocationSize = allocationSize;
                marshalledAllocateInfo->MemoryTypeIndex = memoryTypeIndex;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkAllocateMemory(this.handle, marshalledAllocateInfo, marshalledAllocator, &marshalledMemory);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.DeviceMemory(this, marshalledMemory);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Flush mapped memory ranges.
        /// </summary>
        public unsafe void FlushMappedMemoryRanges(ArrayProxy<SharpVk.MappedMemoryRange>? memoryRanges)
        {
            try
            {
                SharpVk.Interop.MappedMemoryRange* marshalledMemoryRanges = default(SharpVk.Interop.MappedMemoryRange*);
                if (memoryRanges.IsNull())
                {
                    marshalledMemoryRanges = null;
                }
                else
                {
                    if (memoryRanges.Value.Contents == ProxyContents.Single)
                    {
                        marshalledMemoryRanges = (SharpVk.Interop.MappedMemoryRange*)(Interop.HeapUtil.Allocate<SharpVk.Interop.MappedMemoryRange>());
                        memoryRanges.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.MappedMemoryRange*)(marshalledMemoryRanges));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.MappedMemoryRange*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.MappedMemoryRange>(Interop.HeapUtil.GetLength(memoryRanges.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(memoryRanges.Value)); index++)
                        {
                            memoryRanges.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledMemoryRanges = fieldPointer;
                    }
                }
                Result methodResult = Interop.Commands.vkFlushMappedMemoryRanges(this.handle, (uint)(Interop.HeapUtil.GetLength(memoryRanges)), marshalledMemoryRanges);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Invalidate ranges of mapped memory objects.
        /// </summary>
        public unsafe void InvalidateMappedMemoryRanges(ArrayProxy<SharpVk.MappedMemoryRange>? memoryRanges)
        {
            try
            {
                SharpVk.Interop.MappedMemoryRange* marshalledMemoryRanges = default(SharpVk.Interop.MappedMemoryRange*);
                if (memoryRanges.IsNull())
                {
                    marshalledMemoryRanges = null;
                }
                else
                {
                    if (memoryRanges.Value.Contents == ProxyContents.Single)
                    {
                        marshalledMemoryRanges = (SharpVk.Interop.MappedMemoryRange*)(Interop.HeapUtil.Allocate<SharpVk.Interop.MappedMemoryRange>());
                        memoryRanges.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.MappedMemoryRange*)(marshalledMemoryRanges));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.MappedMemoryRange*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.MappedMemoryRange>(Interop.HeapUtil.GetLength(memoryRanges.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(memoryRanges.Value)); index++)
                        {
                            memoryRanges.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledMemoryRanges = fieldPointer;
                    }
                }
                Result methodResult = Interop.Commands.vkInvalidateMappedMemoryRanges(this.handle, (uint)(Interop.HeapUtil.GetLength(memoryRanges)), marshalledMemoryRanges);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new fence object.
        /// </summary>
        /// <param name="flags">
        /// flags defines the initial state and behavior of the fence. Bits
        /// which can be set include: + --
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Fence CreateFence(SharpVk.FenceCreateFlags? flags = default(SharpVk.FenceCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Fence result = default(SharpVk.Fence);
                SharpVk.Interop.FenceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.FenceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Fence marshalledFence = default(SharpVk.Interop.Fence);
                marshalledCreateInfo = (SharpVk.Interop.FenceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.FenceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.FenceCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.FenceCreateFlags);
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateFence(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledFence);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Fence(this, marshalledFence);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Resets one or more fence objects.
        /// </summary>
        public unsafe void ResetFences(ArrayProxy<SharpVk.Fence>? fences)
        {
            try
            {
                SharpVk.Interop.Fence* marshalledFences = default(SharpVk.Interop.Fence*);
                if (fences.IsNull())
                {
                    marshalledFences = null;
                }
                else
                {
                    if (fences.Value.Contents == ProxyContents.Single)
                    {
                        marshalledFences = (SharpVk.Interop.Fence*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Fence>());
                        *(SharpVk.Interop.Fence*)(marshalledFences) = fences.Value.GetSingleValue()?.handle ?? default(SharpVk.Interop.Fence);
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.Fence*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.Fence>(Interop.HeapUtil.GetLength(fences.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(fences.Value)); index++)
                        {
                            fieldPointer[index] = fences.Value[index]?.handle ?? default(SharpVk.Interop.Fence);
                        }
                        marshalledFences = fieldPointer;
                    }
                }
                Result methodResult = Interop.Commands.vkResetFences(this.handle, (uint)(Interop.HeapUtil.GetLength(fences)), marshalledFences);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Wait for one or more fences to become signaled.
        /// </summary>
        public unsafe void WaitForFences(ArrayProxy<SharpVk.Fence>? fences, bool waitAll, ulong timeout)
        {
            try
            {
                SharpVk.Interop.Fence* marshalledFences = default(SharpVk.Interop.Fence*);
                if (fences.IsNull())
                {
                    marshalledFences = null;
                }
                else
                {
                    if (fences.Value.Contents == ProxyContents.Single)
                    {
                        marshalledFences = (SharpVk.Interop.Fence*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Fence>());
                        *(SharpVk.Interop.Fence*)(marshalledFences) = fences.Value.GetSingleValue()?.handle ?? default(SharpVk.Interop.Fence);
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.Fence*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.Fence>(Interop.HeapUtil.GetLength(fences.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(fences.Value)); index++)
                        {
                            fieldPointer[index] = fences.Value[index]?.handle ?? default(SharpVk.Interop.Fence);
                        }
                        marshalledFences = fieldPointer;
                    }
                }
                Result methodResult = Interop.Commands.vkWaitForFences(this.handle, (uint)(Interop.HeapUtil.GetLength(fences)), marshalledFences, waitAll, timeout);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new queue semaphore object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Semaphore CreateSemaphore(SharpVk.SemaphoreCreateFlags? flags = default(SharpVk.SemaphoreCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Semaphore result = default(SharpVk.Semaphore);
                SharpVk.Interop.SemaphoreCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.SemaphoreCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Semaphore marshalledSemaphore = default(SharpVk.Interop.Semaphore);
                marshalledCreateInfo = (SharpVk.Interop.SemaphoreCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.SemaphoreCreateInfo>());
                marshalledCreateInfo->SType = StructureType.SemaphoreCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.SemaphoreCreateFlags);
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateSemaphore(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSemaphore);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Semaphore(this, marshalledSemaphore);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new event object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Event CreateEvent(SharpVk.EventCreateFlags? flags = default(SharpVk.EventCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Event result = default(SharpVk.Event);
                SharpVk.Interop.EventCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.EventCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Event marshalledEvent = default(SharpVk.Interop.Event);
                marshalledCreateInfo = (SharpVk.Interop.EventCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.EventCreateInfo>());
                marshalledCreateInfo->SType = StructureType.EventCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.EventCreateFlags);
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateEvent(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledEvent);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Event(this, marshalledEvent);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new query pool object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="queryType">
        /// The type of queries managed by the pool.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.QueryPool CreateQueryPool(SharpVk.QueryType queryType, uint queryCount, SharpVk.QueryPoolCreateFlags? flags = default(SharpVk.QueryPoolCreateFlags?), SharpVk.QueryPipelineStatisticFlags? pipelineStatistics = default(SharpVk.QueryPipelineStatisticFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.QueryPool result = default(SharpVk.QueryPool);
                SharpVk.Interop.QueryPoolCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.QueryPoolCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.QueryPool marshalledQueryPool = default(SharpVk.Interop.QueryPool);
                marshalledCreateInfo = (SharpVk.Interop.QueryPoolCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.QueryPoolCreateInfo>());
                marshalledCreateInfo->SType = StructureType.QueryPoolCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.QueryPoolCreateFlags);
                }
                marshalledCreateInfo->QueryType = queryType;
                marshalledCreateInfo->QueryCount = queryCount;
                if (pipelineStatistics != null)
                {
                    marshalledCreateInfo->PipelineStatistics = pipelineStatistics.Value;
                }
                else
                {
                    marshalledCreateInfo->PipelineStatistics = default(SharpVk.QueryPipelineStatisticFlags);
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateQueryPool(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledQueryPool);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.QueryPool(this, marshalledQueryPool);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new buffer object.
        /// </summary>
        /// <param name="flags">
        /// A bitmask describing additional parameters of the buffer.
        /// </param>
        /// <param name="size">
        /// The size in bytes of the buffer to be created.
        /// </param>
        /// <param name="usage">
        /// A bitmask describing the allowed usages of the buffer.
        /// </param>
        /// <param name="sharingMode">
        /// The sharing mode of the buffer when it will be accessed by multiple
        /// queue families.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Buffer CreateBuffer(DeviceSize size, SharpVk.BufferUsageFlags usage, SharpVk.SharingMode sharingMode, ArrayProxy<uint>? queueFamilyIndices, SharpVk.BufferCreateFlags? flags = default(SharpVk.BufferCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Buffer result = default(SharpVk.Buffer);
                SharpVk.Interop.BufferCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.BufferCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Buffer marshalledBuffer = default(SharpVk.Interop.Buffer);
                marshalledCreateInfo = (SharpVk.Interop.BufferCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.BufferCreateInfo>());
                marshalledCreateInfo->SType = StructureType.BufferCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.BufferCreateFlags);
                }
                marshalledCreateInfo->Size = size;
                marshalledCreateInfo->Usage = usage;
                marshalledCreateInfo->SharingMode = sharingMode;
                marshalledCreateInfo->QueueFamilyIndexCount = (uint)(Interop.HeapUtil.GetLength(queueFamilyIndices));
                if (queueFamilyIndices.IsNull())
                {
                    marshalledCreateInfo->QueueFamilyIndices = null;
                }
                else
                {
                    if (queueFamilyIndices.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->QueueFamilyIndices = (uint*)(Interop.HeapUtil.Allocate<uint>());
                        *(uint*)(marshalledCreateInfo->QueueFamilyIndices) = queueFamilyIndices.Value.GetSingleValue();
                    }
                    else
                    {
                        var fieldPointer = (uint*)(Interop.HeapUtil.AllocateAndClear<uint>(Interop.HeapUtil.GetLength(queueFamilyIndices.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(queueFamilyIndices.Value)); index++)
                        {
                            fieldPointer[index] = queueFamilyIndices.Value[index];
                        }
                        marshalledCreateInfo->QueueFamilyIndices = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateBuffer(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledBuffer);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Buffer(this, marshalledBuffer);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new buffer view object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="buffer">
        /// A Buffer on which the view will be created.
        /// </param>
        /// <param name="format">
        /// A Format describing the format of the data elements in the buffer.
        /// </param>
        /// <param name="offset">
        /// An offset in bytes from the base address of the buffer. Accesses to
        /// the buffer view from shaders use addressing that is relative to
        /// this starting offset.
        /// </param>
        /// <param name="range">
        /// A size in bytes of the buffer view. If range is equal to
        /// VK_WHOLE_SIZE, the range from offset to the end of the buffer is
        /// used. If VK_WHOLE_SIZE is used and the remaining size of the buffer
        /// is not a multiple of the element size of format, then the nearest
        /// smaller multiple is used.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.BufferView CreateBufferView(SharpVk.Buffer buffer, SharpVk.Format format, DeviceSize offset, DeviceSize range, SharpVk.BufferViewCreateFlags? flags = default(SharpVk.BufferViewCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.BufferView result = default(SharpVk.BufferView);
                SharpVk.Interop.BufferViewCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.BufferViewCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.BufferView marshalledView = default(SharpVk.Interop.BufferView);
                marshalledCreateInfo = (SharpVk.Interop.BufferViewCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.BufferViewCreateInfo>());
                marshalledCreateInfo->SType = StructureType.BufferViewCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.BufferViewCreateFlags);
                }
                marshalledCreateInfo->Buffer = buffer?.handle ?? default(SharpVk.Interop.Buffer);
                marshalledCreateInfo->Format = format;
                marshalledCreateInfo->Offset = offset;
                marshalledCreateInfo->Range = range;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateBufferView(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledView);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.BufferView(this, marshalledView);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new image object.
        /// </summary>
        /// <param name="flags">
        /// A bitmask describing additional parameters of the image. See
        /// ImageCreateFlagBits below for a description of the supported bits.
        /// </param>
        /// <param name="imageType">
        /// A ImageType specifying the basic dimensionality of the image, as
        /// described below. Layers in array textures do not count as a
        /// dimension for the purposes of the image type.
        /// </param>
        /// <param name="format">
        /// A Format describing the format and type of the data elements that
        /// will be contained in the image.
        /// </param>
        /// <param name="extent">
        /// A Extent3D describing the number of data elements in each dimension
        /// of the base level.
        /// </param>
        /// <param name="mipLevels">
        /// mipLevels describes the number of levels of detail available for
        /// minified sampling of the image.
        /// </param>
        /// <param name="arrayLayers">
        /// The number of layers in the image.
        /// </param>
        /// <param name="samples">
        /// The number of sub-data element samples in the image as defined in
        /// SampleCountFlagBits. See Multisampling.
        /// </param>
        /// <param name="tiling">
        /// A ImageTiling specifying the tiling arrangement of the data
        /// elements in memory, as described below.
        /// </param>
        /// <param name="usage">
        /// A bitmask describing the intended usage of the image. See
        /// ImageUsageFlagBits below for a description of the supported bits.
        /// </param>
        /// <param name="sharingMode">
        /// The sharing mode of the image when it will be accessed by multiple
        /// queue families, and must be one of the values described for
        /// SharingMode in the Resource Sharing section below.
        /// </param>
        /// <param name="initialLayout">
        /// initialLayout selects the initial ImageLayout state of all image
        /// subresources of the image. See Image Layouts. initialLayout must be
        /// VK_IMAGE_LAYOUT_UNDEFINED or VK_IMAGE_LAYOUT_PREINITIALIZED.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Image CreateImage(SharpVk.ImageType imageType, SharpVk.Format format, SharpVk.Extent3D extent, uint mipLevels, uint arrayLayers, SharpVk.SampleCountFlags samples, SharpVk.ImageTiling tiling, SharpVk.ImageUsageFlags usage, SharpVk.SharingMode sharingMode, ArrayProxy<uint>? queueFamilyIndices, SharpVk.ImageLayout initialLayout, SharpVk.ImageCreateFlags? flags = default(SharpVk.ImageCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Image result = default(SharpVk.Image);
                SharpVk.Interop.ImageCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.ImageCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Image marshalledImage = default(SharpVk.Interop.Image);
                marshalledCreateInfo = (SharpVk.Interop.ImageCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.ImageCreateInfo>());
                marshalledCreateInfo->SType = StructureType.ImageCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.ImageCreateFlags);
                }
                marshalledCreateInfo->ImageType = imageType;
                marshalledCreateInfo->Format = format;
                marshalledCreateInfo->Extent = extent;
                marshalledCreateInfo->MipLevels = mipLevels;
                marshalledCreateInfo->ArrayLayers = arrayLayers;
                marshalledCreateInfo->Samples = samples;
                marshalledCreateInfo->Tiling = tiling;
                marshalledCreateInfo->Usage = usage;
                marshalledCreateInfo->SharingMode = sharingMode;
                marshalledCreateInfo->QueueFamilyIndexCount = (uint)(Interop.HeapUtil.GetLength(queueFamilyIndices));
                if (queueFamilyIndices.IsNull())
                {
                    marshalledCreateInfo->QueueFamilyIndices = null;
                }
                else
                {
                    if (queueFamilyIndices.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->QueueFamilyIndices = (uint*)(Interop.HeapUtil.Allocate<uint>());
                        *(uint*)(marshalledCreateInfo->QueueFamilyIndices) = queueFamilyIndices.Value.GetSingleValue();
                    }
                    else
                    {
                        var fieldPointer = (uint*)(Interop.HeapUtil.AllocateAndClear<uint>(Interop.HeapUtil.GetLength(queueFamilyIndices.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(queueFamilyIndices.Value)); index++)
                        {
                            fieldPointer[index] = queueFamilyIndices.Value[index];
                        }
                        marshalledCreateInfo->QueueFamilyIndices = fieldPointer;
                    }
                }
                marshalledCreateInfo->InitialLayout = initialLayout;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateImage(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledImage);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Image(this, marshalledImage);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create an image view from an existing image.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="image">
        /// A Image on which the view will be created.
        /// </param>
        /// <param name="viewType">
        /// The type of the image view.
        /// </param>
        /// <param name="format">
        /// A Format describing the format and type used to interpret data
        /// elements in the image.
        /// </param>
        /// <param name="components">
        /// Specifies a remapping of color components (or of depth or stencil
        /// components after they have been converted into color components).
        /// See ComponentMapping.
        /// </param>
        /// <param name="subresourceRange">
        /// A ImageSubresourceRange selecting the set of mipmap levels and
        /// array layers to be accessible to the view.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.ImageView CreateImageView(SharpVk.Image image, SharpVk.ImageViewType viewType, SharpVk.Format format, SharpVk.ComponentMapping components, SharpVk.ImageSubresourceRange subresourceRange, SharpVk.ImageViewCreateFlags? flags = default(SharpVk.ImageViewCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.ImageView result = default(SharpVk.ImageView);
                SharpVk.Interop.ImageViewCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.ImageViewCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.ImageView marshalledView = default(SharpVk.Interop.ImageView);
                marshalledCreateInfo = (SharpVk.Interop.ImageViewCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.ImageViewCreateInfo>());
                marshalledCreateInfo->SType = StructureType.ImageViewCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.ImageViewCreateFlags);
                }
                marshalledCreateInfo->Image = image?.handle ?? default(SharpVk.Interop.Image);
                marshalledCreateInfo->ViewType = viewType;
                marshalledCreateInfo->Format = format;
                marshalledCreateInfo->Components = components;
                marshalledCreateInfo->SubresourceRange = subresourceRange;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateImageView(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledView);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.ImageView(this, marshalledView);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Creates a new shader module object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="codeSize">
        /// The size, in bytes, of the code pointed to by pCode.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.ShaderModule CreateShaderModule(HostSize codeSize, ArrayProxy<uint>? code, SharpVk.ShaderModuleCreateFlags? flags = default(SharpVk.ShaderModuleCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.ShaderModule result = default(SharpVk.ShaderModule);
                SharpVk.Interop.ShaderModuleCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.ShaderModuleCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.ShaderModule marshalledShaderModule = default(SharpVk.Interop.ShaderModule);
                marshalledCreateInfo = (SharpVk.Interop.ShaderModuleCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.ShaderModuleCreateInfo>());
                marshalledCreateInfo->SType = StructureType.ShaderModuleCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.ShaderModuleCreateFlags);
                }
                marshalledCreateInfo->CodeSize = codeSize;
                if (code.IsNull())
                {
                    marshalledCreateInfo->Code = null;
                }
                else
                {
                    if (code.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->Code = (uint*)(Interop.HeapUtil.Allocate<uint>());
                        *(uint*)(marshalledCreateInfo->Code) = code.Value.GetSingleValue();
                    }
                    else
                    {
                        var fieldPointer = (uint*)(Interop.HeapUtil.AllocateAndClear<uint>(Interop.HeapUtil.GetLength(code.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(code.Value)); index++)
                        {
                            fieldPointer[index] = code.Value[index];
                        }
                        marshalledCreateInfo->Code = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateShaderModule(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledShaderModule);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.ShaderModule(this, marshalledShaderModule);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Creates a new pipeline cache.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.PipelineCache CreatePipelineCache(ArrayProxy<byte>? initialData, SharpVk.PipelineCacheCreateFlags? flags = default(SharpVk.PipelineCacheCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.PipelineCache result = default(SharpVk.PipelineCache);
                SharpVk.Interop.PipelineCacheCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.PipelineCacheCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.PipelineCache marshalledPipelineCache = default(SharpVk.Interop.PipelineCache);
                marshalledCreateInfo = (SharpVk.Interop.PipelineCacheCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PipelineCacheCreateInfo>());
                marshalledCreateInfo->SType = StructureType.PipelineCacheCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.PipelineCacheCreateFlags);
                }
                marshalledCreateInfo->InitialDataSize = (HostSize)(Interop.HeapUtil.GetLength(initialData));
                if (initialData.IsNull())
                {
                    marshalledCreateInfo->InitialData = null;
                }
                else
                {
                    if (initialData.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->InitialData = (byte*)(Interop.HeapUtil.Allocate<byte>());
                        *(byte*)(marshalledCreateInfo->InitialData) = initialData.Value.GetSingleValue();
                    }
                    else
                    {
                        var fieldPointer = (byte*)(Interop.HeapUtil.AllocateAndClear<byte>(Interop.HeapUtil.GetLength(initialData.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(initialData.Value)); index++)
                        {
                            fieldPointer[index] = initialData.Value[index];
                        }
                        marshalledCreateInfo->InitialData = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreatePipelineCache(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledPipelineCache);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.PipelineCache(this, marshalledPipelineCache);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create graphics pipelines.
        /// </summary>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Pipeline[] CreateGraphicsPipelines(SharpVk.PipelineCache pipelineCache, ArrayProxy<SharpVk.GraphicsPipelineCreateInfo>? createInfos, SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Pipeline[] result = default(SharpVk.Pipeline[]);
                uint createInfoCount = default(uint);
                SharpVk.Interop.GraphicsPipelineCreateInfo* marshalledCreateInfos = default(SharpVk.Interop.GraphicsPipelineCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Pipeline* marshalledPipelines = default(SharpVk.Interop.Pipeline*);
                createInfoCount = (uint)(Interop.HeapUtil.GetLength(createInfos));
                if (createInfos.IsNull())
                {
                    marshalledCreateInfos = null;
                }
                else
                {
                    if (createInfos.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfos = (SharpVk.Interop.GraphicsPipelineCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.GraphicsPipelineCreateInfo>());
                        createInfos.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.GraphicsPipelineCreateInfo*)(marshalledCreateInfos));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.GraphicsPipelineCreateInfo*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.GraphicsPipelineCreateInfo>(Interop.HeapUtil.GetLength(createInfos.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(createInfos.Value)); index++)
                        {
                            createInfos.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledCreateInfos = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                marshalledPipelines = (SharpVk.Interop.Pipeline*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Pipeline>(createInfoCount));
                Result methodResult = Interop.Commands.vkCreateGraphicsPipelines(this.handle, pipelineCache?.handle ?? default(SharpVk.Interop.PipelineCache), createInfoCount, marshalledCreateInfos, marshalledAllocator, marshalledPipelines);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                if (marshalledPipelines != null)
                {
                    var fieldPointer = new SharpVk.Pipeline[(uint)(createInfoCount)];
                    for(int index = 0; index < (uint)(createInfoCount); index++)
                    {
                        fieldPointer[index] = new SharpVk.Pipeline(this, marshalledPipelines[index]);
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Creates a new compute pipeline object.
        /// </summary>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Pipeline[] CreateComputePipelines(SharpVk.PipelineCache pipelineCache, ArrayProxy<SharpVk.ComputePipelineCreateInfo>? createInfos, SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Pipeline[] result = default(SharpVk.Pipeline[]);
                uint createInfoCount = default(uint);
                SharpVk.Interop.ComputePipelineCreateInfo* marshalledCreateInfos = default(SharpVk.Interop.ComputePipelineCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Pipeline* marshalledPipelines = default(SharpVk.Interop.Pipeline*);
                createInfoCount = (uint)(Interop.HeapUtil.GetLength(createInfos));
                if (createInfos.IsNull())
                {
                    marshalledCreateInfos = null;
                }
                else
                {
                    if (createInfos.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfos = (SharpVk.Interop.ComputePipelineCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.ComputePipelineCreateInfo>());
                        createInfos.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.ComputePipelineCreateInfo*)(marshalledCreateInfos));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.ComputePipelineCreateInfo*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.ComputePipelineCreateInfo>(Interop.HeapUtil.GetLength(createInfos.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(createInfos.Value)); index++)
                        {
                            createInfos.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledCreateInfos = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                marshalledPipelines = (SharpVk.Interop.Pipeline*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Pipeline>(createInfoCount));
                Result methodResult = Interop.Commands.vkCreateComputePipelines(this.handle, pipelineCache?.handle ?? default(SharpVk.Interop.PipelineCache), createInfoCount, marshalledCreateInfos, marshalledAllocator, marshalledPipelines);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                if (marshalledPipelines != null)
                {
                    var fieldPointer = new SharpVk.Pipeline[(uint)(createInfoCount)];
                    for(int index = 0; index < (uint)(createInfoCount); index++)
                    {
                        fieldPointer[index] = new SharpVk.Pipeline(this, marshalledPipelines[index]);
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Creates a new pipeline layout object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.PipelineLayout CreatePipelineLayout(ArrayProxy<SharpVk.DescriptorSetLayout>? setLayouts, ArrayProxy<SharpVk.PushConstantRange>? pushConstantRanges, SharpVk.PipelineLayoutCreateFlags? flags = default(SharpVk.PipelineLayoutCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.PipelineLayout result = default(SharpVk.PipelineLayout);
                SharpVk.Interop.PipelineLayoutCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.PipelineLayoutCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.PipelineLayout marshalledPipelineLayout = default(SharpVk.Interop.PipelineLayout);
                marshalledCreateInfo = (SharpVk.Interop.PipelineLayoutCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PipelineLayoutCreateInfo>());
                marshalledCreateInfo->SType = StructureType.PipelineLayoutCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.PipelineLayoutCreateFlags);
                }
                marshalledCreateInfo->SetLayoutCount = (uint)(Interop.HeapUtil.GetLength(setLayouts));
                if (setLayouts.IsNull())
                {
                    marshalledCreateInfo->SetLayouts = null;
                }
                else
                {
                    if (setLayouts.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->SetLayouts = (SharpVk.Interop.DescriptorSetLayout*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DescriptorSetLayout>());
                        *(SharpVk.Interop.DescriptorSetLayout*)(marshalledCreateInfo->SetLayouts) = setLayouts.Value.GetSingleValue()?.handle ?? default(SharpVk.Interop.DescriptorSetLayout);
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.DescriptorSetLayout*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.DescriptorSetLayout>(Interop.HeapUtil.GetLength(setLayouts.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(setLayouts.Value)); index++)
                        {
                            fieldPointer[index] = setLayouts.Value[index]?.handle ?? default(SharpVk.Interop.DescriptorSetLayout);
                        }
                        marshalledCreateInfo->SetLayouts = fieldPointer;
                    }
                }
                marshalledCreateInfo->PushConstantRangeCount = (uint)(Interop.HeapUtil.GetLength(pushConstantRanges));
                if (pushConstantRanges.IsNull())
                {
                    marshalledCreateInfo->PushConstantRanges = null;
                }
                else
                {
                    if (pushConstantRanges.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->PushConstantRanges = (SharpVk.PushConstantRange*)(Interop.HeapUtil.Allocate<SharpVk.PushConstantRange>());
                        *(SharpVk.PushConstantRange*)(marshalledCreateInfo->PushConstantRanges) = pushConstantRanges.Value.GetSingleValue();
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.PushConstantRange*)(Interop.HeapUtil.AllocateAndClear<SharpVk.PushConstantRange>(Interop.HeapUtil.GetLength(pushConstantRanges.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(pushConstantRanges.Value)); index++)
                        {
                            fieldPointer[index] = pushConstantRanges.Value[index];
                        }
                        marshalledCreateInfo->PushConstantRanges = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreatePipelineLayout(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledPipelineLayout);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.PipelineLayout(this, marshalledPipelineLayout);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new sampler object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="magFilter">
        /// The magnification filter to apply to lookups.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Sampler CreateSampler(SharpVk.Filter magFilter, SharpVk.Filter minFilter, SharpVk.SamplerMipmapMode mipmapMode, SharpVk.SamplerAddressMode addressModeU, SharpVk.SamplerAddressMode addressModeV, SharpVk.SamplerAddressMode addressModeW, float mipLodBias, bool anisotropyEnable, float maxAnisotropy, bool compareEnable, SharpVk.CompareOp compareOp, float minLod, float maxLod, SharpVk.BorderColor borderColor, bool unnormalizedCoordinates, SharpVk.SamplerCreateFlags? flags = default(SharpVk.SamplerCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Sampler result = default(SharpVk.Sampler);
                SharpVk.Interop.SamplerCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.SamplerCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Sampler marshalledSampler = default(SharpVk.Interop.Sampler);
                marshalledCreateInfo = (SharpVk.Interop.SamplerCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.SamplerCreateInfo>());
                marshalledCreateInfo->SType = StructureType.SamplerCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.SamplerCreateFlags);
                }
                marshalledCreateInfo->MagFilter = magFilter;
                marshalledCreateInfo->MinFilter = minFilter;
                marshalledCreateInfo->MipmapMode = mipmapMode;
                marshalledCreateInfo->AddressModeU = addressModeU;
                marshalledCreateInfo->AddressModeV = addressModeV;
                marshalledCreateInfo->AddressModeW = addressModeW;
                marshalledCreateInfo->MipLodBias = mipLodBias;
                marshalledCreateInfo->AnisotropyEnable = anisotropyEnable;
                marshalledCreateInfo->MaxAnisotropy = maxAnisotropy;
                marshalledCreateInfo->CompareEnable = compareEnable;
                marshalledCreateInfo->CompareOp = compareOp;
                marshalledCreateInfo->MinLod = minLod;
                marshalledCreateInfo->MaxLod = maxLod;
                marshalledCreateInfo->BorderColor = borderColor;
                marshalledCreateInfo->UnnormalizedCoordinates = unnormalizedCoordinates;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateSampler(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSampler);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Sampler(this, marshalledSampler);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new descriptor set layout.
        /// </summary>
        /// <param name="flags">
        /// flags provides options for descriptor set layout creation, and is
        /// of type DescriptorSetLayoutCreateFlags. Bits which can be set
        /// include: + --
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.DescriptorSetLayout CreateDescriptorSetLayout(ArrayProxy<SharpVk.DescriptorSetLayoutBinding>? bindings, SharpVk.DescriptorSetLayoutCreateFlags? flags = default(SharpVk.DescriptorSetLayoutCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.DescriptorSetLayout result = default(SharpVk.DescriptorSetLayout);
                SharpVk.Interop.DescriptorSetLayoutCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.DescriptorSetLayoutCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.DescriptorSetLayout marshalledSetLayout = default(SharpVk.Interop.DescriptorSetLayout);
                marshalledCreateInfo = (SharpVk.Interop.DescriptorSetLayoutCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DescriptorSetLayoutCreateInfo>());
                marshalledCreateInfo->SType = StructureType.DescriptorSetLayoutCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.DescriptorSetLayoutCreateFlags);
                }
                marshalledCreateInfo->BindingCount = (uint)(Interop.HeapUtil.GetLength(bindings));
                if (bindings.IsNull())
                {
                    marshalledCreateInfo->Bindings = null;
                }
                else
                {
                    if (bindings.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->Bindings = (SharpVk.Interop.DescriptorSetLayoutBinding*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DescriptorSetLayoutBinding>());
                        bindings.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.DescriptorSetLayoutBinding*)(marshalledCreateInfo->Bindings));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.DescriptorSetLayoutBinding*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.DescriptorSetLayoutBinding>(Interop.HeapUtil.GetLength(bindings.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(bindings.Value)); index++)
                        {
                            bindings.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledCreateInfo->Bindings = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateDescriptorSetLayout(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSetLayout);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.DescriptorSetLayout(this, marshalledSetLayout);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Creates a descriptor pool object.
        /// </summary>
        /// <param name="flags">
        /// Specifies certain supported operations on the pool. Bits which can
        /// be set include: + --
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.DescriptorPool CreateDescriptorPool(uint maxSets, ArrayProxy<SharpVk.DescriptorPoolSize>? poolSizes, SharpVk.DescriptorPoolCreateFlags? flags = default(SharpVk.DescriptorPoolCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.DescriptorPool result = default(SharpVk.DescriptorPool);
                SharpVk.Interop.DescriptorPoolCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.DescriptorPoolCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.DescriptorPool marshalledDescriptorPool = default(SharpVk.Interop.DescriptorPool);
                marshalledCreateInfo = (SharpVk.Interop.DescriptorPoolCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DescriptorPoolCreateInfo>());
                marshalledCreateInfo->SType = StructureType.DescriptorPoolCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.DescriptorPoolCreateFlags);
                }
                marshalledCreateInfo->MaxSets = maxSets;
                marshalledCreateInfo->PoolSizeCount = (uint)(Interop.HeapUtil.GetLength(poolSizes));
                if (poolSizes.IsNull())
                {
                    marshalledCreateInfo->PoolSizes = null;
                }
                else
                {
                    if (poolSizes.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->PoolSizes = (SharpVk.DescriptorPoolSize*)(Interop.HeapUtil.Allocate<SharpVk.DescriptorPoolSize>());
                        *(SharpVk.DescriptorPoolSize*)(marshalledCreateInfo->PoolSizes) = poolSizes.Value.GetSingleValue();
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.DescriptorPoolSize*)(Interop.HeapUtil.AllocateAndClear<SharpVk.DescriptorPoolSize>(Interop.HeapUtil.GetLength(poolSizes.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(poolSizes.Value)); index++)
                        {
                            fieldPointer[index] = poolSizes.Value[index];
                        }
                        marshalledCreateInfo->PoolSizes = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateDescriptorPool(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledDescriptorPool);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.DescriptorPool(this, marshalledDescriptorPool);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Allocate one or more descriptor sets.
        /// </summary>
        /// <param name="descriptorPool">
        /// The pool which the sets will be allocated from.
        /// </param>
        public unsafe SharpVk.DescriptorSet[] AllocateDescriptorSets(SharpVk.DescriptorPool descriptorPool, ArrayProxy<SharpVk.DescriptorSetLayout>? setLayouts)
        {
            try
            {
                SharpVk.DescriptorSet[] result = default(SharpVk.DescriptorSet[]);
                SharpVk.Interop.DescriptorSetAllocateInfo* marshalledAllocateInfo = default(SharpVk.Interop.DescriptorSetAllocateInfo*);
                SharpVk.Interop.DescriptorSet* marshalledDescriptorSets = default(SharpVk.Interop.DescriptorSet*);
                marshalledAllocateInfo = (SharpVk.Interop.DescriptorSetAllocateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DescriptorSetAllocateInfo>());
                marshalledAllocateInfo->SType = StructureType.DescriptorSetAllocateInfo;
                marshalledAllocateInfo->Next = null;
                marshalledAllocateInfo->DescriptorPool = descriptorPool?.handle ?? default(SharpVk.Interop.DescriptorPool);
                marshalledAllocateInfo->DescriptorSetCount = (uint)(Interop.HeapUtil.GetLength(setLayouts));
                if (setLayouts.IsNull())
                {
                    marshalledAllocateInfo->SetLayouts = null;
                }
                else
                {
                    if (setLayouts.Value.Contents == ProxyContents.Single)
                    {
                        marshalledAllocateInfo->SetLayouts = (SharpVk.Interop.DescriptorSetLayout*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DescriptorSetLayout>());
                        *(SharpVk.Interop.DescriptorSetLayout*)(marshalledAllocateInfo->SetLayouts) = setLayouts.Value.GetSingleValue()?.handle ?? default(SharpVk.Interop.DescriptorSetLayout);
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.DescriptorSetLayout*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.DescriptorSetLayout>(Interop.HeapUtil.GetLength(setLayouts.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(setLayouts.Value)); index++)
                        {
                            fieldPointer[index] = setLayouts.Value[index]?.handle ?? default(SharpVk.Interop.DescriptorSetLayout);
                        }
                        marshalledAllocateInfo->SetLayouts = fieldPointer;
                    }
                }
                marshalledDescriptorSets = (SharpVk.Interop.DescriptorSet*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DescriptorSet>(Interop.HeapUtil.GetLength(setLayouts)));
                Result methodResult = Interop.Commands.vkAllocateDescriptorSets(this.handle, marshalledAllocateInfo, marshalledDescriptorSets);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                if (marshalledDescriptorSets != null)
                {
                    var fieldPointer = new SharpVk.DescriptorSet[(uint)(Interop.HeapUtil.GetLength(setLayouts))];
                    for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(setLayouts)); index++)
                    {
                        fieldPointer[index] = new SharpVk.DescriptorSet(descriptorPool, marshalledDescriptorSets[index]);
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Update the contents of a descriptor set object.
        /// </summary>
        public unsafe void UpdateDescriptorSets(ArrayProxy<SharpVk.WriteDescriptorSet>? descriptorWrites, ArrayProxy<SharpVk.CopyDescriptorSet>? descriptorCopies)
        {
            try
            {
                SharpVk.Interop.WriteDescriptorSet* marshalledDescriptorWrites = default(SharpVk.Interop.WriteDescriptorSet*);
                SharpVk.Interop.CopyDescriptorSet* marshalledDescriptorCopies = default(SharpVk.Interop.CopyDescriptorSet*);
                if (descriptorWrites.IsNull())
                {
                    marshalledDescriptorWrites = null;
                }
                else
                {
                    if (descriptorWrites.Value.Contents == ProxyContents.Single)
                    {
                        marshalledDescriptorWrites = (SharpVk.Interop.WriteDescriptorSet*)(Interop.HeapUtil.Allocate<SharpVk.Interop.WriteDescriptorSet>());
                        descriptorWrites.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.WriteDescriptorSet*)(marshalledDescriptorWrites));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.WriteDescriptorSet*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.WriteDescriptorSet>(Interop.HeapUtil.GetLength(descriptorWrites.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(descriptorWrites.Value)); index++)
                        {
                            descriptorWrites.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledDescriptorWrites = fieldPointer;
                    }
                }
                if (descriptorCopies.IsNull())
                {
                    marshalledDescriptorCopies = null;
                }
                else
                {
                    if (descriptorCopies.Value.Contents == ProxyContents.Single)
                    {
                        marshalledDescriptorCopies = (SharpVk.Interop.CopyDescriptorSet*)(Interop.HeapUtil.Allocate<SharpVk.Interop.CopyDescriptorSet>());
                        descriptorCopies.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.CopyDescriptorSet*)(marshalledDescriptorCopies));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.CopyDescriptorSet*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.CopyDescriptorSet>(Interop.HeapUtil.GetLength(descriptorCopies.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(descriptorCopies.Value)); index++)
                        {
                            descriptorCopies.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledDescriptorCopies = fieldPointer;
                    }
                }
                Interop.Commands.vkUpdateDescriptorSets(this.handle, (uint)(Interop.HeapUtil.GetLength(descriptorWrites)), marshalledDescriptorWrites, (uint)(Interop.HeapUtil.GetLength(descriptorCopies)), marshalledDescriptorCopies);
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new framebuffer object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="renderPass">
        /// A render pass that defines what render passes the framebuffer will
        /// be compatible with. See Render Pass Compatibility for details.
        /// </param>
        /// <param name="width">
        /// width, height and layers define the dimensions of the framebuffer.
        /// If the render pass uses multiview, then layers must be one and each
        /// attachment requires a number of layers that is greater than the
        /// maximum bit index set in the view mask in the subpasses in which it
        /// is used.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Framebuffer CreateFramebuffer(SharpVk.RenderPass renderPass, ArrayProxy<SharpVk.ImageView>? attachments, uint width, uint height, uint layers, SharpVk.FramebufferCreateFlags? flags = default(SharpVk.FramebufferCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Framebuffer result = default(SharpVk.Framebuffer);
                SharpVk.Interop.FramebufferCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.FramebufferCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Framebuffer marshalledFramebuffer = default(SharpVk.Interop.Framebuffer);
                marshalledCreateInfo = (SharpVk.Interop.FramebufferCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.FramebufferCreateInfo>());
                marshalledCreateInfo->SType = StructureType.FramebufferCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.FramebufferCreateFlags);
                }
                marshalledCreateInfo->RenderPass = renderPass?.handle ?? default(SharpVk.Interop.RenderPass);
                marshalledCreateInfo->AttachmentCount = (uint)(Interop.HeapUtil.GetLength(attachments));
                if (attachments.IsNull())
                {
                    marshalledCreateInfo->Attachments = null;
                }
                else
                {
                    if (attachments.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->Attachments = (SharpVk.Interop.ImageView*)(Interop.HeapUtil.Allocate<SharpVk.Interop.ImageView>());
                        *(SharpVk.Interop.ImageView*)(marshalledCreateInfo->Attachments) = attachments.Value.GetSingleValue()?.handle ?? default(SharpVk.Interop.ImageView);
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.ImageView*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.ImageView>(Interop.HeapUtil.GetLength(attachments.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(attachments.Value)); index++)
                        {
                            fieldPointer[index] = attachments.Value[index]?.handle ?? default(SharpVk.Interop.ImageView);
                        }
                        marshalledCreateInfo->Attachments = fieldPointer;
                    }
                }
                marshalledCreateInfo->Width = width;
                marshalledCreateInfo->Height = height;
                marshalledCreateInfo->Layers = layers;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateFramebuffer(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledFramebuffer);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Framebuffer(this, marshalledFramebuffer);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new render pass object.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.RenderPass CreateRenderPass(ArrayProxy<SharpVk.AttachmentDescription>? attachments, ArrayProxy<SharpVk.SubpassDescription>? subpasses, ArrayProxy<SharpVk.SubpassDependency>? dependencies, SharpVk.RenderPassCreateFlags? flags = default(SharpVk.RenderPassCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.RenderPass result = default(SharpVk.RenderPass);
                SharpVk.Interop.RenderPassCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.RenderPassCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.RenderPass marshalledRenderPass = default(SharpVk.Interop.RenderPass);
                marshalledCreateInfo = (SharpVk.Interop.RenderPassCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.RenderPassCreateInfo>());
                marshalledCreateInfo->SType = StructureType.RenderPassCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.RenderPassCreateFlags);
                }
                marshalledCreateInfo->AttachmentCount = (uint)(Interop.HeapUtil.GetLength(attachments));
                if (attachments.IsNull())
                {
                    marshalledCreateInfo->Attachments = null;
                }
                else
                {
                    if (attachments.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->Attachments = (SharpVk.AttachmentDescription*)(Interop.HeapUtil.Allocate<SharpVk.AttachmentDescription>());
                        *(SharpVk.AttachmentDescription*)(marshalledCreateInfo->Attachments) = attachments.Value.GetSingleValue();
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.AttachmentDescription*)(Interop.HeapUtil.AllocateAndClear<SharpVk.AttachmentDescription>(Interop.HeapUtil.GetLength(attachments.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(attachments.Value)); index++)
                        {
                            fieldPointer[index] = attachments.Value[index];
                        }
                        marshalledCreateInfo->Attachments = fieldPointer;
                    }
                }
                marshalledCreateInfo->SubpassCount = (uint)(Interop.HeapUtil.GetLength(subpasses));
                if (subpasses.IsNull())
                {
                    marshalledCreateInfo->Subpasses = null;
                }
                else
                {
                    if (subpasses.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->Subpasses = (SharpVk.Interop.SubpassDescription*)(Interop.HeapUtil.Allocate<SharpVk.Interop.SubpassDescription>());
                        subpasses.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.SubpassDescription*)(marshalledCreateInfo->Subpasses));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.SubpassDescription*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.SubpassDescription>(Interop.HeapUtil.GetLength(subpasses.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(subpasses.Value)); index++)
                        {
                            subpasses.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledCreateInfo->Subpasses = fieldPointer;
                    }
                }
                marshalledCreateInfo->DependencyCount = (uint)(Interop.HeapUtil.GetLength(dependencies));
                if (dependencies.IsNull())
                {
                    marshalledCreateInfo->Dependencies = null;
                }
                else
                {
                    if (dependencies.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->Dependencies = (SharpVk.SubpassDependency*)(Interop.HeapUtil.Allocate<SharpVk.SubpassDependency>());
                        *(SharpVk.SubpassDependency*)(marshalledCreateInfo->Dependencies) = dependencies.Value.GetSingleValue();
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.SubpassDependency*)(Interop.HeapUtil.AllocateAndClear<SharpVk.SubpassDependency>(Interop.HeapUtil.GetLength(dependencies.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(dependencies.Value)); index++)
                        {
                            fieldPointer[index] = dependencies.Value[index];
                        }
                        marshalledCreateInfo->Dependencies = fieldPointer;
                    }
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateRenderPass(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledRenderPass);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.RenderPass(this, marshalledRenderPass);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new command pool object.
        /// </summary>
        /// <param name="flags">
        /// A bitmask indicating usage behavior for the pool and command
        /// buffers allocated from it. Bits which can be set include: + --
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.CommandPool CreateCommandPool(uint queueFamilyIndex, SharpVk.CommandPoolCreateFlags? flags = default(SharpVk.CommandPoolCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.CommandPool result = default(SharpVk.CommandPool);
                SharpVk.Interop.CommandPoolCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.CommandPoolCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.CommandPool marshalledCommandPool = default(SharpVk.Interop.CommandPool);
                marshalledCreateInfo = (SharpVk.Interop.CommandPoolCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.CommandPoolCreateInfo>());
                marshalledCreateInfo->SType = StructureType.CommandPoolCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.CommandPoolCreateFlags);
                }
                marshalledCreateInfo->QueueFamilyIndex = queueFamilyIndex;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                Result methodResult = Interop.Commands.vkCreateCommandPool(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledCommandPool);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.CommandPool(this, marshalledCommandPool);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Allocate command buffers from an existing command pool.
        /// </summary>
        /// <param name="commandPool">
        /// The command pool from which the command buffers are allocated.
        /// </param>
        /// <param name="level">
        /// level determines whether the command buffers are primary or
        /// secondary command buffers. Possible values include: + --
        /// </param>
        public unsafe SharpVk.CommandBuffer[] AllocateCommandBuffers(SharpVk.CommandPool commandPool, SharpVk.CommandBufferLevel level, uint commandBufferCount)
        {
            try
            {
                SharpVk.CommandBuffer[] result = default(SharpVk.CommandBuffer[]);
                SharpVk.Interop.CommandBufferAllocateInfo* marshalledAllocateInfo = default(SharpVk.Interop.CommandBufferAllocateInfo*);
                SharpVk.Interop.CommandBuffer* marshalledCommandBuffers = default(SharpVk.Interop.CommandBuffer*);
                marshalledAllocateInfo = (SharpVk.Interop.CommandBufferAllocateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.CommandBufferAllocateInfo>());
                marshalledAllocateInfo->SType = StructureType.CommandBufferAllocateInfo;
                marshalledAllocateInfo->Next = null;
                marshalledAllocateInfo->CommandPool = commandPool?.handle ?? default(SharpVk.Interop.CommandPool);
                marshalledAllocateInfo->Level = level;
                marshalledAllocateInfo->CommandBufferCount = commandBufferCount;
                marshalledCommandBuffers = (SharpVk.Interop.CommandBuffer*)(Interop.HeapUtil.Allocate<SharpVk.Interop.CommandBuffer>(commandBufferCount));
                Result methodResult = Interop.Commands.vkAllocateCommandBuffers(this.handle, marshalledAllocateInfo, marshalledCommandBuffers);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                if (marshalledCommandBuffers != null)
                {
                    var fieldPointer = new SharpVk.CommandBuffer[(uint)(commandBufferCount)];
                    for(int index = 0; index < (uint)(commandBufferCount); index++)
                    {
                        fieldPointer[index] = new SharpVk.CommandBuffer(commandPool, marshalledCommandBuffers[index]);
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
    }
}
