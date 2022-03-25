using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Toko_Buku.Models
{
    public class DataBukuViewModel
    {
        public int Id { get; set; }
        public string Judul { get; set; }
        public int Harga { get; set; }

        public DataBukuViewModel(int id, string judul, int harga)
        {
            Id = id;
            Judul = judul;
            Harga = harga;
        }
    }
}
