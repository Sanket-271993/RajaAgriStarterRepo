using System;
using System.Collections.Generic;
using SQLite;

namespace Database
{
    /// <summary>
    /// This class provide the operations of database
    /// </summary>
    public class DatabaseHelper : IDatabaseHelper
    {
        public SQLiteConnection _database;
        public string ErrorMessage { get; set; }

        // Get and set the result of database based on true false
        public bool Result { get => _result == 1 ? true : false; }
        private int _result { get; set; }

        public SQLiteConnection SQLConnection { get => _database; }

        public DatabaseHelper(string name)
        {
            ConnectDatabase(name);
        }

        /// <summary>
        /// Connect Database
        /// </summary>
        /// <param name="name"></param>
        public void ConnectDatabase(string name)
        {
            var path = DatabasePath.Path + "/" + name;
            _database = new SQLiteConnection(databasePath: path);
        }

        /// <summary>
        /// Creates the table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int CreateTable<T>()
        {
            return (int)_database.CreateTable<T>();
        }

         
        /// <summary>
        /// Perform Query operations
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<T> Query<T>(string query) where T : new()
        {
            try
            {
                var result = _database.Query<T>(query: query);
                return result;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                _result = 0;
                return null;
            }
        }

        /// <summary>
        /// Inserts or replaces values in table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void InsertOrReplace<T>(T value)
        {
            try
            {
                _result = _database.InsertOrReplace(obj: value);
            }
            catch (SQLiteException ex)
            {
                ErrorMessage = ex.Message;
                _result = 0;
            }
        }

        /// <summary>
        /// Deletes value from table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public int Delete<T>(T value)
        {
            try
            {
                _result = _database.Delete(value);
            }
            catch (SQLiteException ex)
            {
                ErrorMessage = ex.Message;
                _result = 0;
            }
            return _result;
        }

        /// <summary>
        /// Inserts  values in table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void Insert<T>(T value)
        {
            try
            {
                _result = _database.Insert(obj: value);
            }
            catch (SQLiteException ex)
            {
                ErrorMessage = ex.Message;
                _result = 0;
            }
        }
        /// <summary>
        /// Updates  values in table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public void Update<T>(T value)
        {
            try
            {
                _result = _database.Update(obj: value);
            }
            catch (SQLiteException ex)
            {
                ErrorMessage = ex.Message;
                _result = 0;
            }
        }

        /// <summary>
        /// Clears Table
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int ClearTable(string tableName)
        {
            return _database.Execute(query: "delete from " + tableName);
        }
    }
}
