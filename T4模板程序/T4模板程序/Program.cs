using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4模板程序
{
    class Program
    {
        static void Main(string[] args)
        {
            string testName = "Abc";
            var ress = testName.Substring(0, 1).ToLower() + testName.Substring(1);
        }
    }
}
