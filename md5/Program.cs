using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace md5
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Console.WriteLine("invalid or no input");
                return;
            }
            byte[] hash;
            using (var md5 = new MD5Cng())
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(args[0]));
            Console.WriteLine(BitConverter.ToString(hash).Replace("-", ""));
        }
    }
}
