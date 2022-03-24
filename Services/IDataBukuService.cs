using Toko_Buku.Models;

namespace Toko_Buku.Services
{
    public interface IDataBukuService
    {
        List<DataBukuViewModel> GetDataBukus();
        List<DataBuku> GetDataBukusServer();
        public void AddData(DataBuku request);
    }
}
