using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SW_Console_Controller_V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Encoding.UTF8.GetString(Convert.FromBase64String(args[0]));
            Properties properties = JsonConvert.DeserializeObject<Properties>(input);
            SWController controller = new SWController("C:\\Users\\tedva\\Documents\\1_MA-Ford\\V2\\Master models", properties);
            //controller.Update();
            //Console.ReadLine();
        }
    }
}
