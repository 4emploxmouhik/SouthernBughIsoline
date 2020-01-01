using System.Collections.Generic;

namespace DataAccess
{
    public interface IDataAccess
    {
        bool DbExist(string connectionString);
        T GetCellData<T>(string sql);
        List<T> GetColumnData<T>(string sql);
    }
}
