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
    /// Opaque handle to a physical device object.
    /// </summary>
    public partial class PhysicalDevice
    {
        internal readonly SharpVk.Interop.PhysicalDevice handle; 
        
        internal readonly CommandCache commandCache; 
        
        internal readonly SharpVk.Instance parent; 
        
        internal PhysicalDevice(SharpVk.Instance parent, SharpVk.Interop.PhysicalDevice handle)
        {
            this.handle = handle;
            this.parent = parent;
            this.commandCache = parent.commandCache;
        }
        
        /// <summary>
        /// Returns properties of a physical device.
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceProperties GetProperties()
        {
            try
            {
                SharpVk.PhysicalDeviceProperties result = default(SharpVk.PhysicalDeviceProperties);
                SharpVk.Interop.PhysicalDeviceProperties marshalledProperties = default(SharpVk.Interop.PhysicalDeviceProperties);
                Interop.Commands.vkGetPhysicalDeviceProperties(this.handle, &marshalledProperties);
                result = SharpVk.PhysicalDeviceProperties.MarshalFrom(&marshalledProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Reports properties of the queues of the specified physical device.
        /// </summary>
        public unsafe SharpVk.QueueFamilyProperties[] GetQueueFamilyProperties()
        {
            try
            {
                SharpVk.QueueFamilyProperties[] result = default(SharpVk.QueueFamilyProperties[]);
                uint queueFamilyPropertyCount = default(uint);
                SharpVk.QueueFamilyProperties* marshalledQueueFamilyProperties = default(SharpVk.QueueFamilyProperties*);
                Interop.Commands.vkGetPhysicalDeviceQueueFamilyProperties(this.handle, &queueFamilyPropertyCount, marshalledQueueFamilyProperties);
                marshalledQueueFamilyProperties = (SharpVk.QueueFamilyProperties*)(Interop.HeapUtil.Allocate<SharpVk.QueueFamilyProperties>((uint)(queueFamilyPropertyCount)));
                Interop.Commands.vkGetPhysicalDeviceQueueFamilyProperties(this.handle, &queueFamilyPropertyCount, marshalledQueueFamilyProperties);
                if (marshalledQueueFamilyProperties != null)
                {
                    var fieldPointer = new SharpVk.QueueFamilyProperties[(uint)(queueFamilyPropertyCount)];
                    for(int index = 0; index < (uint)(queueFamilyPropertyCount); index++)
                    {
                        fieldPointer[index] = marshalledQueueFamilyProperties[index];
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
        /// Reports memory information for the specified physical device.
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceMemoryProperties GetMemoryProperties()
        {
            try
            {
                SharpVk.PhysicalDeviceMemoryProperties result = default(SharpVk.PhysicalDeviceMemoryProperties);
                SharpVk.Interop.PhysicalDeviceMemoryProperties marshalledMemoryProperties = default(SharpVk.Interop.PhysicalDeviceMemoryProperties);
                Interop.Commands.vkGetPhysicalDeviceMemoryProperties(this.handle, &marshalledMemoryProperties);
                result = SharpVk.PhysicalDeviceMemoryProperties.MarshalFrom(&marshalledMemoryProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Reports capabilities of a physical device.
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceFeatures GetFeatures()
        {
            try
            {
                SharpVk.PhysicalDeviceFeatures result = default(SharpVk.PhysicalDeviceFeatures);
                SharpVk.Interop.PhysicalDeviceFeatures marshalledFeatures = default(SharpVk.Interop.PhysicalDeviceFeatures);
                Interop.Commands.vkGetPhysicalDeviceFeatures(this.handle, &marshalledFeatures);
                result = SharpVk.PhysicalDeviceFeatures.MarshalFrom(&marshalledFeatures);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Lists physical device's format capabilities.
        /// </summary>
        public unsafe SharpVk.FormatProperties GetFormatProperties(SharpVk.Format format)
        {
            try
            {
                SharpVk.FormatProperties result = default(SharpVk.FormatProperties);
                SharpVk.FormatProperties marshalledFormatProperties = default(SharpVk.FormatProperties);
                Interop.Commands.vkGetPhysicalDeviceFormatProperties(this.handle, format, &marshalledFormatProperties);
                result = marshalledFormatProperties;
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Lists physical device's image format capabilities.
        /// </summary>
        public unsafe SharpVk.ImageFormatProperties GetImageFormatProperties(SharpVk.Format format, SharpVk.ImageType type, SharpVk.ImageTiling tiling, SharpVk.ImageUsageFlags usage, SharpVk.ImageCreateFlags? flags = default(SharpVk.ImageCreateFlags?))
        {
            try
            {
                SharpVk.ImageFormatProperties result = default(SharpVk.ImageFormatProperties);
                SharpVk.ImageCreateFlags marshalledFlags = default(SharpVk.ImageCreateFlags);
                SharpVk.ImageFormatProperties marshalledImageFormatProperties = default(SharpVk.ImageFormatProperties);
                if (flags != null)
                {
                    marshalledFlags = flags.Value;
                }
                else
                {
                    marshalledFlags = default(SharpVk.ImageCreateFlags);
                }
                Result methodResult = Interop.Commands.vkGetPhysicalDeviceImageFormatProperties(this.handle, format, type, tiling, usage, marshalledFlags, &marshalledImageFormatProperties);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = marshalledImageFormatProperties;
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new device instance.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="enabledLayerNames">
        /// ppEnabledLayerNames is deprecated and ignored. See Device Layer
        /// Deprecation.
        /// </param>
        /// <param name="enabledExtensionNames">
        /// An array of enabledExtensionCount strings containing the names of
        /// extensions to enable for the created device. See the Extensions
        /// section for further details.
        /// </param>
        /// <param name="enabledFeatures">
        /// Null or a PhysicalDeviceFeatures structure that contains boolean
        /// indicators of all the features to be enabled. Refer to the Features
        /// section for further details.
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Device CreateDevice(ArrayProxy<SharpVk.DeviceQueueCreateInfo>? queueCreateInfos, ArrayProxy<string>? enabledLayerNames, ArrayProxy<string>? enabledExtensionNames, SharpVk.DeviceCreateFlags? flags = default(SharpVk.DeviceCreateFlags?), SharpVk.PhysicalDeviceFeatures? enabledFeatures = default(SharpVk.PhysicalDeviceFeatures?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Device result = default(SharpVk.Device);
                SharpVk.Interop.DeviceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.DeviceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Device marshalledDevice = default(SharpVk.Interop.Device);
                marshalledCreateInfo = (SharpVk.Interop.DeviceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DeviceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.DeviceCreateInfo;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.DeviceCreateFlags);
                }
                marshalledCreateInfo->QueueCreateInfoCount = (uint)(Interop.HeapUtil.GetLength(queueCreateInfos));
                if (queueCreateInfos.IsNull())
                {
                    marshalledCreateInfo->QueueCreateInfos = null;
                }
                else
                {
                    if (queueCreateInfos.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->QueueCreateInfos = (SharpVk.Interop.DeviceQueueCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DeviceQueueCreateInfo>());
                        queueCreateInfos.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.DeviceQueueCreateInfo*)(marshalledCreateInfo->QueueCreateInfos));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.DeviceQueueCreateInfo*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.DeviceQueueCreateInfo>(Interop.HeapUtil.GetLength(queueCreateInfos.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(queueCreateInfos.Value)); index++)
                        {
                            queueCreateInfos.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledCreateInfo->QueueCreateInfos = fieldPointer;
                    }
                }
                marshalledCreateInfo->EnabledLayerCount = (uint)(Interop.HeapUtil.GetLength(enabledLayerNames));
                marshalledCreateInfo->EnabledLayerNames = Interop.HeapUtil.MarshalTo(enabledLayerNames);
                marshalledCreateInfo->EnabledExtensionCount = (uint)(Interop.HeapUtil.GetLength(enabledExtensionNames));
                marshalledCreateInfo->EnabledExtensionNames = Interop.HeapUtil.MarshalTo(enabledExtensionNames);
                if (enabledFeatures != null)
                {
                    marshalledCreateInfo->EnabledFeatures = (SharpVk.Interop.PhysicalDeviceFeatures*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PhysicalDeviceFeatures>());
                    enabledFeatures.Value.MarshalTo(marshalledCreateInfo->EnabledFeatures);
                }
                else
                {
                    marshalledCreateInfo->EnabledFeatures = default(SharpVk.Interop.PhysicalDeviceFeatures*);
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
                Result methodResult = Interop.Commands.vkCreateDevice(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledDevice);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Device(this, marshalledDevice);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Returns properties of available physical device layers.
        /// </summary>
        public unsafe SharpVk.LayerProperties[] EnumerateDeviceLayerProperties()
        {
            try
            {
                SharpVk.LayerProperties[] result = default(SharpVk.LayerProperties[]);
                uint propertyCount = default(uint);
                SharpVk.Interop.LayerProperties* marshalledProperties = default(SharpVk.Interop.LayerProperties*);
                Result methodResult = Interop.Commands.vkEnumerateDeviceLayerProperties(this.handle, &propertyCount, marshalledProperties);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                marshalledProperties = (SharpVk.Interop.LayerProperties*)(Interop.HeapUtil.Allocate<SharpVk.Interop.LayerProperties>((uint)(propertyCount)));
                Interop.Commands.vkEnumerateDeviceLayerProperties(this.handle, &propertyCount, marshalledProperties);
                if (marshalledProperties != null)
                {
                    var fieldPointer = new SharpVk.LayerProperties[(uint)(propertyCount)];
                    for(int index = 0; index < (uint)(propertyCount); index++)
                    {
                        fieldPointer[index] = SharpVk.LayerProperties.MarshalFrom(&marshalledProperties[index]);
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
        /// Returns properties of available physical device extensions.
        /// </summary>
        public unsafe SharpVk.ExtensionProperties[] EnumerateDeviceExtensionProperties(string layerName)
        {
            try
            {
                SharpVk.ExtensionProperties[] result = default(SharpVk.ExtensionProperties[]);
                uint propertyCount = default(uint);
                SharpVk.Interop.ExtensionProperties* marshalledProperties = default(SharpVk.Interop.ExtensionProperties*);
                Result methodResult = Interop.Commands.vkEnumerateDeviceExtensionProperties(this.handle, Interop.HeapUtil.MarshalTo(layerName), &propertyCount, marshalledProperties);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                marshalledProperties = (SharpVk.Interop.ExtensionProperties*)(Interop.HeapUtil.Allocate<SharpVk.Interop.ExtensionProperties>((uint)(propertyCount)));
                Interop.Commands.vkEnumerateDeviceExtensionProperties(this.handle, Interop.HeapUtil.MarshalTo(layerName), &propertyCount, marshalledProperties);
                if (marshalledProperties != null)
                {
                    var fieldPointer = new SharpVk.ExtensionProperties[(uint)(propertyCount)];
                    for(int index = 0; index < (uint)(propertyCount); index++)
                    {
                        fieldPointer[index] = SharpVk.ExtensionProperties.MarshalFrom(&marshalledProperties[index]);
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
        /// Retrieve properties of an image format applied to sparse images.
        /// </summary>
        public unsafe SharpVk.SparseImageFormatProperties[] GetSparseImageFormatProperties(SharpVk.Format format, SharpVk.ImageType type, SharpVk.SampleCountFlags samples, SharpVk.ImageUsageFlags usage, SharpVk.ImageTiling tiling)
        {
            try
            {
                SharpVk.SparseImageFormatProperties[] result = default(SharpVk.SparseImageFormatProperties[]);
                uint propertyCount = default(uint);
                SharpVk.SparseImageFormatProperties* marshalledProperties = default(SharpVk.SparseImageFormatProperties*);
                Interop.Commands.vkGetPhysicalDeviceSparseImageFormatProperties(this.handle, format, type, samples, usage, tiling, &propertyCount, marshalledProperties);
                marshalledProperties = (SharpVk.SparseImageFormatProperties*)(Interop.HeapUtil.Allocate<SharpVk.SparseImageFormatProperties>((uint)(propertyCount)));
                Interop.Commands.vkGetPhysicalDeviceSparseImageFormatProperties(this.handle, format, type, samples, usage, tiling, &propertyCount, marshalledProperties);
                if (marshalledProperties != null)
                {
                    var fieldPointer = new SharpVk.SparseImageFormatProperties[(uint)(propertyCount)];
                    for(int index = 0; index < (uint)(propertyCount); index++)
                    {
                        fieldPointer[index] = marshalledProperties[index];
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
