using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;

#endif

public class enemydate
{
    //敌人基础类

}

public class enemyObject
{
    public int[] zuobiao = new int[2] { 0, 0 };
    public int enemyID;

    public enemyObject(int[] Zuobiao, int EnemyID)
    {
        zuobiao = Zuobiao;
        enemyID = EnemyID;
    }
}



public class wupingObject
{
    public int[] zuobiao = new int[2] { 0, 0 };
    public wupingType thisType;

    public wupingObject(int[] Zuobiao,wupingType WupingType) {
        zuobiao = Zuobiao;
        thisType = WupingType;
    }
}

public class doorObject
{
    public int[] zuobiao = new int[2] { 0, 0 };

    public string doorColor;

    public doorObject(string color,int[] Zuobiao)
    {
        doorColor = color;
        zuobiao = Zuobiao;
    }
}


public class floorData {
    public int[] init;//当前层的玩家入口坐标，下楼处坐标，切换场景时使用
    public int[] initUp;//当前层离开时的坐标，上楼处坐标，切换场景时使用

    public List<enemyObject> enemylist = new List<enemyObject>();
    public List<doorObject> doorlist = new List<doorObject>();
    public List<wupingObject> wupinglist = new List<wupingObject>();
}

public class floorFather : MonoBehaviour
{
    public int[] init;//当前层的玩家入口坐标，下楼处坐标，切换场景时使用
    public int[] initUp;//当前层离开时的坐标，上楼处坐标，切换场景时使用

    public List<enemyObject> enemylist = new List<enemyObject>();
    public List<doorObject> doorlist = new List<doorObject>();
    public List<wupingObject> wupinglist = new List<wupingObject>();

    public void showEnemy()
    {
        for (int i = 0; i <= enemylist.Count - 1; i++)
        {
            //获取单个敌人数据
            int[] ZuoBiao = enemylist[i].zuobiao;
            int ID = enemylist[i].enemyID;
            ArrayList datalist = (ArrayList)player.enemyType[ID - 1];
            //实例化敌人
            GameObject enemyObject = (GameObject)Instantiate(Resources.Load(datalist[5].ToString()));
            //根据数据，赋值怪物坐标
            enemyObject.transform.position = new Vector3(ZuoBiao[0] * 0.32f + 0.16f, -ZuoBiao[1] * 0.32f - 0.16f, 0f);
            enemyObject.AddComponent<BoxCollider2D>();
            enemyObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
            //根据数据，赋值怪物属性信息
            enemypro ep = enemyObject.AddComponent<enemypro>();
            ep.enemyTypeID = datalist[0].ToString();
            ep.Name = datalist[1].ToString();
            ep.hp = (int)datalist[2];
            ep.atk = (int)datalist[3];
            ep.def = (int)datalist[4];
            ep.prefabName = datalist[5].ToString();
            ep.deadCoin = (int)datalist[6];
            ep.deadEmpiric = (int)datalist[7];
            enemyObject.tag = "enemy";

            gameObject.GetComponent<myTweenAlpha>()._thisSprite.Add(enemyObject);
        }
    }

    public void showDoor() {
        for (int i = 0; i <= doorlist.Count - 1; i++) {
            //获取门的位置、颜色
            string color = doorlist[i].doorColor;
            int[] ZuoBiao = doorlist[i].zuobiao;

            string prefabUrl="";
            //实例化门
            switch (color) {
                case "yellow":
                    prefabUrl = "door/door_0";
                    break;
                case "blue":
                    prefabUrl = "door/door_1";
                    break;
                case "red":
                    prefabUrl = "door/door_2";
                    break;
            }
            GameObject door = (GameObject)Instantiate(Resources.Load(prefabUrl));
            door.transform.position = new Vector3(ZuoBiao[0]*0.32f+0.16f,-ZuoBiao[1]*0.32f-0.16f,0f);
            door.GetComponent<SpriteRenderer>().sortingOrder = 10;

            gameObject.GetComponent<myTweenAlpha>()._thisSprite.Add(door);
        }
    }

