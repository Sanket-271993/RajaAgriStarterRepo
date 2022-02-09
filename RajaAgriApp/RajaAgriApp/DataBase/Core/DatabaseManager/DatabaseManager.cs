namespace Database
{
    /// <summary>
    /// This class is used for setup the database environment
    /// </summary>
    public class DatabaseManager:IDatabaseManager
    {
        DatabaseHelper _databaseHelper;

        public DatabaseManager(string path)
        {
            SetDatabasePath(path: path);
            _databaseHelper = new DatabaseHelper(DatabaseName.RajaAgriAppDB);
        }

        /// <summary>
        /// Create Tables & Connect Database using TrainHigherDatabase class
        /// </summary>
        public void SetUp()
        {
            DatabaseBuilder databseBuilder = new NaviStarOccDatabase(_databaseHelper);
            databseBuilder.SetUp();
        }

        /// <summary>
        /// Set path of the database
        /// </summary>
        /// <param name="path"></param>
        public void SetDatabasePath(string path)
        {
            DatabasePath.Path = path;
        }
    }
}
