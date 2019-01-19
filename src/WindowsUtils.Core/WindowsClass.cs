using System;
using System.Runtime.InteropServices;

namespace WindowsUtils.Core
{
    public class WindowsClass
    {
        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        const int WM_SETTEXT = 0x000c;
    }

    public class Helper{
        
        public static IntPtr FindEditInNotepad()
        {
            IntPtr hWndToEdit = IntPtr.Zero;
            string NotepadParentClass = "Notepad";
            string NotepadParentWindowCaption = "Untitled - Notepad";
            string NotepadEditClass = "Edit";

            IntPtr ParenthWnd = new IntPtr(0);
            IntPtr hWnd = new IntPtr(0);
            ParenthWnd = WindowsClass.FindWindow(NotepadParentClass, NotepadParentWindowCaption);
            if (ParenthWnd.Equals(IntPtr.Zero))
                Trace.WriteLine("Notepad Not Running");
            else
            {
                hWnd = WindowsClass.FindWindowEx(ParenthWnd, hWnd, NotepadEditClass, "");
                if (hWnd.Equals(IntPtr.Zero))
                    Trace.WriteLine("Can't find Edit component in Notepad");
                else
                {
                    Trace.WriteLine(String.Format("Notepad Window: {0} in Hex: {1}", ParenthWnd.ToString(), ParenthWnd.ToString("X")));
                    Trace.WriteLine(String.Format("Edit Control: {0} in Hex: {1}", hWnd.ToString(), hWnd.ToString("X")));
                    hWndToEdit = hWnd;
                }
            }
            return hWndToEdit;
        }
    }
}
