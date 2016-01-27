using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp2
{
    class User
    {
        public string id { get; set; }
        public string no_rfid { get; set; }
        public string nama { get; set; }

        public User(string Id, String no_rfid, String nama)
        {
            this.id = Id;
            this.no_rfid = no_rfid;
            this.nama = nama;
        }


    }
}
