using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace off
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.FileName = "cmd";
            
            try
            {
                p.Start();
                if(args.Length > 0)
                    p.StandardInput.WriteLine("shutdown /s /t " + args[0]);
                else
                    p.StandardInput.WriteLine("shutdown /s /t 120");
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
