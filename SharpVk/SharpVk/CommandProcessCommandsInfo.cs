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
    /// Structure specifying parameters for the generation of commands.
    /// </summary>
    public struct CommandProcessCommandsInfo
    {
        /// <summary>
        /// pname:objectTable is the sname:VkObjectTableNVX to be used for the
        /// generation process. Only registered objects at the time
        /// flink:vkCmdReserveSpaceForCommandsNVX is called, will be taken into
        /// account for the reservation.
        /// </summary>
        public ObjectTable ObjectTable
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:indirectCommandsLayout is the
        /// sname:VkIndirectCommandsLayoutNVX that provides the command
        /// sequence to generate.
        /// </summary>
        public IndirectCommandsLayout IndirectCommandsLayout
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:pIndirectCommandsTokens provides an array of
        /// slink:VkIndirectCommandsTokenNVX that reference the input data for
        /// each token command.
        /// </summary>
        public IndirectCommandsToken[] IndirectCommandsTokens
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:maxSequencesCount is the maximum number of sequences for
        /// which command buffer space will be reserved. If
        /// pname:sequencesCountBuffer is `NULL`, this is also the actual
        /// number of sequences generated.
        /// </summary>
        public uint MaxSequencesCount
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:targetCommandBuffer can: be the secondary
        /// sname:VkCommandBuffer in which the commands should be recorded. If
        /// `NULL` an implicit reservation as well as execution takes place on
        /// the processing sname:VkCommandBuffer.
        /// </summary>
        public CommandBuffer TargetCommandBuffer
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:sequencesCountBuffer can: be sname:VkBuffer from which the
        /// actual amount of sequences is sourced from as ftext:uint32_t value.
        /// </summary>
        public Buffer SequencesCountBuffer
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:sequencesCountOffset is the byte offset into
        /// pname:sequencesCountBuffer where the count value is stored.
        /// </summary>
        public ulong SequencesCountOffset
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:sequencesIndexBuffer must: be set if
        /// pname:indirectCommandsLayout's ename:VK_INDIRECT_COMMANDS_LAYOUT_USAGE_INDEXED_SEQUENCES_BIT
        /// is set and provides the used sequence indices as ftext:uint32_t
        /// array. Otherwise it must: be `NULL`.
        /// </summary>
        public Buffer SequencesIndexBuffer
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:sequencesIndexOffset is the byte offset into
        /// pname:sequencesIndexBuffer where the index values start.
        /// </summary>
        public ulong SequencesIndexOffset
        {
            get;
            set;
        }
        
        internal unsafe Interop.CommandProcessCommandsInfo* MarshalTo()
        {
            var result = (Interop.CommandProcessCommandsInfo*)Interop.HeapUtil.AllocateAndClear<Interop.CommandProcessCommandsInfo>().ToPointer();
            this.MarshalTo(result);
            return result;
        }
        
        internal unsafe void MarshalTo(Interop.CommandProcessCommandsInfo* pointer)
        {
            pointer->SType = StructureType.CommandProcessCommandsInfo;
            pointer->Next = null;
            this.ObjectTable?.MarshalTo(&pointer->ObjectTable);
            this.IndirectCommandsLayout?.MarshalTo(&pointer->IndirectCommandsLayout);
            
            //IndirectCommandsTokens
            if (this.IndirectCommandsTokens != null)
            {
                var fieldPointer = (Interop.IndirectCommandsToken*)Interop.HeapUtil.AllocateAndClear<Interop.IndirectCommandsToken>(this.IndirectCommandsTokens.Length);
                for (int index = 0; index < this.IndirectCommandsTokens.Length; index++)
                {
                    this.IndirectCommandsTokens[index].MarshalTo(&fieldPointer[index]);
                }
                pointer->IndirectCommandsTokens = fieldPointer;
            }
            else
            {
                pointer->IndirectCommandsTokens = null;
            }
            this.TargetCommandBuffer?.MarshalTo(&pointer->TargetCommandBuffer);
            this.SequencesCountBuffer?.MarshalTo(&pointer->SequencesCountBuffer);
            this.SequencesIndexBuffer?.MarshalTo(&pointer->SequencesIndexBuffer);
            pointer->IndirectCommandsTokenCount = (uint)(this.IndirectCommandsTokens?.Length ?? 0);
            pointer->MaxSequencesCount = this.MaxSequencesCount;
            pointer->SequencesCountOffset = this.SequencesCountOffset;
            pointer->SequencesIndexOffset = this.SequencesIndexOffset;
        }
    }
}
