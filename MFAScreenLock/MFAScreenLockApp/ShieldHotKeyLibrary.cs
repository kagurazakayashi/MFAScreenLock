namespace MFAScreenLockApp
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// 热键屏蔽处理类
    /// 引用自 https://blog.csdn.net/AsynSpace/article/details/102572049
    /// </summary>
    internal class HotKeyHandler
        {

            public static HotKeyHandler Instance { get; } = new HotKeyHandler();

        public HotKeyHandler()
            {

            }

            #region dll


            [DllImport("ntdll.dll")]
            public static extern int ZwSuspendProcess(IntPtr ProcessId);
            [DllImport("ntdll.dll")]
            public static extern int ZwResumeProcess(IntPtr ProcessId);


            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

            // 卸载钩子
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern bool UnhookWindowsHookEx(int idHook);

            // 继续下一个钩子 
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

            // 取得当前线程编号
            [DllImport("kernel32.dll")]
            private static extern int GetCurrentThreadId();

            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
            private static extern short GetKeyState(int vKey);



            #endregion

            #region 变量声明

            public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
            private HookProc KeyboardHookProcedure;

            private const byte LLKHF_ALTDOWN = 0x20;
            private const byte VK_CAPITAL = 0x14;
            private const byte VK_ESCAPE = 0x1B;
            private const byte VK_F4 = 0x73;
            private const byte VK_LCONTROL = 0xA2;
            private const byte VK_NUMLOCK = 0x90;
            private const byte VK_RCONTROL = 0xA3;
            private const byte VK_SHIFT = 0x10;
            private const byte VK_TAB = 0x09;
            private const int WH_KEYBOARD = 13;
            private const int WH_KEYBOARD_LL = 13;
            private const int WH_MOUSE = 7;
            private const int WH_MOUSE_LL = 14;
            private const int WM_KEYDOWN = 0x100;
            private const int WM_KEYUP = 0x101;
            private const int WM_LBUTTONDBLCLK = 0x203;
            private const int WM_LBUTTONDOWN = 0x201;
            private const int WM_LBUTTONUP = 0x202;
            private const int WM_MBUTTONDBLCLK = 0x209;
            private const int WM_MBUTTONDOWN = 0x207;
            private const int WM_MBUTTONUP = 0x208;
            private const int WM_MOUSEMOVE = 0x200;
            private const int WM_MOUSEWHEEL = 0x020A;
            private const int WM_RBUTTONDBLCLK = 0x206;
            private const int WM_RBUTTONDOWN = 0x204;
            private const int WM_RBUTTONUP = 0x205;
            private const int WM_SYSKEYDOWN = 0x104;
            private const int WM_SYSKEYUP = 0x105;
            private static int hKeyboardHook = 0;

            /// <summary>
            /// 按键结构体
            /// </summary>
            public struct KeyBoardHookStruct
            {
                public int vkCode;
                int scanCode;
                public int flags;
                int time;
                int dwExtraInfo;
            }

            #endregion


            #region 任务管理器

            /// <summary>
            /// 屏蔽任务管理器
            /// </summary>
            public void SuspendWinLogon()
            {
                Process[] pc = Process.GetProcessesByName("winlogon");
                if (pc.Length > 0)
                {
                    ZwSuspendProcess(pc[0].Handle);
                }
            }


            /// <summary>
            /// 恢复任务管理器
            /// </summary>
            public void ResumeWinLogon()
            {
                Process[] pc = Process.GetProcessesByName("winlogon");
                if (pc.Length > 0)
                {
                    ZwResumeProcess(pc[0].Handle);
                }
            }


            #endregion

            #region 键盘钩子
            /// <summary>
            /// 钩子回调函数，在这里屏蔽热键。
            /// </summary>
            /// <param name="nCode"></param>
            /// <param name="wParam"></param>
            /// <param name="lParam"></param>
            /// <returns></returns>
            private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
            {
                if (nCode >= 0)
                {
                    KeyBoardHookStruct kbh = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));

                    if (
                        //左边WIN键
                        kbh.vkCode == 91 ||
                        //右边WIN键
                        kbh.vkCode == 92 ||
                        //左边SHIFT键
                        kbh.vkCode == 160 ||
                        //右边SHIFT键
                        kbh.vkCode == 161 ||
                        //Ctrl+ESC
                        (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control) ||
                        //ESC + Alt
                        (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Alt) ||
                        //ALT+F4
                        (kbh.vkCode == (int)Keys.F4 && (int)Control.ModifierKeys == (int)Keys.Alt) ||
                        //Tab + Alt
                        (kbh.vkCode == (int)Keys.Tab && (int)Control.ModifierKeys == (int)Keys.Alt) ||
                        //Ctrl + Alt + Delete
                        (kbh.vkCode == (int)Keys.Delete && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt) ||
                        //Esc + Ctrl + Alt
                        (kbh.vkCode == (int)Keys.Escape && (int)Control.ModifierKeys == (int)Keys.Control + (int)Keys.Alt)

                        )
                    {
                        return 1;
                    }
                }

                return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam);
            }


            /// <summary>
            /// 启动键盘热键Hook
            /// </summary>
            public void HookStart()
            {
                if (hKeyboardHook == 0)
                {
                    // 创建HookProc实例  
                    KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                    hKeyboardHook = SetWindowsHookEx(WH_KEYBOARD,
                                                     KeyboardHookProcedure,
                                                     Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().ManifestModule),
                                                     0);
                    // 如果设置钩子失败  
                    if (hKeyboardHook == 0)
                    {
                        HookStop();
                    }
                }
            }



            /// <summary>
            /// 停止键盘热键Hook
            /// </summary>
            public void HookStop()
            {
                bool retKeyboard = true;
                if (hKeyboardHook != 0)
                {
                    retKeyboard = UnhookWindowsHookEx(hKeyboardHook);
                    hKeyboardHook = 0;
                }
                if (!(retKeyboard))
                {
                    throw new Exception("UnhookWindowsHookEx Error");
                }
            }

            #endregion



        }
}
