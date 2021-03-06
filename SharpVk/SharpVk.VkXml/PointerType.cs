﻿namespace SharpVk.VkXml
{
    public enum PointerType
    {
        Value,
        ConstValue,
        Pointer,
        DoublePointer,
        ConstPointer,
        DoubleConstPointer
    }

    public static class PointerTypeExtensions
    {
        public static int GetPointerCount(this PointerType pointerType)
        {
            switch (pointerType)
            {
                case PointerType.Pointer:
                case PointerType.ConstPointer:
                    return 1;
                case PointerType.DoublePointer:
                case PointerType.DoubleConstPointer:
                    return 2;
                default:
                    return 0;
            }
        }

        public static bool IsPointer(this PointerType pointerType)
        {
            switch (pointerType)
            {
                case PointerType.Value:
                case PointerType.ConstValue:
                    return false;
                default:
                    return true;
            }
        }
    }
}