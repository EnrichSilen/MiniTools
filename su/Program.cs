using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace su
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.CreateNoWindow = false;
            proc.FileName = "cmd";
            proc.Verb = "runas";
            try
            {
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
