# 更多商店物品

让NPC卖更多的物品。<br>

当你和NPC对话后的2秒内，打开商店，会将配置文件中满足条件的物品附加到商店内。<br><br>



## 插件下载
插件在 TShock v4.5.18（Terraria 1.4.3.6）环境下测试通过。<br>
插件下载：[MoreShopItem.dll]() <br><br>


## 配置文件
插件首次启动会在 tshock目录下自动创建一个名为 “MoreShopItem.json”文件，内容和本项目的 [./res/config.json](./res/config.json) 相同。<br>

配置说明：

```json
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
                    "unlock": ["世吞", "雨天"]  // 解锁条件，可不写，可写多条，全部的解锁条件见：https://docs.qq.com/sheet/DTkdNZFVlUmRKZHJI?tab=8ojz5h
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

---

参考链接：[商店售卖物品清单表格版](https://docs.qq.com/sheet/DTkdNZFVlUmRKZHJI?tab=BB08J2)