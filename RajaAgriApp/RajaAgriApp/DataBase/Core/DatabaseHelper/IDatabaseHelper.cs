using System.Collections.Generic;
using SQLite;

namespace Database
{
    /// <summary>
    /// This interface will provide all the needed operations related database
    /// </summary>
    public interface IDatabaseHelper
    {
        /// <summary>
        /// Get or Set error messege 
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Get Result from database operations
        /// </summary>
        bool Result { get; }

        // Connect with database
        void ConnectDatabase(string name);

        /// <summary>
        /// Clear the table
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        int ClearTable(string tableName);

        /// <summary>
        /// Create the table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        int CreateTable<T>();

        /// <summary>
        /// Insert Data in table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        void Insert<T>(T value);

        /// <summary>
        /// Insert Or Replace the data in table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        void InsertOrReplace<T>(T value);

        /// <summary>
        /// Return data using specific query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        List<T> Query<T>(string query) where T : new();

        /// <summary>
        /// Update the Data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        void Update<T>(T value);

        /// <summary>
        /// Delete the data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        int Delete<T>(T value);
    }
}