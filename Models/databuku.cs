namespace Toko_Buku.Models
{
    public class databuku
    {
        public string Judul { get; set; }
        public int Harga { get; set; }
        public databuku(string judul, int harga)
        {
            Judul = judul;
            Harga = harga;
        }
    }
}
