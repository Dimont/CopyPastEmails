using System;
using System.Runtime.InteropServices;

namespace EmailAutomation
{
    class ClipboardHelper
    {
        [DllImport("user32.dll")]
        private static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        private static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        private static extern bool EmptyClipboard();

        [DllImport("user32.dll")]
        private static extern IntPtr SetClipboardData(uint uFormat, IntPtr data);

        [DllImport("user32.dll")]
        private static extern IntPtr GetClipboardData(uint uFormat);

        [DllImport("user32.dll")]
        private static extern int CountClipboardFormats();

        private const uint CF_UNICODETEXT = 13;

        public static void SetText(string text)
        {
            if (OpenClipboard(IntPtr.Zero))
            {
                EmptyClipboard();
                IntPtr hGlobal = Marshal.StringToHGlobalUni(text);
                SetClipboardData(CF_UNICODETEXT, hGlobal);
                CloseClipboard();
            }
        }
    }
}
