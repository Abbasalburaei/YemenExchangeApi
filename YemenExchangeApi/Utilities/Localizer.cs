namespace YemenExchangeApi.Utils
{
    /// <summary>
    /// it's used to get the langauge value from resources files
    /// </summary>
    public class Localizer
    {
        /// <summary>
        /// get the value of resources files by passing key
        /// </summary>
        /// <param name="key">key of resource file value</param>
        /// <returns>value of key in  resources files</returns>
        public string GetString(string key) => ResourceManager.GetString(key);
        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                return YemenExchangeApi.Resources.SharedResource.ResourceManager;
            }
        }
    }
}
