namespace Database
{
    /// <summary>
    /// This class is used to Connect the database
    /// </summary>
    public abstract class DatabaseBuilder
    {
        /// <summary>
        /// Connect the database and create the tables
        /// </summary>
        public abstract void SetUp();
    }
}
