using System;
using System.Diagnostics;

namespace WindowsUtils.Core
{
    public class Runner
    {
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