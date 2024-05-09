using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace MoreShopItem
{
    public class Config
    {
        public List<ShopItem> shop = new List<ShopItem>();
        public int delay = 2000;
        private const string RES_NAME = "MoreShopItem.json";

        private static JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            Error = (sender, args) => args.ErrorContext.Handled = true
        };

        public static Config Load(string path)
        {
            Config config;
            if (File.Exists(path))
            {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(path), jsonSettings)!;
            }
            else
            {
                string text = utils.FromEmbeddedPath(RES_NAME);
                config = JsonConvert.DeserializeObject<Config>(text, jsonSettings)!;
                File.WriteAllText(path, text);
            }
            return config!;
        }

        public static void GenConfig(string path)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, utils.FromEmbeddedPath(RES_NAME));
            }
        }

        public int FindShopItem(int npcID)
        {
            for (int i = 0; i < shop.Count; i++)
            {
                if (shop[i].id == npcID)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}