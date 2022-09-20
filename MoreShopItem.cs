using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using TShockAPI.Hooks;

namespace MoreShopItem
{
    [ApiVersion(2, 1)]
    public class MoreShopItem : TerrariaPlugin
    {
        # region 插件信息
        public override string Name => "MoreShopItem";
        public override string Description => "更多商店物品";
        public override string Author => "hufang360";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;
        #endregion

        public static Config _config;
        public static bool isLoading = false;
        public static readonly string configFile = Path.Combine(TShock.SavePath, "MoreShopItem.json");

        // 商店id和npcid的对照关系
        private readonly short[] shop_ids = new short[24] { 17, 19, 20, 38, 54, 107, 108, 124, 142, 160, 178, 207, 208, 209, 227, 228, 229, 353, 368, 453, 550, 588, 633, 663 };
        private readonly int[] lastDelay = new int[256];

        public MoreShopItem(Main game) : base(game)
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Initialize()
        {
            GetDataHandlers.NpcTalk.Register(OnNPCTalk);
            GeneralHooks.ReloadEvent += OnReload;
        }

        /// <summary>
        /// 重载配置文件
        /// </summary>
        /// <param name="args"></param>
        private void OnReload(ReloadEventArgs args)
        {
            Reload(true);
            args.Player.SendSuccessMessage("[更多商店物品]重载配置完成");
        }

        /// <summary>
        /// 与NPC对话时
        /// </summary>
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

                Reload();
                int sIndex = _config.FindShopItem(npcID);
                if (sIndex == -1) return;

                // 延迟
                lastDelay[pIndex] = nIndex;
                await Task.Delay(_config.delay);
                lastDelay[pIndex] = 0;

                // 补货
                int npcShop = Array.IndexOf(shop_ids, npcID) + 1;
                Item[] shopItems = utils.SetupShop(npcShop, Main.player[pIndex]);
                int startIndex = 0;
                for (int i = 0; i < 40; i++)
                {
                    utils.Log($"[msi]: 名称：{shopItems[i].Name} 激活：{shopItems[i].active}");
                    if(!shopItems[i].active)
                    {
                        startIndex = i;
                        break;
                    }
                }

                short count = 0;
                List<Goods> goods = _config.shop[sIndex].FilterByUnlock(pIndex);
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

        /// <summary>
        /// 重载配置文件
        /// </summary>
        /// <param name="force"></param>
        private void Reload(bool force = false)
        {
            if (force || isLoading == false)
            {
                _config = Config.Load(configFile);
                isLoading = true;
            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GetDataHandlers.NpcTalk.UnRegister(OnNPCTalk);
                GeneralHooks.ReloadEvent -= OnReload;
            }
            base.Dispose(disposing);
        }

    }

}
