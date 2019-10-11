﻿// ------------------------
//    WInterop Framework
// ------------------------

// Copyright (c) Jeremy W. Kuhne. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace WInterop.Errors
{
    /// <summary>
    /// Windows error facility codes
    /// </summary>
    public enum Facility : int
    {
        Null = 0,
        Rpc = 1,
        Dispatch = 2,
        Storage = 3,
        Itf = 4,
        Win32 = 7,
        Windows = 8,
        Sspi = 9,
        Security = 9,
        Control = 10,
        Cert = 11,
        Internet = 12,
        MediaServer = 13,
        Msmq = 14,
        SetupApi = 15,
        SCard = 16,
        ComPlus = 17,
        Aaf = 18,
        Urt = 19,
        Acs = 20,
        DPlay = 21,
        Umi = 22,
        Sxs = 23,
        WindowsCE = 24,
        Http = 25,
        UserModeCommonLog = 26,
        Wer = 27,
        UserModeFilterManager = 31,
        BackgroundCopy = 32,
        Configuration = 33,
        Wia = 33,
        StateManagement = 34,
        MetaDirectory = 35,
        WindowsUpdate = 36,
        DirectoryService = 37,
        Graphics = 38,
        Shell = 39,
        Nap = 39,
        TpmServices = 40,
        TpmSoftware = 41,
        Ui = 42,
        Xaml = 43,
        ActionQueue = 44,
        WindowsSetup = 48,
        Pla = 48,
        Fve = 49,
        Fwp = 50,
        WinRm = 51,
        Ndis = 52,
        UserModeHypervisor = 53,
        Cmi = 54,
        UserModeVirtualization = 55,
        UserModeVolmgr = 56,
        Bcd = 57,
        UserModeVhd = 58,
        SDiag = 60,
        WinPE = 61,
        WebServices = 61,
        Wpn = 62,
        WindowsStore = 63,
        Input = 64,
        Eap = 66,
        WindowsDefender = 80,
        Opc = 81,
        Xps = 82,
        Ras = 83,
        Mbn = 84,
        Powershell = 84,
        Eas = 85,
        P2pInt = 98,
        P2p = 99,
        VisualCpp = 109,
        Daf = 100,
        BluetoothAtt = 101,
        Audio = 102,
        Script = 112,
        Parse = 113,
        Blb = 120,
        BlbCli = 121,
        WsbApp = 122,
        BlbUI = 128,
        Usn = 129,
        UserModeVolSnap = 130,
        Tiering = 131,
        WsbOnline = 133,
        OnlineId = 134,
        Dls = 153,
        Sos = 160,
        Debuggers = 176,
        UserModeSpaces = 231,
        Spp = 256,
        Restore = 256,
        Dmserver = 256,
        DeploymentServicesServer = 257,
        DeploymentServicesImaging = 258,
        DeploymentServicesManagement = 259,
        DeploymentServicesUtil = 260,
        DeploymentServicesBinlsvc = 261,
        DeploymentServicesPxe = 263,
        DeploymentServicesTftp = 264,
        DeploymentServicesTransportManagement = 272,
        DeploymentServicesDriverProvisioning = 278,
        DeploymentServicesMulticastServer = 289,
        DeploymentServicesMulticastClient = 290,
        DeploymentServicesContentProvider = 293,
        LinguisticServices = 305,
        Web = 885,
        WebSocket = 886,
        AudioStreaming = 1094,
        Accelerator = 1536,
        Mobile = 1793,
        WmaaEcma = 1996,
        Wep = 2049,
        SyncEngine = 2050,
        DirectMusic = 2168,
        Direct3d10 = 2169,
        Dxgi = 2170,
        DxgiDdi = 2171,
        Direct3d11 = 2172,
        Leap = 2184,
        Audclnt = 2185,
        WincodecDWriteDwm = 2200,
        Direct2d = 2201,
        Defrag = 2304,
        UsermodeSdbus = 2305,
        Jscript = 2306,
        Pidgenx = 2561,
    }
}