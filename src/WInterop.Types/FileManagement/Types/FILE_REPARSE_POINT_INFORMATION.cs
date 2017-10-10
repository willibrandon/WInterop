﻿// ------------------------
//    WInterop Framework
// ------------------------

// Copyright (c) Jeremy W. Kuhne. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WInterop.FileManagement.Types
{
    public struct FILE_REPARSE_POINT_INFORMATION
    {
        // https://msdn.microsoft.com/en-us/library/windows/hardware/ff540354.aspx
        // https://msdn.microsoft.com/en-us/library/cc232086.aspx

        /// <summary>
        /// File reference number generated by NTFS.
        /// </summary>
        public long FileReference;

        /// <summary>
        /// The reparse point tag.
        /// </summary>
        public ReparseTag Tag;
    }
}
