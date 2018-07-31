﻿// ------------------------
//    WInterop Framework
// ------------------------

// Copyright (c) Jeremy W. Kuhne. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Drawing;
using System.Text;
using WInterop.Gdi;
using WInterop.Windows;
using WInterop.Support;

namespace KeyView1
{
    /// <summary>
    /// Sample from Programming Windows, 5th Edition.
    /// Original (c) Charles Petzold, 1998
    /// Figure 6-3, Pages 236-240.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Windows.CreateMainWindowAndRun(new KeyView1(), "Keyboard Message Viewer #1");
        }
    }

    class KeyView1 : WindowClass
    {
        int cxClientMax, cyClientMax, cxClient, cyClient, cxChar, cyChar;
        int cLinesMax, cLines;
        Rectangle rectScroll;
        MSG[] pmsg;

        StringBuilder _sb = new StringBuilder(256);
        char[] _chunk;

        protected override LRESULT WindowProcedure(WindowHandle window, WindowMessage message, WPARAM wParam, LPARAM lParam)
        {
            switch (message)
            {
                case WindowMessage.Create:
                    _chunk = _sb.GetChunk();
                    goto case WindowMessage.DisplayChange;
                case WindowMessage.DisplayChange:
                    // Get maximum size of client area
                    cxClientMax = Windows.GetSystemMetrics(SystemMetric.CXMAXIMIZED);
                    cyClientMax = Windows.GetSystemMetrics(SystemMetric.CYMAXIMIZED);

                    // Get character size for fixed-pitch font
                    using (DeviceContext dc = window.GetDeviceContext())
                    {
                        dc.SelectObject(StockFont.SystemFixed);
                        dc.GetTextMetrics(out TEXTMETRIC tm);
                        cxChar = tm.tmAveCharWidth;
                        cyChar = tm.tmHeight;
                    }

                    cLinesMax = cyClientMax / cyChar;
                    pmsg = new MSG[cLinesMax];
                    cLines = 0;
                    goto CalculateScroll;
                case WindowMessage.Size:
                    cxClient = lParam.LowWord;
                    cyClient = lParam.HighWord;

                    CalculateScroll:

                    rectScroll = Rectangle.FromLTRB(0, cyChar, cxClient, cyChar * (cyClient / cyChar));
                    window.Invalidate(true);

                    return 0;
                case WindowMessage.KeyDown:
                case WindowMessage.KeyUp:
                case WindowMessage.Char:
                case WindowMessage.DeadChar:
                case WindowMessage.SystemKeyDown:
                case WindowMessage.SystemKeyUp:
                case WindowMessage.SystemChar:
                case WindowMessage.SystemDeadChar:
                    // Rearrange storage array
                    for (int i = cLinesMax - 1; i > 0; i--)
                    {
                        pmsg[i] = pmsg[i - 1];
                    }
                    // Store new message
                    pmsg[0].hwnd = window;
                    pmsg[0].message = message;
                    pmsg[0].wParam = wParam;
                    pmsg[0].lParam = lParam;
                    cLines = Math.Min(cLines + 1, cLinesMax);

                    // Scroll up the display
                    window.ScrollWindow(new Point(0, -cyChar), rectScroll, rectScroll);
                    break; // i.e., call DefWindowProc so Sys messages work
                case WindowMessage.Paint:
                    using (DeviceContext dc = window.BeginPaint())
                    {
                        dc.SelectObject(StockFont.SystemFixed);
                        dc.SetBackgroundMode(BackgroundMode.Transparent);
                        dc.TextOut(default, "Message        Key       Char     Repeat Scan Ext ALT Prev Tran".AsSpan());
                        dc.TextOut(default, "_______        ___       ____     ______ ____ ___ ___ ____ ____".AsSpan());
                        for (int i = 0; i < Math.Min(cLines, cyClient / cyChar - 1); i++)
                        {
                            bool iType;
                            switch (pmsg[i].message)
                            {
                                case WindowMessage.Char:
                                case WindowMessage.SystemChar:
                                case WindowMessage.DeadChar:
                                case WindowMessage.SystemDeadChar:
                                    iType = true;
                                    break;
                                default:
                                    iType = false;
                                    break;
                            }

                            _sb.Clear();
                            _sb.AppendFormat(iType
                                ? "{0,-13} {1,3} {2,15} {3,6} {4,4} {5,3} {6,3} {7,4} {8,4}"
                                : "{0,-13} {1,3} {2,-15} {3,6} {4,4} {5,3} {6,3} {7,4} {8,4}  VirtualKey: {9}",
                                    pmsg[i].message,
                                    pmsg[i].wParam.ToString(),
                                    iType
                                        ? $"0x{((uint)pmsg[i].wParam):X4} {(char)(uint)pmsg[i].wParam}"
                                        : Windows.GetKeyNameText(pmsg[i].lParam),
                                    pmsg[i].lParam.LowWord,
                                    pmsg[i].lParam.HighWord & 0xFF,
                                    (0x01000000 & pmsg[i].lParam) != 0 ? "Yes" : "No",
                                    (0x20000000 & pmsg[i].lParam) != 0 ? "Yes" : "No",
                                    (0x40000000 & pmsg[i].lParam) != 0 ? "Down" : "Up",
                                    (0x80000000 & pmsg[i].lParam) != 0 ? "Up" : "Down",
                                    (VirtualKey)pmsg[i].wParam);

                            dc.TextOut(new Point(0, (cyClient / cyChar - 1 - i) * cyChar), _chunk.AsSpan(0, _sb.Length));
                        }
                    }
                    return 0;
            }

            return base.WindowProcedure(window, message, wParam, lParam);
        }
    }
}
