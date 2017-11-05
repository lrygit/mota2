using UnityEngine;
using System.Collections;

public enum wupingType {
    smallHp,
    normalHp,
    bigHp,
    maxHP,
    Atkup,
    Defup,
    Swordlevel_1,
    Swordlevel_2,
    Swordlevel_3,
    Shieldlevel_1,
    Shieldlevel_2,
    Shieldlevel_3,
    yellowKey,
    redKey,
    blueKey
}

public static class player{

    public static int HP=500;//生命
    public static int ATK=15;//攻击
    public static int DEF=5;//防御
    //此行由家里电脑编写，并在此修改
    //此行由笔记本编写

    public static int empiric=0;//经验
    public static int empiricLevelUp=100;//升级所需经验
    public static int level=1;//等级
    public static int coin=0;//金币

    public static int playerInfloor=1;//玩家所在层数
    public static int[] playerPos;//玩家在地图上的位置
    public static int yellowKey=1;//黄色钥匙数量
    public static int blueKey=0;//蓝色钥匙数量
    public static int redKey=0;//红色钥匙数量

    public static bool isNewGame=true;//是否是新开始的进度,若是则进行初始化操作
    public static bool isLoad = false;//进入某层时，是否是读档进入的
    public static string upOrdown="up";//切换时是上楼还是下楼

    //怪物属性列表
    //依次为【ID】【怪物名】【血量】【攻击】【防御】【prefab链接】【死亡金币】【死亡经验】
    public static ArrayList enemyType = new ArrayList() {
        new ArrayList() {"01","红色史莱姆",55,15,0,"Prefabs/enemy_01", 5,2},
        new ArrayList() {"02","绿色史莱姆",85,25,2,"Prefabs/enemy_02", 7,3},
        new ArrayList() {"03","黑色史莱姆",100,30,5,"Prefabs/enemy_03", 10,5},
        new ArrayList() {"04","小蝙蝠",180,55,20,"Prefabs/enemy_04", 15,10},
        new ArrayList() {"05","普通骷髅",250,70,30,"Prefabs/enemy_05", 20,12},
        new ArrayList() {"06","武装骷髅",350,95,40,"Prefabs/enemy_06", 22,15},
        new ArrayList() {"07","大蝙蝠",485,120,45,"Prefabs/enemy_07", 25,15},
        new ArrayList() {"08","强化武装骷髅",600,160,85,"Prefabs/enemy_08", 30,18},
        new ArrayList() {"09","蓝衣法师",850,190,95,"Prefabs/enemy_09", 30,20},
        new ArrayList() {"10","盔甲骷髅",1000,200,160,"Prefabs/enemy_10", 35,20},
        new ArrayList() {"11","史莱姆王",1000,260,100,"Prefabs/enemy_11", 38,25},
        new ArrayList() {"12","红蝙蝠",850,320,125,"Prefabs/enemy_12", 40,25},
        new ArrayList() {"13","兽人",1200,290,155,"Prefabs/enemy_13", 45,28},
        new ArrayList() {"14","黄色魔女",1550,340,190,"Prefabs/enemy_14", 45,28},
        new ArrayList() {"15","红衣法师",1750,400,240,"Prefabs/enemy_15", 48,30},
        new ArrayList() {"16","武装兽人",2000,450,290,"Prefabs/enemy_16", 50,32},
        new ArrayList() {"17","红色魔女",2500,600,400,"Prefabs/enemy_17", 55,35},
        new ArrayList() {"18","巨石像",3000,700,500,"Prefabs/enemy_18", 55,40}
    };

}
