using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Toko_Buku.Models
{
    public class DataBukuViewModel
    {
        public string Judul { get; set; }
        public int Harga { get; set; }

        public DataBukuViewModel(string judul, int harga)
        {
            Judul = judul;
            Harga = harga;
        }
    }
}
