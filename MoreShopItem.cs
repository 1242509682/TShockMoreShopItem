using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using TShockAPI.Hooks;



// 主插件类应始终使用ApiVersion属性进行修饰。当前API版本为2.1
namespace MoreShopItem
{
    [ApiVersion(2, 1)]
    public class MoreShopItem : TerrariaPlugin
    {

        #region 插件模版信息
        public override string Name => "MoreShopItem";
        public override string Description => "NPC售卖更多商店物品";
        public override string Author => "hufang360、miao、羽学修复内嵌方法";
        public override Version Version => new Version(1, 0, 3);
        #endregion

        #region 注册与释放
        public MoreShopItem(Main game) : base(game) { }
        public override void Initialize()
        {
            LoadConfig();
            GeneralHooks.ReloadEvent += LoadConfig;
            GetDataHandlers.NpcTalk.Register(OnNPCTalk);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GeneralHooks.ReloadEvent -= LoadConfig;
                GetDataHandlers.NpcTalk.UnRegister(OnNPCTalk!);
            }
            base.Dispose(disposing);
        }
         internal static  Configuration Config = null!;
        // 商店id和npcid的对照关系
        private readonly short[] shop_ids = new short[24] { 17, 19, 20, 38, 54, 107, 108, 124, 142, 160, 178, 207, 208, 209, 227, 228, 229, 353, 368, 453, 550, 588, 633, 663 };
        private readonly int[] lastDelay = new int[256];
        #endregion

        #region 配置文件创建与重读加载方法
        internal static void LoadConfig(ReloadEventArgs args = null!)
        {
            //调用Configuration.cs文件Read和Write方法
            Config = Configuration.Read(Configuration.FilePath);
            Config.Write(Configuration.FilePath);
            if (args != null && args.Player != null)
            {
                args.Player.SendSuccessMessage("[更多商店物品]重载配置完成");
            }
        }
        #endregion

        private async void OnNPCTalk(object sender, GetDataHandlers.NpcTalkEventArgs args)
        {
            // 玩家索引 和 NPC索引（非NPCID）
            int nIndex = args.NPCTalkTarget;
            if (nIndex == -1) return;

            int pIndex = args.PlayerId;
            TSPlayer plr = TShock.Players[pIndex];
            if (plr != null && plr.TPlayer.talkNPC != nIndex && lastDelay[pIndex] == 0)
            {
                short npcID = (short)Main.npc[nIndex].netID;
                if (!shop_ids.Contains(npcID)) return;

                LoadConfig();
                int sIndex = Config.FindShopItem(npcID);
                if (sIndex == -1) return;

                // 延迟
                lastDelay[pIndex] = nIndex;
                await Task.Delay(Config.delay);
                lastDelay[pIndex] = 0;

                // 补货
                int npcShop = Array.IndexOf(shop_ids, npcID) + 1;
                Item[] shopItems = utils.SetupShop(npcShop, Main.player[pIndex]);
                int startIndex = 0;
                for (int i = 0; i < 40; i++)
                {
                    //utils.Log($"[msi]: 名称：{shopItems[i].Name} 激活：{shopItems[i].active}");
                    if (!shopItems[i].active)
                    {
                        startIndex = i;
                        break;
                    }
                }

                short count = 0;
                List<Goods> goods = Config.shop[sIndex].FilterByUnlock(pIndex);
                for (int i = startIndex; i < 40; i++)
                {
                    if (count >= goods.Count) continue;

                    Goods item = goods[count];
                    count++;

                    UpdateSlot(plr, i, item);
                }
            }
        }

        /// <summary>
        /// 更新单个商品
        /// </summary>
        private void UpdateSlot(TSPlayer plr, int i, Goods item)
        {
            byte[] idBytes = BitConverter.GetBytes(item.id);
            byte[] stackBytes = BitConverter.GetBytes(item.stack > 0 ? item.stack : 1);
            byte[] priceBytes = BitConverter.GetBytes(item.price > 0 ? item.price : 1);
            plr.SendRawData(new byte[] { 14, 0, 104, (byte)i, idBytes[0], idBytes[1], stackBytes[0], stackBytes[1], (byte)item.prefix, priceBytes[0], priceBytes[1], priceBytes[2], priceBytes[3], 0 });
        }

    }
}