using Toko_Buku.Models;

namespace Toko_Buku.Services
{
    public interface IDataBukuService
    {
        //Cara lama
        //List<DataBukuViewModel> GetDataBukus();
        //public void AddData(DataBuku request);
        Task<List<DataBukuViewModel>> ReadViewModel();
        Task Write(DataBuku request);
        Task<DataBuku> GetDetail(int id);
        List<DataBuku> GetDataBukusServer();
    }
}
