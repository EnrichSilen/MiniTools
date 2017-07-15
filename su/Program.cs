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
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Verb = "runas";

            try
            {
                p.Start();
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
