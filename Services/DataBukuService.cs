using Toko_Buku.Models;

namespace Toko_Buku.Services
{
    public class DataBukuService : IDataBukuService
    {

        List<DataBuku> _dataBukuList;
        
        private const string FILE_NAME = "database.txt";
        // Cara Lama
        //
        // string line;
        // string[] dataLine = new string[3];
        //
        //public void AddData(DataBuku request)
        //{
        //    using (StreamWriter writer = new StreamWriter("database.txt", true))
        //    {
        //        writer.Write("\n{0}, {1}, {2}, {3}", request.Id, request.Judul, request.Harga, request.User);
        //    }
        //}
        //public List<DataBukuViewModel> GetDataBukus()
        //{
        //    List<DataBukuViewModel> _dataViewModels = new List<DataBukuViewModel>();
        //    using (StreamReader sr = new StreamReader("database.txt"))
        //    {
        //        _dataBukuList = new List<DataBuku>
        //        { };
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            dataLine = line.Split(", ");
        //            _dataBukuList.Add(new DataBuku(Convert.ToInt32(dataLine[0]), dataLine[1], Convert.ToInt32(dataLine[2]), dataLine[3]));
        //        }
        //    }
        //    foreach (var item in _dataBukuList)
        //    {
        //        _dataViewModels.Add(new DataBukuViewModel(item.Id, item.Judul, item.Harga));
        //    }

        //    return _dataViewModels;
        //}

        public async Task<List<DataBukuViewModel>> ReadViewModel()
        {
            if (!File.Exists(System.AppContext.BaseDirectory + FILE_NAME))
            {
                return new List<DataBukuViewModel>();
            }
            var res = await File.ReadAllLinesAsync(System.AppContext.BaseDirectory + FILE_NAME);
            if(res == null)
                return new List<DataBukuViewModel>();
            List<DataBukuViewModel> list = new List<DataBukuViewModel>();
            foreach (var item in res)
            {
                var dataSplit = item.Split(", ").ToArray();
                list.Add(new DataBukuViewModel(int.Parse(dataSplit[0]), dataSplit[1], int.Parse(dataSplit[2])));
            }
             
            return list;
        }

        public async Task Write(DataBuku request)
        {
            if (!File.Exists(System.AppContext.BaseDirectory + FILE_NAME))
            {
                using (var fileStream = File.Create(System.AppContext.BaseDirectory + FILE_NAME))
                {
                    fileStream.Close();
                }
            }
            using (var fileStream = File.AppendText(System.AppContext.BaseDirectory + FILE_NAME))
            {
                await fileStream.WriteLineAsync($"\n{request.Id}, {request.Judul}, {request.Harga}, {request.User}");
            }
        }

        public async Task<DataBuku> GetDetail(int id)
        {
            DataBuku getDetail = new DataBuku(11, "qq", 12, "121");
            //if (!File.Exists(System.AppContext.BaseDirectory + FILE_NAME))
            //{
            //    return null;
            //}
            var res = await File.ReadAllLinesAsync(System.AppContext.BaseDirectory + FILE_NAME);
            //if (res == null)
            //    return null;
          
            foreach (var item in res)
            {
                var dataSplit = item.Split(", ").ToArray();
                if (int.Parse(dataSplit[0]) == id)
                {
                    getDetail = new DataBuku(int.Parse(dataSplit[0]), dataSplit[1], int.Parse(dataSplit[2]), dataSplit[3]);
                }
            }

            if (getDetail == null)
            {
                return null;
            }
            return getDetail;

        }

        public List<DataBuku> GetDataBukusServer()
        {
            return _dataBukuList;
        }
    }
}