    public void showWuping() {
        for (int i = 0; i <= wupinglist.Count - 1; i++) {
            //获取物品种类、位置
            wupingType type = wupinglist[i].thisType;
            int[] ZuoBiao = wupinglist[i].zuobiao;

            int newhp=0, newatk=0, newdef=0, newyellow=0, newblue=0, newred=0, newem=0, newcoin = 0;
            string prefabUrl = "";//prefab路径
            string info ="";
         
            //实例化物品
            switch (type) {
                case wupingType.Atkup:
                    prefabUrl = "wuping/item_0";
                    newatk = 5;
                    info = "发现红宝石！攻击力上升5！";
                    break;
                case wupingType.Defup:
                    prefabUrl = "wuping/item_1";
                    newdef = 5;
                    info = "发现蓝宝石！防御力上升5！";
                    break;
                case wupingType.smallHp:
                    prefabUrl = "wuping/item_4";
                    newhp = 300;
                    info = "喝下小生命药水！生命恢复300！";
                    break;
                case wupingType.normalHp:
                    prefabUrl = "wuping/item_5";
                    newhp = 500;
                    info = "喝下生命药水！生命恢复500！";
                    break;
                case wupingType.bigHp:
                    prefabUrl = "wuping/item_6";
                    newhp = 1000;
                    info = "喝下大生命药水！生命恢复1000！";
                    break;
                case wupingType.maxHP:
                    prefabUrl = "wuping/item_7";
                    newhp = 1500;
                    info = "喝下圣水，生命恢复1500！";
                    break;
                case wupingType.yellowKey:
                    prefabUrl = "wuping/item_14";
                    newyellow = 1;
                    info = "找到一把黄色钥匙！";
                    break;
                case wupingType.blueKey:
                    prefabUrl = "wuping/item_15";
                    newblue = 1;
                    info = "找到一把蓝色钥匙！";
                    break;
                case wupingType.redKey:
                    prefabUrl = "wuping/item_16";
                    newred = 1;
                    info = "找到一把红色钥匙！";
                    break;
                case wupingType.Shieldlevel_1:
                    prefabUrl = "wuping/item_50";
                    newdef = 50;
                    info = "装备盾牌！防御力上升50！";
                    break;
                case wupingType.Shieldlevel_2:
                    prefabUrl = "wuping/item_53";
                    newdef = 80;
                    info = "装备精良盾牌！防御力上升80！";
                    break;
                case wupingType.Shieldlevel_3:
                    prefabUrl = "wuping/item_54";
                    newdef = 120;
                    info = "装备先锋盾！防御力上升120！";
                    break;
                case wupingType.Swordlevel_1:
                    prefabUrl = "wuping/item_45";
                    newatk = 50;
                    info = "装备铁剑！攻击力上升50！";
                    break;
                case wupingType.Swordlevel_2:
                    prefabUrl = "wuping/item_47";
                    newatk = 80;
                    info = "装备战士剑！攻击力上升80！";
                    break;
                case wupingType.Swordlevel_3:
                    prefabUrl = "wuping/item_49";
                    newatk = 120;
                    info = "装备退魔剑！攻击力上升120！";
                    break;
            }
            //加载位置
            GameObject wuping = (GameObject)Instantiate(Resources.Load(prefabUrl));
            wuping.transform.position = new Vector3(ZuoBiao[0] * 0.32f + 0.16f, -ZuoBiao[1] * 0.32f - 0.16f, 0f);
            wuping.GetComponent<SpriteRenderer>().sortingOrder = 10;
            //挂载物品属性脚本
            wupingMain wm = wuping.AddComponent<wupingMain>();
            wm.hpVar = newhp;
            wm.atkVar = newatk;
            wm.defVar = newdef;
            wm.yellowKeyVar = newyellow;
            wm.blueKeyVar = newblue;
            wm.redKeyVar = newred;
            wm.emVar = newem;
            wm.coinVar = newcoin;
            wm.Infostring = info;

            gameObject.GetComponent<myTweenAlpha>()._thisSprite.Add(wuping);
        }
    }

    //加载英雄到舞台
    public void showHero(Vector3 pos)
    {
        //实例化一个英雄单位
        //通过方法里的参数，给英雄赋予相应的位置属性
        //通过后台，赋予英雄战斗属性
        //enemyObject.transform.position = new Vector3(ZuoBiao[0] * 0.32f + 0.16f, -ZuoBiao[1] * 0.32f - 0.16f, 0f);
        GameObject hero = (GameObject)Instantiate(Resources.Load("Prefabs/hero_0"));
        hero.transform.position = pos;
        hero.GetComponent<SpriteRenderer>().sortingOrder = 10;

        gameObject.GetComponent<myTweenAlpha>()._thisSprite.Add(hero);

        //主角赋值属性
        playerpro heroP = hero.GetComponent<playerpro>();
        heroP.hp = player.HP;
        heroP.atk = player.ATK;
        heroP.def = player.DEF;
    }

    //坐标转换器，传入游戏内的坐标，输出unity坐标
    public Vector3 transMap(int[] pos) {
        Vector3 newPos = new Vector3( pos[0] * 0.32f + 0.16f, -pos[1] * 0.32f - 0.16f, 0f);
        return newPos;
    }

    public int[] transMaptoArray(Vector3 pos) {
        int[] newPos = new int[] {Mathf.RoundToInt((pos.x-0.16f)/0.32f),Mathf.RoundToInt(-(pos.y+0.16f)/0.32f)};
        return newPos;
    }

    //比较坐标是否相等
    public bool CompareArray(int[] bt1, int[] bt2)
    {
        var len1 = bt1.Length;
        var len2 = bt2.Length;
        if (len1 != len2)
        {
            return false;
        }
        for (var i = 0; i < len1; i++)
        {
            if (bt1[i] != bt2[i])
                return false;
        }
        return true;
    }
}


