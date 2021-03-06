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
    /// Structure specifying render pass begin info.
    /// </para>
    /// <para>
    /// pname:renderArea is the render area that is affected by the render pass
    /// instance. The effects of attachment load, store and multisample resolve
    /// operations are restricted to the pixels whose x and y coordinates fall
    /// within the render area on all attachments. The render area extends to
    /// all layers of pname:framebuffer. The application must: ensure (using
    /// scissor if necessary) that all rendering is contained within the render
    /// area, otherwise the pixels outside of the render area become undefined
    /// and shader side effects may: occur for fragments outside the render
    /// area. The render area must: be contained within the framebuffer
    /// dimensions.
    /// </para>
    /// <para>
    /// [NOTE] .Note ==== There may: be a performance cost for using a render
    /// area smaller than the framebuffer, unless it matches the render area
    /// granularity for the render pass. ====
    /// </para>
    /// </summary>
    public struct RenderPassBeginInfo
    {
        /// <summary>
        /// pname:renderPass is the render pass to begin an instance of.
        /// </summary>
        public RenderPass RenderPass
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:framebuffer is the framebuffer containing the attachments
        /// that are used with the render pass.
        /// </summary>
        public Framebuffer Framebuffer
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:renderArea is the render area that is affected by the render
        /// pass instance, and is described in more detail below.
        /// </summary>
        public Rect2D RenderArea
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:pClearValues is an array of slink:VkClearValue structures
        /// that contains clear values for each attachment, if the attachment
        /// uses a pname:loadOp value of ename:VK_ATTACHMENT_LOAD_OP_CLEAR or
        /// if the attachment has a depth/stencil format and uses a
        /// pname:stencilLoadOp value of ename:VK_ATTACHMENT_LOAD_OP_CLEAR. The
        /// array is indexed by attachment number. Only elements corresponding
        /// to cleared attachments are used. Other elements of
        /// pname:pClearValues are ignored.
        /// </summary>
        public ClearValue[] ClearValues
        {
            get;
            set;
        }
        
        internal unsafe Interop.RenderPassBeginInfo* MarshalTo()
        {
            var result = (Interop.RenderPassBeginInfo*)Interop.HeapUtil.AllocateAndClear<Interop.RenderPassBeginInfo>().ToPointer();
            this.MarshalTo(result);
            return result;
        }
        
        internal unsafe void MarshalTo(Interop.RenderPassBeginInfo* pointer)
        {
            pointer->SType = StructureType.RenderPassBeginInfo;
            pointer->Next = null;
            this.RenderPass?.MarshalTo(&pointer->RenderPass);
            this.Framebuffer?.MarshalTo(&pointer->Framebuffer);
            
            //ClearValues
            if (this.ClearValues != null && this.ClearValues.Length > 0)
            {
                int length = (int)(this.ClearValues.Length);
                pointer->ClearValues = (ClearValue*)Interop.HeapUtil.Allocate<ClearValue>(length).ToPointer();
                for (int index = 0; index < length; index++)
                {
                    pointer->ClearValues[index] = this.ClearValues[index];
                }
            }
            else
            {
                pointer->ClearValues = null;
            }
            pointer->ClearValueCount = (uint)(this.ClearValues?.Length ?? 0);
            pointer->RenderArea = this.RenderArea;
        }
    }
}
