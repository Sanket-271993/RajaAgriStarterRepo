using System.Threading.Tasks;

namespace NavistarOCCApp.Common
{
    /// <summary>
    /// This class is using Secure Storage and Preference to store the values.
    /// </summary>
    public class StorageServiceProvider
    {
        private readonly SecureStorage _secureStorage;
        private readonly Preference _preference;
        private static StorageServiceProvider _instance = null;

        /// <summary>
        /// Getting single instance of the class.
        /// </summary>
        public static StorageServiceProvider Instance
        {
            get
            {
                return _instance ?? new StorageServiceProvider();
            }
        }

        private StorageServiceProvider()
        {
            _secureStorage = SecureStorage.Instance;
            _preference = Preference.Instance;
        }

        /// <summary>
        /// Writing the value inside Secure storage if shouldStoreInSecureStorage is true,
        /// otherwise using Preference to store the value.
        /// </summary>
        /// <param name="key">Key to identify the value.</param>
        /// <param name="value">Value that need to be stored</param>
        /// <param name="shouldStoreInSecureStorage">If true then use Secure stoarage else use prefernce.</param>
        public void Write(string key, string value, bool shouldStoreInSecureStorage)
        {
            if (shouldStoreInSecureStorage)
            {
                _secureStorage.Write(key, value);
            }
            else
            {
                _preference.Write(key, value);
            }
        }

        /// <summary>
        /// Fetching the value.
        /// </summary>
        /// <param name="key">Key for identifying</param>
        /// <param name="shouldStoreInSecureStorage">If true then fetch the value from Secure storage,
        /// else fetch value from Preference.</param>
        /// <returns></returns>
        public async Task<string> Read(string key, bool shouldStoreInSecureStorage)
        {
            return shouldStoreInSecureStorage ? await _secureStorage.Read(key) : _preference.Read(key);
        }
    }
}
