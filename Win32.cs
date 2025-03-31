using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomListView
{
    internal class Win32
    {
        public const uint RDW_INVALIDATE = 0x0001;
        public const uint RDW_UPDATENOW = 0x0100;
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, uint flags);


        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr BeginPaint(IntPtr hWnd, out PAINTSTRUCT lpPaint);

        [DllImport("user32.dll")]
        public static extern bool EndPaint(IntPtr hWnd, [In] ref PAINTSTRUCT lpPaint);

        public const int HDM_GETITEMRECT = 0x1200 + 7;

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int msg, IntPtr wParam, out RECT lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;
            public RECT rcPaint;
            public bool fRestore;
            public bool fIncUpdate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
    }
}
