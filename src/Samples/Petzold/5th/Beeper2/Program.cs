﻿// ------------------------
//    WInterop Framework
// ------------------------

// Copyright (c) Jeremy W. Kuhne. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Drawing;
using WInterop.Gdi;
using WInterop.Windows;

namespace Beeper2
{
    /// <summary>
    /// Sample from Programming Windows, 5th Edition.
    /// Original (c) Charles Petzold, 1998
    /// Figure 8-2, Pages 335-337.
    /// </summary>
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Windows.CreateMainWindowAndRun(new Beeper2(), "Timer Procedure");
        }
    }

    class Beeper2 : WindowClass
    {
        static bool fFlipFlop = false;
        const int ID_TIMER = 1;

        protected override LRESULT WindowProcedure(WindowHandle window, WindowMessage message, WPARAM wParam, LPARAM lParam)
        {
            switch (message)
            {
                case WindowMessage.Create:
                    window.SetTimer(ID_TIMER, 1000, TimerProcedure);
                    return 0;
                case WindowMessage.Destroy:
                    window.KillTimer(ID_TIMER);
                    break;
            }

            return base.WindowProcedure(window, message, wParam, lParam);
        }

        static void TimerProcedure(WindowHandle window, WindowMessage message, TimerId timerId, uint time)
        {
            Windows.MessageBeep();
            fFlipFlop = !fFlipFlop;
            using (DeviceContext dc = window.GetDeviceContext())
            {
                using (BrushHandle brush = Gdi.CreateSolidBrush(fFlipFlop ? Color.Red : Color.Blue))
                {
                    dc.FillRectangle(window.GetClientRectangle(), brush);
                }
            }
        }
    }
}
