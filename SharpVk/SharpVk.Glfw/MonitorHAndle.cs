﻿using System;

namespace SharpVk.Glfw
{
    public struct MonitorHandle
    {
        private IntPtr handle;

        public IntPtr RawHandle
        {
            get
            {
                return this.handle;
            }
        }
    }
}
