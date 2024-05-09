using Plugin;
using Terraria;
using TerrariaApi.Server;
using TShockAPI;
using TShockAPI.Hooks;


namespace MoreShopItem
{
    [ApiVersion(2, 1)]
    public class MoreShopItem : TerrariaPlugin
    {
        public override string Name => "MoreShopItem";
        public override string Description => "更多商店物品";
        public override string Author => "hufang360 miao 羽学";
        public override Version Version => new Version(1, 0, 3);

        public static Config? _config;
        public static bool isLoading = false;
        public static readonly string configFile = Path.Combine(TShock.SavePath, "MoreShopItem.json");
        private readonly short[] shop_ids = new short[24]
        {
        17, 19, 20, 38, 54, 107, 108, 124, 142, 160,
        178, 207, 208, 209, 227, 228, 229, 353, 368, 453,
        550, 588, 633, 663
        };

        private readonly int[] lastDelay = new int[256];

        public MoreShopItem(Main game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            GetDataHandlers.NpcTalk.Register(OnNPCTalk!);
            GeneralHooks.ReloadEvent += OnReload;
            Reload();
        }

        private void OnReload(ReloadEventArgs args)
        {
            Reload(force: true);
            args.Player.SendSuccessMessage("[更多商店物品]重载配置完成");
        }

        private async void OnNPCTalk(object sender, GetDataHandlers.NpcTalkEventArgs args)
        {
            int nPCTalkTarget = args.NPCTalkTarget;
            if (nPCTalkTarget == -1)
            {
                return;
            }
            int pIndex = args.PlayerId;
            TSPlayer plr = TShock.Players[pIndex];
            if (plr == null || plr.TPlayer.talkNPC == nPCTalkTarget || lastDelay[pIndex] != 0)
            {
                return;
            }
            short npcID = (short)Main.npc[nPCTalkTarget].netID;
            if (!shop_ids.Contains(npcID))
            {
                return;
            }
            Reload();
            int sIndex = _config!.FindShopItem(npcID);
            if (sIndex == -1)
            {
                return;
            }
            lastDelay[pIndex] = nPCTalkTarget;
            await Task.Delay(_config.delay);
            lastDelay[pIndex] = 0;
            Item[] array = utils.SetupShop(Array.IndexOf(shop_ids, npcID) + 1, Main.player[pIndex]);
            int num = 0;
            for (int i = 0; i < 40; i++)
            {
                if (!array[i].active)
                {
                    num = i;
                    break;
                }
            }
            short num2 = 0;
            List<Goods> list = _config.shop[sIndex].FilterByUnlock(pIndex);
            for (int j = num; j < 40; j++)
            {
                if (num2 < list.Count)
                {
                    Goods item = list[num2];
                    num2++;
                    UpdateSlot(plr, j, item);
                }
            }
        }

        private void UpdateSlot(TSPlayer plr, int i, Goods item)
        {
            byte[] bytes = BitConverter.GetBytes(item.id);
            byte[] bytes2 = BitConverter.GetBytes((item.stack <= 0) ? 1 : item.stack);
            byte[] bytes3 = BitConverter.GetBytes((item.price <= 0) ? 1 : item.price);
            plr.SendRawData(new byte[14]
            {
            14,
            0,
            104,
            (byte)i,
            bytes[0],
            bytes[1],
            bytes2[0],
            bytes2[1],
            (byte)item.prefix,
            bytes3[0],
            bytes3[1],
            bytes3[2],
            bytes3[3],
            0
            });
        }

        private void Reload(bool force = false)
        {
            if (force || !isLoading)
            {
                _config = Config.Load(configFile);
                isLoading = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GetDataHandlers.NpcTalk.UnRegister(OnNPCTalk!);
                GeneralHooks.ReloadEvent -= OnReload;
            }
            base.Dispose(disposing);
        }
    }
}