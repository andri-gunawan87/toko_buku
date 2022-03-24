using Toko_Buku.Models;

namespace Toko_Buku.Services
{
    public class DataBukuService : IDataBukuService
    {

        List<DataBuku> _dataBukuList;
        string line;
        string[] dataLine = new string[3];
        public DataBukuService()
        {
            using (StreamReader sr = new StreamReader("database.txt"))
            {
                _dataBukuList = new List<DataBuku>
                { };
                while ((line = sr.ReadLine()) != null)
                {
                    dataLine = line.Split(", ");
                    _dataBukuList.Add(new DataBuku(Convert.ToInt32(dataLine[0]), dataLine[1], Convert.ToInt32(dataLine[2]), dataLine[3]));
                }
            }
        }

        public void AddData(DataBuku request)
        {
            using (StreamWriter writer = new StreamWriter("database.txt", true))
            {
                writer.Write("\n{0}, {1}, {2}, {3}", request.Id, request.Judul, request.Harga, request.User);
            }
        }

        public List<DataBukuViewModel> GetDataBukus()
        {
            List<DataBukuViewModel> _dataViewModels = new List<DataBukuViewModel>();
            foreach (var item in _dataBukuList)
            {
                _dataViewModels.Add(new DataBukuViewModel(item.Judul, item.Harga));
            }
            
        return _dataViewModels;
        }

        public List<DataBuku> GetDataBukusServer()
        {
            return _dataBukuList;
        }
    }
}
