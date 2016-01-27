using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp2
{
    static class DataBase
    {
        public static string dbAddr = "";
        public static string server = "";
        public static string db = "";
        public static string uid = "";
        public static string pwd = "";

        public static void readConf()
        {
            string[] lines = System.IO.File.ReadAllLines(@"conf.txt");

            // Display the file contents by using a foreach loop.
            try
            {
                server = lines[2];
            }
            catch (Exception)
            {
                server = "";
            }

            try
            {
                db = lines[3];
            }
            catch (Exception)
            {
                db = "";
            }

            //uid = "balimukti";
            //pwd = "8aliMukti";

            uid = "root";
            pwd = "";

            dbAddr = "server="+server+";database="+db+";uid="+uid+";password="+pwd;
            //dbAddr = "server=" + server + ";database=" + db + ";uid=" + uid + ";password=" + pwd;
            Console.WriteLine(dbAddr);
        }
    }
}
