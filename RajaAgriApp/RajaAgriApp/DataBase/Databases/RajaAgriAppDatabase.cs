using RajaAgriApp.Models;

namespace Database
{ 
    /// <summary>
    /// This class is used for connecting database and for create tables
    /// </summary>
    public class NaviStarOccDatabase : DatabaseBuilder
    {
        readonly DatabaseHelper _databaseHelper;

        public NaviStarOccDatabase(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        /// <summary>
        /// Create Tables & Connect Database
        /// </summary>
        public override void SetUp()
        {
            _databaseHelper.ConnectDatabase(name: DatabaseName.RajaAgriAppDB);
            // Create table here
           // _databaseHelper.CreateTable<LoginResponseModel>();
           
        }
    }
}