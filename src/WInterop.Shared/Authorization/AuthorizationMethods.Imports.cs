﻿// ------------------------
//    WInterop Framework
// ------------------------

// Copyright (c) Jeremy W. Kuhne. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using WInterop.Authorization.Types;

namespace WInterop.Authorization
{
    public static partial class AuthorizationMethods
    {
        /// <summary>
        /// Direct usage of Imports isn't recommended. Use the wrappers that do the heavy lifting for you.
        /// </summary>
        public static partial class Imports
        {
            // Advapi (Advanced API) provides Win32 security and registry calls and as such hosts most
            // of the Authorization APIs.
            //
            // Advapi usually calls the NT Marta provider (Windows NT Multiple Access RouTing Authority).
            // https://msdn.microsoft.com/en-us/library/aa939264.aspx


            // https://msdn.microsoft.com/en-us/library/windows/desktop/aa379159.aspx
            [DllImport(Libraries.Advapi32, SetLastError = true, ExactSpelling = true)]
            public unsafe static extern bool LookupAccountNameW(
                string lpSystemName,
                char* lpAccountName,
                SID* Sid,
                uint* cbSid,
                char* ReferencedDomainName,
                ref uint cchReferencedDomainName,
                out SID_NAME_USE peUse);
        }
    }
}