using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp2
{
    class Log
    {
        public string id { get; set; }
        public string no_kendaraan { get; set; }
        public string waktu_masuk { get; set; }
        public string waktu_keluar { get; set; }
        public string foto { get; set; }
        public string barcode { get; set; }
        public string rfid { get; set; }

        public Log(string Id, String no_kendaraan, String waktu_masuk, string waktu_keluar, string foto, string barcode, string rfid)
        {
            this.id = Id;
            this.no_kendaraan = no_kendaraan;
            this.waktu_masuk = waktu_masuk;
            this.waktu_keluar = waktu_keluar;
            this.foto = foto;
            this.barcode = barcode;
            this.rfid = rfid;
        }


    }
}
