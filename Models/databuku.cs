namespace Toko_Buku.Models
{
    public class DataBuku
    {
        public int Id { get; set; }
        public string Judul { get; set; }
        public int Harga { get; set; }
        public string User { get; set; }

        public DataBuku(int id, string judul, int harga, string user)
        {
            Id = id;
            Judul = judul;
            Harga = harga;
            User = user;
        }
    }
}
