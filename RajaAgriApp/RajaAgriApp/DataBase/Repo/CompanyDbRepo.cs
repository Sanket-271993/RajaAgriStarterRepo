using System.Collections.Generic;

namespace Database
{
    public class CompanyDbRepo
    {
        private DatabaseHelper _sqliteHelper;
        public bool Result { get => _sqliteHelper.Result == true ? true : false; }
        public string Message { get => _sqliteHelper.ErrorMessage; }

        public CompanyDbRepo()
        {
            _sqliteHelper = new DatabaseHelper(DatabaseName.RajaAgriAppDB);
        }

        public List<Company> GetCompanyDetails()
        {
            return _sqliteHelper.SQLConnection.Table<Company>().ToList();
        }

        /// <summary>
        /// Insert Login Details into database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(Company company)
        {
            _sqliteHelper.Insert(company);
            return _sqliteHelper.Result;
        }

        public bool ClearAll()
        {
            _sqliteHelper.ClearTable(CompanyInfo.TableName);
            return _sqliteHelper.Result;
        }

        public bool Update(Company company)
        {
            _sqliteHelper.Update(company);
            return _sqliteHelper.Result;
        }
    }
}
