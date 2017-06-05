using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace logoff
{
    class Program
    {

        [DllImport("wtsapi32.dll", SetLastError = true)]
        static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);

        [DllImport("Kernel32.dll", SetLastError = true)]
        static extern UInt32 WTSGetActiveConsoleSessionId();

        static readonly IntPtr WTS_CURRENT_SERVER_HANDLE = IntPtr.Zero;

        static void Main(string[] args)
        {
            if (WTSDisconnectSession(WTS_CURRENT_SERVER_HANDLE, int.Parse(WTSGetActiveConsoleSessionId().ToString()), false))
                throw new Win32Exception();
        }
    }
}
