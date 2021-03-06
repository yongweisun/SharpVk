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
    /// <para>
    /// Structure specifying parameters of a newly created pipeline input
    /// assembly state.
    /// </para>
    /// <para>
    /// Restarting the assembly of primitives discards the most recent index
    /// values if those elements formed an incomplete primitive, and restarts
    /// the primitive assembly using the subsequent indices, but only
    /// assembling the immediately following element through the end of the
    /// originally specified elements. The primitive restart index value
    /// comparison is performed before adding the pname:vertexOffset value to
    /// the index value.
    /// </para>
    /// </summary>
    public struct PipelineInputAssemblyStateCreateInfo
    {
        /// <summary>
        /// pname:flags is reserved for future use.
        /// </summary>
        public PipelineInputAssemblyStateCreateFlags Flags
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:topology is a elink:VkPrimitiveTopology defining the
        /// primitive topology, as described below.
        /// </summary>
        public PrimitiveTopology Topology
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:primitiveRestartEnable controls whether a special vertex
        /// index value is treated as restarting the assembly of primitives.
        /// This enable only applies to indexed draws (flink:vkCmdDrawIndexed
        /// and flink:vkCmdDrawIndexedIndirect), and the special index value is
        /// either 0xFFFFFFFF when the pname:indexType parameter of
        /// fname:vkCmdBindIndexBuffer is equal to ename:VK_INDEX_TYPE_UINT32,
        /// or 0xFFFF when pname:indexType is equal to
        /// ename:VK_INDEX_TYPE_UINT16. Primitive restart is not allowed for
        /// "`list`" topologies.
        /// </summary>
        public Bool32 PrimitiveRestartEnable
        {
            get;
            set;
        }
        
        internal unsafe Interop.PipelineInputAssemblyStateCreateInfo* MarshalTo()
        {
            var result = (Interop.PipelineInputAssemblyStateCreateInfo*)Interop.HeapUtil.AllocateAndClear<Interop.PipelineInputAssemblyStateCreateInfo>().ToPointer();
            this.MarshalTo(result);
            return result;
        }
        
        internal unsafe void MarshalTo(Interop.PipelineInputAssemblyStateCreateInfo* pointer)
        {
            pointer->SType = StructureType.PipelineInputAssemblyStateCreateInfo;
            pointer->Next = null;
            pointer->Flags = this.Flags;
            pointer->Topology = this.Topology;
            pointer->PrimitiveRestartEnable = this.PrimitiveRestartEnable;
        }
    }
}
