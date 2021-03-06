﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpVk.Interop
{
    internal class AllocationLog
    {
        public List<IntPtr> StructAllocations = new List<IntPtr>();
        public List<IntPtr> StringAllocations = new List<IntPtr>();

        public void Clear()
        {
            this.StructAllocations.Clear();
            this.StringAllocations.Clear();
        }
    }

    internal static unsafe class HeapUtil
    {
        [ThreadStatic]
        private static AllocationLog threadLog;

        private static AllocationLog ThreadLog
        {
            get
            {
                if (threadLog == null)
                {
                    threadLog = new AllocationLog();
                }

                return threadLog;
            }
        }

        internal static IntPtr Allocate<T>(uint count)
        {
            return Allocate<T>((int)count);
        }

        internal static IntPtr Allocate<T>(int count = 1)
        {
            uint size = MemUtil.SizeOf<T>();

            IntPtr pointer = Marshal.AllocHGlobal((int)size * count);

            ThreadLog.StructAllocations.Add(pointer);

            return pointer;
        }

        internal static IntPtr AllocateAndClear<T>(int count = 1)
        {
            uint size = MemUtil.SizeOf<T>();

            IntPtr pointer = Allocate<T>(count);

            var bytePointer = (byte*)pointer.ToPointer();

            for (int offset = 0; offset < size; offset++)
            {
                bytePointer[offset] = 0;
            }

            return pointer;
        }

        internal static void FreeLog()
        {
            for (int index = 0; index < ThreadLog.StructAllocations.Count; index++)
            {
                FreeStruct(ThreadLog.StructAllocations[index]);
            }

            for (int index = 0; index < ThreadLog.StringAllocations.Count; index++)
            {
                FreeString(ThreadLog.StringAllocations[index]);
            }

            ThreadLog.Clear();
        }

        internal static void FreeStruct(IntPtr pointer)
        {
            Marshal.FreeHGlobal(pointer);
        }

        internal static void FreeString(IntPtr pointer)
        {
            FreeStruct(pointer);
        }

        internal static void Free(void* pointer)
        {
            FreeStruct(new IntPtr(pointer));
        }

        internal static char* MarshalTo(string value)
        {
            if (value != null)
            {
                IntPtr pointer = Marshal.StringToHGlobalAnsi(value);

                ThreadLog.StringAllocations.Add(pointer);

                return (char*)pointer.ToPointer();
            }
            else
            {
                return null;
            }
        }

        internal static char** MarshalTo(string[] value)
        {
            IntPtr pointer = Allocate<IntPtr>(value.Length);

            char** typedPointer = (char**)pointer.ToPointer();

            MarshalTo(value, value.Length, typedPointer);

            return typedPointer;
        }

        internal static string MarshalFrom(char* pointer)
        {
            return Marshal.PtrToStringAnsi(new IntPtr(pointer));
        }

        internal static string MarshalFrom(char* pointer, int length)
        {
            return Marshal.PtrToStringAnsi(new IntPtr(pointer), length);
        }

        internal static byte[] MarshalFrom(byte* pointer, int length)
        {
            int actualLength;

            return MarshalFrom(pointer, length, out actualLength);
        }

        internal static byte[] MarshalFrom(byte* pointer, int length, out int actualLength, bool isNullTerminated = false)
        {
            if (isNullTerminated)
            {
                actualLength = 0;

                while (actualLength < length && pointer[actualLength] != 0)
                {
                    actualLength++;
                }

                length = actualLength;
            }
            else
            {
                actualLength = length;
            }

            var newArray = new byte[length];

            Marshal.Copy(new IntPtr(pointer), newArray, 0, length);

            return newArray;
        }

        internal static float[] MarshalFrom(float* pointer, int length)
        {
            var newArray = new float[length];

            Marshal.Copy(new IntPtr(pointer), newArray, 0, length);

            return newArray;
        }

        internal static uint[] MarshalFrom(uint* pointer, int length)
        {
            var newArray = new uint[length];

            // Marshal.Copy doesn't support uints for some reason...
            for (int index = 0; index < length; index++)
            {
                newArray[index] = *(pointer + length);
            }

            return newArray;
        }

        internal static byte* MarshalTo(byte[] value)
        {
            byte* pointer = (byte*)Allocate<byte>(value.Length).ToPointer();

            MarshalTo(value, value.Length, pointer);

            return pointer;
        }

        internal static float* MarshalTo(float[] value)
        {
            float* pointer = (float*)Allocate<float>(value.Length).ToPointer();

            MarshalTo(value, value.Length, pointer);

            return pointer;
        }

        internal static int* MarshalTo(int[] value)
        {
            int* pointer = (int*)Allocate<int>(value.Length).ToPointer();

            MarshalTo(value, value.Length, pointer);

            return pointer;
        }

        internal static uint* MarshalTo(uint[] value)
        {
            uint* pointer = (uint*)Allocate<uint>(value.Length).ToPointer();

            MarshalTo(value, value.Length, pointer);

            return pointer;
        }

        internal static ulong* MarshalTo(ulong[] value)
        {
            ulong* pointer = (ulong*)Allocate<ulong>(value.Length).ToPointer();

            MarshalTo(value, value.Length, pointer);

            return pointer;
        }

        //internal static void* MarshalTo<T>(IEnumerable<T> value, int length)
        //    where T : struct
        //{
        //    uint size = MemUtil.SizeOf<T>();

        //    T[] valueArray = value.ToArray();

        //    IntPtr pointer = Allocate<T>(valueArray.Length);

        //    for (int index = 0; index < length; index++)
        //    {
        //        Marshal.StructureToPtr(valueArray[index], pointer + ((int)size * index), false);
        //    }

        //    return pointer.ToPointer();
        //}
        
        internal static void MarshalTo(byte[] value, int length, byte* pointer)
        {
            Marshal.Copy(value, 0, new IntPtr(pointer), length);
        }

        internal static void MarshalTo(float[] value, int length, float* pointer)
        {
            Marshal.Copy(value, 0, new IntPtr(pointer), length);
        }

        internal static void MarshalTo(int[] value, int length, int* pointer)
        {
            Marshal.Copy(value, 0, new IntPtr(pointer), length);
        }

        internal static void MarshalTo(uint[] value, int length, uint* pointer)
        {
            //Marshal.Copy doesn't support uints for some reason...
            for (int index = 0; index < length; index++)
            {
                pointer[index] = value[index];
            }
        }

        internal static void MarshalTo(ulong[] value, int length, ulong* pointer)
        {
            //Marshal.Copy doesn't support ulongs for some reason...
            for (int index = 0; index < length; index++)
            {
                pointer[index] = value[index];
            }
        }
        
        internal static void MarshalTo(string[] value, int length, char** pointer)
        {
            for (int index = 0; index < length; index++)
            {
                pointer[index] = MarshalTo(value[index]);
            }
        }
    }
}
