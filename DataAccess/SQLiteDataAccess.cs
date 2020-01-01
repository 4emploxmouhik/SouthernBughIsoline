using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class SQLiteDataAccess : BaseDataAccess, IDataAccess
    {
        public SQLiteDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool DbExist(string connectionString)
        {
            throw new NotImplementedException();
        }

        public T GetCellData<T>(string sql)
        {
            throw new NotImplementedException();
        }

        public List<T> GetColumnData<T>(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
