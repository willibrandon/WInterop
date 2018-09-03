﻿// ------------------------
//    WInterop Framework
// ------------------------

// Copyright (c) Jeremy W. Kuhne. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using WInterop.Windows;

namespace WInterop.Clipboard.Unsafe
{
    /// <summary>
    /// Direct usage of Imports isn't recommended. Use the wrappers that do the heavy lifting for you.
    /// </summary>
    public static partial class Imports
    {
        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649048.aspx
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern bool OpenClipboard(
            WindowHandle hWndNewOwner);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649035.aspx
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern bool CloseClipboard();

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649037.aspx
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern bool EmptyClipboard();

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649047.aspx
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern bool IsClipboardFormatAvailable(
            uint format);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649039.aspx
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr GetClipboardData(
            uint uFormat);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649036.aspx
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern int CountClipboardFormats();

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649041.aspx
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern WindowHandle GetClipboardOwner();

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649040.aspx
        [DllImport(Libraries.User32, SetLastError = true,ExactSpelling = true)]
        public static extern int GetClipboardFormatNameW(
            uint format,
            SafeHandle lpszFormatName,
            int cchMaxCount);

        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public unsafe static extern bool GetUpdatedClipboardFormats(
            ref uint lpuiFormats,
            uint cFormats,
            out uint pcFormatsOut);

        // https://msdn.microsoft.com/en-us/library/windows/desktop/ms649045.aspx
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern int GetPriorityClipboardFormat(
            uint[] paFormatPriorityList,
            int cFormats);
    }
}