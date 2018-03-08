using NetMud.Backup;

namespace NetMud
{
    public class GameConfig
    {
        public static void PreloadSupportingEntities()
        {
            //Load the "referential" data first
            BackingData.LoadEverythingToCache();
        }
    }
}