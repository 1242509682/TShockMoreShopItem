# 更多商店物品
作者：hufang
修改：miao 羽学
让NPC卖更多的物品。<br>

当你和NPC对话后的2秒内，打开商店，会将配置文件中满足条件的物品附加到商店内。<br><br>



## 更新日志
v1.0.3
羽学修复了内嵌配置文件方法（顺便给它换了个配置文件）

v1.0.2
miao 修复了覆盖原有商品 适配了.net 6.0


## 配置文件
安装插件后，首次启动会自动创建配置文件，位于 `./tshock/MoreShopItem/config.json`，内容和本项目的 [./res/config.json](./res/config.json) 文件相同。<br>

配置说明：

```jsonc
{
    // （这个是备注，目的是说明各个字段，实际配置这样写会出错）

    // 和npc对话后，多加附加物品到NPC商店
    "delay": 2000,

    // 商店列表
    "shop": [
        // 第一个商店
        {
            "id": 17,           //npc id
            "comment": "商人",  // 备注，可不写
            "item": [
                {
                    "id": 2674,  // 物品id
                    "comment": "学徒诱饵",  // 物品名称，可不写
                    "price": 1000,  // 单价，多少铜币，注意是单价
                    "unlock": ["世吞", "雨天"]  // 解锁条件，可不写，可写多条
                },
                {
                    "id": 9,
                    "comment": "木材",
                    "price": 10
                }
            ]
        },
        // 第二个商店
        {
            "id": 453,
            "comment": "骷髅商人",
            "item": [{
                "id": 5043,
                "comment": "火把神徽章",
                "price": 2000000,
                "unlock": ["骷髅王"]
            }]
        }
    ]
}
```
<br>


本插件未新增加任何指令，修改配置文件后，请输入tshock自带的 "/reload" 指令重新载入配置。

<br>
<br>

## 参考链接：<br>
- [插件支持的解锁条件](https://docs.qq.com/sheet/DTkdNZFVlUmRKZHJI?tab=8ojz5h)
- [商店售卖物品清单](https://docs.qq.com/sheet/DTkdNZFVlUmRKZHJI?tab=BB08J2)（感谢cart、mz参与商店物品的配置）
