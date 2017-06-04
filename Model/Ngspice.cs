using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Model
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ngcomplex
    {
        /// double
        public double cx_real;
        /// double
        public double cx_imag;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vector_info
    {
        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string v_name;
        /// int
        public int v_type;
        /// short
        public short v_flags;
        /// double*
        public IntPtr v_realdata;
        /// ngcomplex_t*
        public IntPtr v_compdata;
        /// int
        public int v_length;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vecvalues
    {
        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;
        /// double
        public double creal;
        /// double
        public double cimag;
        /// boolean
        [MarshalAs(UnmanagedType.I1)]
        public bool is_scale;
        /// boolean
        [MarshalAs(UnmanagedType.I1)]
        public bool is_complex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vecvaluesall
    {
        /// int
        public int veccount;
        /// int
        public int vecindex;
        /// pvecvalues*
        public IntPtr vecsa;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vecinfo
    {
        /// int
        public int number;
        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string vecname;
        /// boolean
        [MarshalAs(UnmanagedType.I1)]
        public bool is_real;
        /// void*
        public IntPtr pdvec;
        /// void*
        public IntPtr pdvecscale;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct vecinfoall
    {
        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string name;
        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string title;
        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string date;
        /// char*
        [MarshalAs(UnmanagedType.LPStr)]
        public string type;
        /// int
        public int veccount;
        /// pvecinfo*
        public IntPtr vecs;
    }

    /// Return Type: int
    ///param0: char*
    ///param1: int
    ///param2: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SendChar(IntPtr param0, int param1, IntPtr param2);

    /// Return Type: int
    ///param0: char*
    ///param1: int
    ///param2: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SendStat(IntPtr param0, int param1, IntPtr param2);

    /// Return Type: int
    ///param0: int
    ///param1: boolean
    ///param2: boolean
    ///param3: int
    ///param4: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int ControlledExit(int param0, [MarshalAs(UnmanagedType.I1)] bool param1, [MarshalAs(UnmanagedType.I1)] bool param2, int param3, IntPtr param4);

    /// Return Type: int
    ///param0: pvecvaluesall->vecvaluesall*
    ///param1: int
    ///param2: int
    ///param3: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SendData(IntPtr param0, int param1, int param2, IntPtr param3);

    /// Return Type: int
    ///param0: pvecinfoall->vecinfoall*
    ///param1: int
    ///param2: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int SendInitData(IntPtr param0, int param1, IntPtr param2);

    /// Return Type: int
    ///param0: boolean
    ///param1: int
    ///param2: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int BGThreadRunning([MarshalAs(UnmanagedType.I1)] bool param0, int param1, IntPtr param2);

    /// Return Type: int
    ///param0: double*
    ///param1: double
    ///param2: char*
    ///param3: int
    ///param4: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int GetVSRCData(IntPtr param0, double param1, IntPtr param2, int param3, IntPtr param4);

    /// Return Type: int
    ///param0: double*
    ///param1: double
    ///param2: char*
    ///param3: int
    ///param4: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int GetISRCData(IntPtr param0, double param1, IntPtr param2, int param3, IntPtr param4);

    /// Return Type: int
    ///param0: double
    ///param1: double*
    ///param2: double
    ///param3: int
    ///param4: int
    ///param5: int
    ///param6: void*
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int GetSyncData(double param0, IntPtr param1, double param2, int param3, int param4, int param5, IntPtr param6);

    public partial class Ngspice
    {

        /// Return Type: int
        ///printfcn: SendChar*
        ///statfcn: SendStat*
        ///ngexit: ControlledExit*
        ///sdata: SendData*
        ///sinitdata: SendInitData*
        ///bgtrun: BGThreadRunning*
        ///userData: void*
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngSpice_Init", 
            SetLastError = true,
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int ngSpice_Init(IntPtr printfcn, IntPtr statfcn, IntPtr ngexit, IntPtr sdata, IntPtr sinitdata, IntPtr bgtrun, IntPtr userData);


        /// Return Type: int
        ///vsrcdat: GetVSRCData*
        ///isrcdat: GetISRCData*
        ///syncdat: GetSyncData*
        ///ident: int*
        ///userData: void*
        [DllImport("../../../source/ngspice.dll",
            EntryPoint = "ngSpice_Init_Sync",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int ngSpice_Init_Sync(IntPtr vsrcdat, IntPtr isrcdat, IntPtr syncdat, IntPtr ident, IntPtr userData);


        /// Return Type: int
        ///command: char*
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngSpice_Command",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int ngSpice_Command([MarshalAs(UnmanagedType.LPStr)]string command);


        /// Return Type: pvector_info->vector_info*
        ///vecname: char*
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngGet_Vec_Info",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ngGet_Vec_Info([MarshalAs(UnmanagedType.LPStr)]string vecname);


        /// Return Type: int
        ///circarray: char**
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngSpice_Circ",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern int ngSpice_Circ(IntPtr circarray);


        /// Return Type: char*
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngSpice_CurPlot",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ngSpice_CurPlot();


        /// Return Type: char**
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngSpice_AllPlots",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ngSpice_AllPlots();


        /// Return Type: char**
        ///plotname: char*
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngSpice_AllVecs",
            CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ngSpice_AllVecs([MarshalAs(UnmanagedType.LPStr)]string plotname);


        /// Return Type: boolean
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngSpice_running",
            CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ngSpice_running();


        /// Return Type: boolean
        ///time: double
        [DllImport("../../../source/ngspice.dll", 
            EntryPoint = "ngSpice_SetBkpt",
            CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ngSpice_SetBkpt(double time);

            }
}
