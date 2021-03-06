﻿using System;
using System.Collections.Generic;

namespace SharpVk.VkXml
{
    public class TypeSet
    {
        public List<VkConstant> Constants
        {
            get;
            private set;
        } = new List<VkConstant>();

        public List<VkConstant> Exceptions
        {
            get;
            private set;
        } = new List<VkConstant>();

        public List<VkEnumeration> Enumerations
        {
            get;
            private set;
        } = new List<VkEnumeration>();

        public List<VkStruct> Structs
        {
            get;
            private set;
        } = new List<VkStruct>();

        public List<VkStruct> InteropStructs
        {
            get;
            private set;
        } = new List<VkStruct>();

        public List<VkClass> Classes
        {
            get;
            private set;
        } = new List<VkClass>();

        public List<VkStruct> Unions
        {
            get;
            private set;
        } = new List<VkStruct>();

        public List<VkHandle> Handles
        {
            get;
            private set;
        } = new List<VkHandle>();

        public List<VkCommand> Commands
        {
            get;
            private set;
        } = new List<VkCommand>();

        public List<VkCommand> Delegates
        {
            get;
            private set;
        } = new List<VkCommand>();

        public class VkDelegate
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public string ReturnType
            {
                get;
                set;
            }
        }

        public class VkClass
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public bool IsOutput
            {
                get;
                set;
            }

            public List<VkClassProperty> Properties
            {
                get;
                private set;
            } = new List<VkClassProperty>();

            public List<string> MarshalToStatements
            {
                get;
                private set;
            } = new List<string>();

            public List<string> MarshalFromStatements
            {
                get;
                private set;
            } = new List<string>();
        }

        public class VkClassProperty
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public string TypeName
            {
                get;
                set;
            }
        }

        public class VkConstant
        {
            public string Name
            {
                get;
                set;
            }

            public string SubGroupName
            {
                get;
                set;
            }

            public Type Type
            {
                get;
                set;
            }

            public string ExplicitType
            {
                get;
                set;
            }

            public bool IsStaticReadonly
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }
        }

        public class VkEnumeration
        {
            public string Name
            {
                get;
                set;
            }

            public bool IsFlags
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public List<VkEnumerationField> Fields
            {
                get;
                private set;
            } = new List<VkEnumerationField>();
        }

        public class VkEnumerationField
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }
        }

        public class VkStruct
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public List<VkStructMember> Members
            {
                get;
                private set;
            } = new List<VkStructMember>();
        }

        public class VkStructMember
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public string TypeName
            {
                get;
                set;
            }

            public string FieldOffset
            {
                get;
                set;
            }

            public int FixedSize
            {
                get;
                set;
            }

            public bool IsPrivate
            {
                get;
                set;
            }
        }

        public class VkHandle
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public string ParentHandle
            {
                get;
                set;
            }

            public string AssociatedHandle
            {
                get;
                set;
            }

            public bool IsDispatch
            {
                get;
                set;
            }

            public bool IsDisposable
            {
                get;
                set;
            }

            public string ProcCacheType
            {
                get;
                set;
            }

            public bool IsProcLookup
            {
                get
                {
                    return !string.IsNullOrEmpty(this.ProcCacheType);
                }
            }

            public List<VkHandleMethod> Methods
            {
                get;
                private set;
            } = new List<VkHandleMethod>();
        }

        public class VkHandleMethod
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public string ReturnTypeName
            {
                get;
                set;
            }

            public string CommandName
            {
                get;
                set;
            }

            public bool IsStatic
            {
                get;
                set;
            }

            public bool IsDoubleInvoke
            {
                get;
                set;
            }

            public bool IsPassthroughResult
            {
                get;
                set;
            }

            public bool HasVkResult
            {
                get;
                set;
            }

            public string CacheLookupName
            {
                get;
                set;
            }

            public string CacheLookupType
            {
                get;
                set;
            }

            public bool ShouldGetFromCache
            {
                get
                {
                    return !string.IsNullOrEmpty(this.CacheLookupName);
                }
            }

            public List<VkMethodParam> Parameters
            {
                get;
                private set;
            } = new List<VkMethodParam>();

            public List<string> MarshalToStatements
            {
                get;
                private set;
            } = new List<string>();

            public List<string> MarshalMidStatements
            {
                get;
                private set;
            } = new List<string>();

            public List<string> MarshalFromStatements
            {
                get;
                private set;
            } = new List<string>();
        }

        public class VkMethodParam
        {
            public string Name
            {
                get;
                set;
            }

            public string PreInvokeArgumentName
            {
                get;
                set;
            }

            public string ArgumentName
            {
                get;
                set;
            }

            public string TypeName
            {
                get;
                set;
            }

            public string FixedName
            {
                get;
                set;
            }

            public string FixedType
            {
                get;
                set;
            }
        }

        public class VkCommand
        {
            public string Name
            {
                get;
                set;
            }

            public List<string> Comment
            {
                get;
                set;
            }

            public string ReturnTypeName
            {
                get;
                set;
            }

            public List<VkCommandParameter> Parameters
            {
                get;
                private set;
            } = new List<VkCommandParameter>();
        }

        public class VkCommandParameter
        {
            public string Name
            {
                get;
                set;
            }

            public string TypeName
            {
                get;
                set;
            }
        }
    }
}