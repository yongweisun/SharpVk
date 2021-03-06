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

namespace SharpVk
{
    /// <summary>
    /// <para>
    /// Opaque handle to a physical device object.
    /// </para>
    /// <para>
    /// Vulkan separates the concept of _physical_ and _logical_ devices. A
    /// physical device usually represents a single device in a system (perhaps
    /// made up of several individual hardware devices working together), of
    /// which there are a finite number. A logical device represents an
    /// application's view of the device.
    /// </para>
    /// </summary>
    public partial class PhysicalDevice
    {
        internal readonly Interop.PhysicalDevice handle; 
        
        internal readonly CommandCache commandCache; 
        
        private readonly Instance parent; 
        
        internal AllocationCallbacks? Allocator
        {
            get
            {
                return this.parent.Allocator;
            }
        }
        
        internal PhysicalDevice(Interop.PhysicalDevice handle, Instance parent, CommandCache commandCache)
        {
            this.handle = handle;
            this.parent = parent;
            this.commandCache = commandCache;
        }
        
        /// <summary>
        /// Reports capabilities of a physical device.
        /// </summary>
        public PhysicalDeviceFeatures GetFeatures()
        {
            unsafe
            {
                try
                {
                    PhysicalDeviceFeatures result = default(PhysicalDeviceFeatures);
                    Interop.Commands.vkGetPhysicalDeviceFeatures(this.handle, &result);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Lists physical device's format capabilities.
        /// </summary>
        public FormatProperties GetFormatProperties(Format format)
        {
            unsafe
            {
                try
                {
                    FormatProperties result = default(FormatProperties);
                    Interop.Commands.vkGetPhysicalDeviceFormatProperties(this.handle, format, &result);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Lists physical device's image format capabilities.
        /// </summary>
        public ImageFormatProperties GetImageFormatProperties(Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags)
        {
            unsafe
            {
                try
                {
                    ImageFormatProperties result = default(ImageFormatProperties);
                    Result commandResult;
                    commandResult = Interop.Commands.vkGetPhysicalDeviceImageFormatProperties(this.handle, format, type, tiling, usage, flags, &result);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Returns properties of a physical device.
        /// </summary>
        public PhysicalDeviceProperties GetProperties()
        {
            unsafe
            {
                try
                {
                    PhysicalDeviceProperties result = default(PhysicalDeviceProperties);
                    Interop.PhysicalDeviceProperties marshalledProperties;
                    Interop.Commands.vkGetPhysicalDeviceProperties(this.handle, &marshalledProperties);
                    result = PhysicalDeviceProperties.MarshalFrom(&marshalledProperties);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Reports properties of the queues of the specified physical device.
        /// </summary>
        public QueueFamilyProperties[] GetQueueFamilyProperties()
        {
            unsafe
            {
                try
                {
                    QueueFamilyProperties[] result = default(QueueFamilyProperties[]);
                    uint queueFamilyPropertyCount;
                    QueueFamilyProperties* marshalledQueueFamilyProperties = null;
                    Interop.Commands.vkGetPhysicalDeviceQueueFamilyProperties(this.handle, &queueFamilyPropertyCount, null);
                    marshalledQueueFamilyProperties = (QueueFamilyProperties*)Interop.HeapUtil.Allocate<QueueFamilyProperties>((uint)queueFamilyPropertyCount);
                    Interop.Commands.vkGetPhysicalDeviceQueueFamilyProperties(this.handle, &queueFamilyPropertyCount, marshalledQueueFamilyProperties);
                    result = new QueueFamilyProperties[(uint)queueFamilyPropertyCount];
                    for(int index = 0; index < (uint)queueFamilyPropertyCount; index++)
                    {
                    	result[index] = marshalledQueueFamilyProperties[index];
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Reports memory information for the specified physical device.
        /// </summary>
        public PhysicalDeviceMemoryProperties GetMemoryProperties()
        {
            unsafe
            {
                try
                {
                    PhysicalDeviceMemoryProperties result = default(PhysicalDeviceMemoryProperties);
                    Interop.PhysicalDeviceMemoryProperties marshalledMemoryProperties;
                    Interop.Commands.vkGetPhysicalDeviceMemoryProperties(this.handle, &marshalledMemoryProperties);
                    result = PhysicalDeviceMemoryProperties.MarshalFrom(&marshalledMemoryProperties);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Create a new device instance.
        /// </summary>
        public Device CreateDevice(DeviceCreateInfo createInfo)
        {
            unsafe
            {
                try
                {
                    Device result = default(Device);
                    Result commandResult;
                    Interop.DeviceCreateInfo marshalledCreateInfo;
                    createInfo.MarshalTo(&marshalledCreateInfo);
                    Interop.AllocationCallbacks marshalledAllocator;
                    this.parent.Allocator?.MarshalTo(&marshalledAllocator);
                    Interop.Device marshalledDevice;
                    commandResult = Interop.Commands.vkCreateDevice(this.handle, &marshalledCreateInfo, this.parent.Allocator == null ? null : &marshalledAllocator, &marshalledDevice);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new Device(marshalledDevice, this);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Returns properties of available physical device extensions.
        /// </summary>
        public ExtensionProperties[] EnumerateDeviceExtensionProperties(string layerName)
        {
            unsafe
            {
                try
                {
                    ExtensionProperties[] result = default(ExtensionProperties[]);
                    Result commandResult;
                    char* marshalledLayerName = Interop.HeapUtil.MarshalTo(layerName);
                    uint propertyCount;
                    Interop.ExtensionProperties* marshalledProperties = null;
                    commandResult = Interop.Commands.vkEnumerateDeviceExtensionProperties(this.handle, marshalledLayerName, &propertyCount, null);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    marshalledProperties = (Interop.ExtensionProperties*)Interop.HeapUtil.Allocate<Interop.ExtensionProperties>((uint)propertyCount);
                    commandResult = Interop.Commands.vkEnumerateDeviceExtensionProperties(this.handle, marshalledLayerName, &propertyCount, marshalledProperties);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new ExtensionProperties[(uint)propertyCount];
                    for(int index = 0; index < (uint)propertyCount; index++)
                    {
                    	result[index] = ExtensionProperties.MarshalFrom(&marshalledProperties[index]);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Returns properties of available physical device layers.
        /// </summary>
        public LayerProperties[] EnumerateDeviceLayerProperties()
        {
            unsafe
            {
                try
                {
                    LayerProperties[] result = default(LayerProperties[]);
                    Result commandResult;
                    uint propertyCount;
                    Interop.LayerProperties* marshalledProperties = null;
                    commandResult = Interop.Commands.vkEnumerateDeviceLayerProperties(this.handle, &propertyCount, null);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    marshalledProperties = (Interop.LayerProperties*)Interop.HeapUtil.Allocate<Interop.LayerProperties>((uint)propertyCount);
                    commandResult = Interop.Commands.vkEnumerateDeviceLayerProperties(this.handle, &propertyCount, marshalledProperties);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new LayerProperties[(uint)propertyCount];
                    for(int index = 0; index < (uint)propertyCount; index++)
                    {
                    	result[index] = LayerProperties.MarshalFrom(&marshalledProperties[index]);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Retrieve properties of an image format applied to sparse images.
        /// </summary>
        public SparseImageFormatProperties[] GetSparseImageFormatProperties(Format format, ImageType type, SampleCountFlags samples, ImageUsageFlags usage, ImageTiling tiling)
        {
            unsafe
            {
                try
                {
                    SparseImageFormatProperties[] result = default(SparseImageFormatProperties[]);
                    uint propertyCount;
                    SparseImageFormatProperties* marshalledProperties = null;
                    Interop.Commands.vkGetPhysicalDeviceSparseImageFormatProperties(this.handle, format, type, samples, usage, tiling, &propertyCount, null);
                    marshalledProperties = (SparseImageFormatProperties*)Interop.HeapUtil.Allocate<SparseImageFormatProperties>((uint)propertyCount);
                    Interop.Commands.vkGetPhysicalDeviceSparseImageFormatProperties(this.handle, format, type, samples, usage, tiling, &propertyCount, marshalledProperties);
                    result = new SparseImageFormatProperties[(uint)propertyCount];
                    for(int index = 0; index < (uint)propertyCount; index++)
                    {
                    	result[index] = marshalledProperties[index];
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query if presentation is supported.
        /// </summary>
        public Bool32 GetSurfaceSupport(uint queueFamilyIndex, Surface surface)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceSurfaceSupportKHR>("vkGetPhysicalDeviceSurfaceSupportKHR", "instance");
                    Bool32 result = default(Bool32);
                    Result commandResult;
                    Interop.Surface marshalledSurface = default(Interop.Surface);
                    surface?.MarshalTo(&marshalledSurface);
                    commandResult = commandDelegate(this.handle, queueFamilyIndex, marshalledSurface, &result);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query surface capabilities.
        /// </summary>
        public SurfaceCapabilities GetSurfaceCapabilities(Surface surface)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceSurfaceCapabilitiesKHR>("vkGetPhysicalDeviceSurfaceCapabilitiesKHR", "instance");
                    SurfaceCapabilities result = default(SurfaceCapabilities);
                    Result commandResult;
                    Interop.Surface marshalledSurface = default(Interop.Surface);
                    surface?.MarshalTo(&marshalledSurface);
                    commandResult = commandDelegate(this.handle, marshalledSurface, &result);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query color formats supported by surface.
        /// </summary>
        public SurfaceFormat[] GetSurfaceFormats(Surface surface)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceSurfaceFormatsKHR>("vkGetPhysicalDeviceSurfaceFormatsKHR", "instance");
                    SurfaceFormat[] result = default(SurfaceFormat[]);
                    Result commandResult;
                    Interop.Surface marshalledSurface = default(Interop.Surface);
                    surface?.MarshalTo(&marshalledSurface);
                    uint surfaceFormatCount;
                    SurfaceFormat* marshalledSurfaceFormats = null;
                    commandResult = commandDelegate(this.handle, marshalledSurface, &surfaceFormatCount, null);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    marshalledSurfaceFormats = (SurfaceFormat*)Interop.HeapUtil.Allocate<SurfaceFormat>((uint)surfaceFormatCount);
                    commandResult = commandDelegate(this.handle, marshalledSurface, &surfaceFormatCount, marshalledSurfaceFormats);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new SurfaceFormat[(uint)surfaceFormatCount];
                    for(int index = 0; index < (uint)surfaceFormatCount; index++)
                    {
                    	result[index] = marshalledSurfaceFormats[index];
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query supported presentation modes.
        /// </summary>
        public PresentMode[] GetSurfacePresentModes(Surface surface)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceSurfacePresentModesKHR>("vkGetPhysicalDeviceSurfacePresentModesKHR", "instance");
                    PresentMode[] result = default(PresentMode[]);
                    Result commandResult;
                    Interop.Surface marshalledSurface = default(Interop.Surface);
                    surface?.MarshalTo(&marshalledSurface);
                    uint presentModeCount;
                    PresentMode* marshalledPresentModes = null;
                    commandResult = commandDelegate(this.handle, marshalledSurface, &presentModeCount, null);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    marshalledPresentModes = (PresentMode*)Interop.HeapUtil.Allocate<int>((uint)presentModeCount);
                    commandResult = commandDelegate(this.handle, marshalledSurface, &presentModeCount, marshalledPresentModes);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new PresentMode[(uint)presentModeCount];
                    for(int index = 0; index < (uint)presentModeCount; index++)
                    {
                    	result[index] = marshalledPresentModes[index];
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query information about the available displays.
        /// </summary>
        public DisplayProperties[] GetDisplayProperties()
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceDisplayPropertiesKHR>("vkGetPhysicalDeviceDisplayPropertiesKHR", "instance");
                    DisplayProperties[] result = default(DisplayProperties[]);
                    Result commandResult;
                    uint propertyCount;
                    Interop.DisplayProperties* marshalledProperties = null;
                    commandResult = commandDelegate(this.handle, &propertyCount, null);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    marshalledProperties = (Interop.DisplayProperties*)Interop.HeapUtil.Allocate<Interop.DisplayProperties>((uint)propertyCount);
                    commandResult = commandDelegate(this.handle, &propertyCount, marshalledProperties);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new DisplayProperties[(uint)propertyCount];
                    for(int index = 0; index < (uint)propertyCount; index++)
                    {
                    	result[index] = DisplayProperties.MarshalFrom(&marshalledProperties[index]);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query the plane properties.
        /// </summary>
        public DisplayPlaneProperties[] GetDisplayPlaneProperties()
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceDisplayPlanePropertiesKHR>("vkGetPhysicalDeviceDisplayPlanePropertiesKHR", "instance");
                    DisplayPlaneProperties[] result = default(DisplayPlaneProperties[]);
                    Result commandResult;
                    uint propertyCount;
                    Interop.DisplayPlaneProperties* marshalledProperties = null;
                    commandResult = commandDelegate(this.handle, &propertyCount, null);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    marshalledProperties = (Interop.DisplayPlaneProperties*)Interop.HeapUtil.Allocate<Interop.DisplayPlaneProperties>((uint)propertyCount);
                    commandResult = commandDelegate(this.handle, &propertyCount, marshalledProperties);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new DisplayPlaneProperties[(uint)propertyCount];
                    for(int index = 0; index < (uint)propertyCount; index++)
                    {
                    	result[index] = DisplayPlaneProperties.MarshalFrom(&marshalledProperties[index]);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query the list of displays a plane supports.
        /// </summary>
        public Display[] GetDisplayPlaneSupportedDisplays(uint planeIndex)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetDisplayPlaneSupportedDisplaysKHR>("vkGetDisplayPlaneSupportedDisplaysKHR", "instance");
                    Display[] result = default(Display[]);
                    Result commandResult;
                    uint displayCount;
                    Interop.Display* marshalledDisplays = null;
                    commandResult = commandDelegate(this.handle, planeIndex, &displayCount, null);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    marshalledDisplays = (Interop.Display*)Interop.HeapUtil.Allocate<Interop.Display>((uint)displayCount);
                    commandResult = commandDelegate(this.handle, planeIndex, &displayCount, marshalledDisplays);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new Display[(uint)displayCount];
                    for(int index = 0; index < (uint)displayCount; index++)
                    {
                    	result[index] = new Display(marshalledDisplays[index], this.Allocator, this.commandCache);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query the set of mode properties supported by the display.
        /// </summary>
        public DisplayModeProperties[] GetDisplayModeProperties(Display display)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetDisplayModePropertiesKHR>("vkGetDisplayModePropertiesKHR", "instance");
                    DisplayModeProperties[] result = default(DisplayModeProperties[]);
                    Result commandResult;
                    Interop.Display marshalledDisplay = default(Interop.Display);
                    display?.MarshalTo(&marshalledDisplay);
                    uint propertyCount;
                    Interop.DisplayModeProperties* marshalledProperties = null;
                    commandResult = commandDelegate(this.handle, marshalledDisplay, &propertyCount, null);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    marshalledProperties = (Interop.DisplayModeProperties*)Interop.HeapUtil.Allocate<Interop.DisplayModeProperties>((uint)propertyCount);
                    commandResult = commandDelegate(this.handle, marshalledDisplay, &propertyCount, marshalledProperties);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new DisplayModeProperties[(uint)propertyCount];
                    for(int index = 0; index < (uint)propertyCount; index++)
                    {
                    	result[index] = DisplayModeProperties.MarshalFrom(&marshalledProperties[index]);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Create a display mode.
        /// </summary>
        public DisplayMode CreateDisplayMode(Display display, DisplayModeCreateInfo createInfo)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkCreateDisplayModeKHR>("vkCreateDisplayModeKHR", "instance");
                    DisplayMode result = default(DisplayMode);
                    Result commandResult;
                    Interop.Display marshalledDisplay = default(Interop.Display);
                    display?.MarshalTo(&marshalledDisplay);
                    Interop.DisplayModeCreateInfo marshalledCreateInfo;
                    createInfo.MarshalTo(&marshalledCreateInfo);
                    Interop.AllocationCallbacks marshalledAllocator;
                    this.parent.Allocator?.MarshalTo(&marshalledAllocator);
                    Interop.DisplayMode marshalledMode;
                    commandResult = commandDelegate(this.handle, marshalledDisplay, &marshalledCreateInfo, this.parent.Allocator == null ? null : &marshalledAllocator, &marshalledMode);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new DisplayMode(marshalledMode, this, this.commandCache);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query physical device for presentation to X11 server using Xlib.
        /// </summary>
        public bool GetXlibPresentationSupport(uint queueFamilyIndex, IntPtr dpy, IntPtr visualID)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceXlibPresentationSupportKHR>("vkGetPhysicalDeviceXlibPresentationSupportKHR", "instance");
                    bool result = default(bool);
                    result = commandDelegate(this.handle, queueFamilyIndex, &dpy, visualID);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query physical device for presentation to X11 server using XCB.
        /// </summary>
        public bool GetXcbPresentationSupport(uint queueFamilyIndex, IntPtr connection, IntPtr visual_id)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceXcbPresentationSupportKHR>("vkGetPhysicalDeviceXcbPresentationSupportKHR", "instance");
                    bool result = default(bool);
                    result = commandDelegate(this.handle, queueFamilyIndex, &connection, visual_id);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query physical device for presentation to Wayland.
        /// </summary>
        public bool GetWaylandPresentationSupport(uint queueFamilyIndex, IntPtr display)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceWaylandPresentationSupportKHR>("vkGetPhysicalDeviceWaylandPresentationSupportKHR", "instance");
                    bool result = default(bool);
                    result = commandDelegate(this.handle, queueFamilyIndex, display);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query physical device for presentation to Mir.
        /// </summary>
        public bool GetMirPresentationSupport(uint queueFamilyIndex, IntPtr connection)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceMirPresentationSupportKHR>("vkGetPhysicalDeviceMirPresentationSupportKHR", "instance");
                    bool result = default(bool);
                    result = commandDelegate(this.handle, queueFamilyIndex, &connection);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query queue family support for presentation on a Win32 display.
        /// </summary>
        public bool GetWin32PresentationSupport(uint queueFamilyIndex)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceWin32PresentationSupportKHR>("vkGetPhysicalDeviceWin32PresentationSupportKHR", "instance");
                    bool result = default(bool);
                    result = commandDelegate(this.handle, queueFamilyIndex);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Determine image capabilities compatible with external memory handle
        /// types.
        /// </summary>
        public ExternalImageFormatProperties GetExternalImageFormatProperties(Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ExternalMemoryHandleTypeFlags externalHandleType)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceExternalImageFormatPropertiesNV>("vkGetPhysicalDeviceExternalImageFormatPropertiesNV", "instance");
                    ExternalImageFormatProperties result = default(ExternalImageFormatProperties);
                    Result commandResult;
                    commandResult = commandDelegate(this.handle, format, type, tiling, usage, flags, externalHandleType, &result);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Reports capabilities of a physical device.
        /// </summary>
        public PhysicalDeviceFeatures2 GetFeatures2()
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceFeatures2KHR>("vkGetPhysicalDeviceFeatures2KHR", "instance");
                    PhysicalDeviceFeatures2 result = default(PhysicalDeviceFeatures2);
                    Interop.PhysicalDeviceFeatures2 marshalledFeatures;
                    commandDelegate(this.handle, &marshalledFeatures);
                    result = PhysicalDeviceFeatures2.MarshalFrom(&marshalledFeatures);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Returns properties of a physical device.
        /// </summary>
        public PhysicalDeviceProperties2 GetProperties2()
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceProperties2KHR>("vkGetPhysicalDeviceProperties2KHR", "instance");
                    PhysicalDeviceProperties2 result = default(PhysicalDeviceProperties2);
                    Interop.PhysicalDeviceProperties2 marshalledProperties;
                    commandDelegate(this.handle, &marshalledProperties);
                    result = PhysicalDeviceProperties2.MarshalFrom(&marshalledProperties);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Lists physical device's format capabilities.
        /// </summary>
        public FormatProperties2 GetFormatProperties2(Format format)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceFormatProperties2KHR>("vkGetPhysicalDeviceFormatProperties2KHR", "instance");
                    FormatProperties2 result = default(FormatProperties2);
                    Interop.FormatProperties2 marshalledFormatProperties;
                    commandDelegate(this.handle, format, &marshalledFormatProperties);
                    result = FormatProperties2.MarshalFrom(&marshalledFormatProperties);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Lists physical device's image format capabilities.
        /// </summary>
        public ImageFormatProperties2 GetImageFormatProperties2(PhysicalDeviceImageFormatInfo2 imageFormatInfo)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceImageFormatProperties2KHR>("vkGetPhysicalDeviceImageFormatProperties2KHR", "instance");
                    ImageFormatProperties2 result = default(ImageFormatProperties2);
                    Result commandResult;
                    Interop.PhysicalDeviceImageFormatInfo2 marshalledImageFormatInfo;
                    imageFormatInfo.MarshalTo(&marshalledImageFormatInfo);
                    Interop.ImageFormatProperties2 marshalledImageFormatProperties;
                    commandResult = commandDelegate(this.handle, &marshalledImageFormatInfo, &marshalledImageFormatProperties);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = ImageFormatProperties2.MarshalFrom(&marshalledImageFormatProperties);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Reports properties of the queues of the specified physical device.
        /// </summary>
        public QueueFamilyProperties2[] GetQueueFamilyProperties2()
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceQueueFamilyProperties2KHR>("vkGetPhysicalDeviceQueueFamilyProperties2KHR", "instance");
                    QueueFamilyProperties2[] result = default(QueueFamilyProperties2[]);
                    uint queueFamilyPropertyCount;
                    Interop.QueueFamilyProperties2* marshalledQueueFamilyProperties = null;
                    commandDelegate(this.handle, &queueFamilyPropertyCount, null);
                    marshalledQueueFamilyProperties = (Interop.QueueFamilyProperties2*)Interop.HeapUtil.Allocate<Interop.QueueFamilyProperties2>((uint)queueFamilyPropertyCount);
                    commandDelegate(this.handle, &queueFamilyPropertyCount, marshalledQueueFamilyProperties);
                    result = new QueueFamilyProperties2[(uint)queueFamilyPropertyCount];
                    for(int index = 0; index < (uint)queueFamilyPropertyCount; index++)
                    {
                    	result[index] = QueueFamilyProperties2.MarshalFrom(&marshalledQueueFamilyProperties[index]);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Reports memory information for the specified physical device.
        /// </summary>
        public PhysicalDeviceMemoryProperties2 GetMemoryProperties2()
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceMemoryProperties2KHR>("vkGetPhysicalDeviceMemoryProperties2KHR", "instance");
                    PhysicalDeviceMemoryProperties2 result = default(PhysicalDeviceMemoryProperties2);
                    Interop.PhysicalDeviceMemoryProperties2 marshalledMemoryProperties;
                    commandDelegate(this.handle, &marshalledMemoryProperties);
                    result = PhysicalDeviceMemoryProperties2.MarshalFrom(&marshalledMemoryProperties);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Retrieve properties of an image format applied to sparse images.
        /// </summary>
        public SparseImageFormatProperties2[] GetSparseImageFormatProperties2(PhysicalDeviceSparseImageFormatInfo2 formatInfo)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceSparseImageFormatProperties2KHR>("vkGetPhysicalDeviceSparseImageFormatProperties2KHR", "instance");
                    SparseImageFormatProperties2[] result = default(SparseImageFormatProperties2[]);
                    Interop.PhysicalDeviceSparseImageFormatInfo2 marshalledFormatInfo;
                    formatInfo.MarshalTo(&marshalledFormatInfo);
                    uint propertyCount;
                    Interop.SparseImageFormatProperties2* marshalledProperties = null;
                    commandDelegate(this.handle, &marshalledFormatInfo, &propertyCount, null);
                    marshalledProperties = (Interop.SparseImageFormatProperties2*)Interop.HeapUtil.Allocate<Interop.SparseImageFormatProperties2>((uint)propertyCount);
                    commandDelegate(this.handle, &marshalledFormatInfo, &propertyCount, marshalledProperties);
                    result = new SparseImageFormatProperties2[(uint)propertyCount];
                    for(int index = 0; index < (uint)propertyCount; index++)
                    {
                    	result[index] = SparseImageFormatProperties2.MarshalFrom(&marshalledProperties[index]);
                    }
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Returns device-generated commands related properties of a physical
        /// device.
        /// </summary>
        public DeviceGeneratedCommandsLimits GetGeneratedCommandsProperties(DeviceGeneratedCommandsFeatures features)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX>("vkGetPhysicalDeviceGeneratedCommandsPropertiesNVX", "device");
                    DeviceGeneratedCommandsLimits result = default(DeviceGeneratedCommandsLimits);
                    Interop.DeviceGeneratedCommandsFeatures marshalledFeatures;
                    features.MarshalTo(&marshalledFeatures);
                    Interop.DeviceGeneratedCommandsLimits marshalledLimits;
                    commandDelegate(this.handle, &marshalledFeatures, &marshalledLimits);
                    result = DeviceGeneratedCommandsLimits.MarshalFrom(&marshalledLimits);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Release access to an acquired VkDisplayKHR.
        /// </summary>
        public void ReleaseDisplay(Display display)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkReleaseDisplayEXT>("vkReleaseDisplayEXT", "instance");
                    Result commandResult;
                    Interop.Display marshalledDisplay = default(Interop.Display);
                    display?.MarshalTo(&marshalledDisplay);
                    commandResult = commandDelegate(this.handle, marshalledDisplay);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Acquire access to a VkDisplayKHR using Xlib.
        /// </summary>
        public void AcquireXlibDisplay(IntPtr dpy, Display display)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkAcquireXlibDisplayEXT>("vkAcquireXlibDisplayEXT", "instance");
                    Result commandResult;
                    Interop.Display marshalledDisplay = default(Interop.Display);
                    display?.MarshalTo(&marshalledDisplay);
                    commandResult = commandDelegate(this.handle, &dpy, marshalledDisplay);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query the VkDisplayKHR corresponding to an X11 RandR Output.
        /// </summary>
        public Display GetRandROutputDisplay(IntPtr dpy, IntPtr rrOutput)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetRandROutputDisplayEXT>("vkGetRandROutputDisplayEXT", "instance");
                    Display result = default(Display);
                    Result commandResult;
                    Interop.Display marshalledDisplay;
                    commandResult = commandDelegate(this.handle, &dpy, rrOutput, &marshalledDisplay);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = new Display(marshalledDisplay, this.parent.Allocator, this.commandCache);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        /// <summary>
        /// Query surface capabilities.
        /// </summary>
        public SurfaceCapabilities2 GetSurfaceCapabilities2(Surface surface)
        {
            unsafe
            {
                try
                {
                    var commandDelegate = this.commandCache.GetCommandDelegate<Interop.vkGetPhysicalDeviceSurfaceCapabilities2EXT>("vkGetPhysicalDeviceSurfaceCapabilities2EXT", "instance");
                    SurfaceCapabilities2 result = default(SurfaceCapabilities2);
                    Result commandResult;
                    Interop.Surface marshalledSurface = default(Interop.Surface);
                    surface?.MarshalTo(&marshalledSurface);
                    Interop.SurfaceCapabilities2 marshalledSurfaceCapabilities;
                    commandResult = commandDelegate(this.handle, marshalledSurface, &marshalledSurfaceCapabilities);
                    if (SharpVkException.IsError(commandResult))
                    {
                        throw SharpVkException.Create(commandResult);
                    }
                    result = SurfaceCapabilities2.MarshalFrom(&marshalledSurfaceCapabilities);
                    return result;
                }
                finally
                {
                    Interop.HeapUtil.FreeLog();
                }
            }
        }
        
        internal unsafe void MarshalTo(Interop.PhysicalDevice* pointer)
        {
            *pointer = this.handle;
        }
        
        /// <summary>
        /// The interop handle for this PhysicalDevice.
        /// </summary>
        public Interop.PhysicalDevice RawHandle => this.handle;
    }
}
