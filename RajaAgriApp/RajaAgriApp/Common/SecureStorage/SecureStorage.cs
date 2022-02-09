using System.Threading.Tasks;
using Storage = Xamarin.Essentials.SecureStorage;

namespace NavistarOCCApp.Common
{
    /// <summary>
    /// This class will use Secure storage(Xamarin.Essentials) to store the value.
    /// </summary>
     class SecureStorage
    {
        private static SecureStorage _instance = null;

        private SecureStorage() { }

        /// <summary>
        /// Getting single instance of the class.
        /// </summary>
        public static SecureStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SecureStorage();
                }
                return _instance;
            }
        }

        private string value = string.Empty;

        /// <summary>
        /// Writing the value inside Secure storage.
        /// </summary>
        /// <param name="key">Key of secure storage value to identify.</param>
        /// <param name="value">Value that need to be stored.</param>
        public async void Write(string key, string value)
        {
            if(!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                await Storage.SetAsync(key, value);
            }
        }

        /// <summary>
        /// Reading the value inside Secure storage.
        /// </summary>
        /// <param name="key">Key of secure storage value to identify</param>
        public async Task<string> Read(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                value = await Storage.GetAsync(key);
            }
            return value;
        }
    }
}
