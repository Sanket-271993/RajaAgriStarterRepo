using Xamarin.Essentials;

namespace NavistarOCCApp.Common
{

    /// <summary>
    /// This class is using Preference(Xamarin Essentials) to store the value.
    /// </summary>
    class Preference
    {
        private static Preference _instance = null;
        private string value = string.Empty;

        /// <summary>
        /// Getting single instance of the class.
        /// </summary>
        public static Preference Instance
        {
            get
            {
                return _instance ?? new Preference();
            }
        }

        /// <summary>
        /// Writing the value inside preference.
        /// </summary>
        /// <param name="key">Key of preference value to identify</param>
        /// <param name="value">Value that need to be stored.</param>
        public void Write(string key, string value)
        {
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
            {
                Preferences.Set(key, value);
            }
        }

        /// <summary>
        /// Reading the value inside preference.
        /// </summary>
        /// <param name="key">Key of preference value to identify</param>
        public string Read(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                value = Preferences.Get(key, string.Empty);
            }
            return value;
        }

        public void Clear(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                   Preferences.Remove(key);
            }
          
        }
    }
}
