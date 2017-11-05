using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class gameData : MonoBehaviour {


    public List<floorData> floorDataList = new List<floorData>();

    void Awake() {
        //如果是新开游戏，初始化
        if (player.isNewGame)
        {
            //第一层数据初始化
            #region
            floorData f1 = new floorData();
            //怪物初始化     
            f1.enemylist.Add(new enemyObject(new int[] { 1, 0 }, 1));
            f1.enemylist.Add(new enemyObject(new int[] { 5, 8 }, 1));
            f1.enemylist.Add(new enemyObject(new int[] { 7, 5 }, 9));
            f1.enemylist.Add(new enemyObject(new int[] { 7, 2 }, 8));
            f1.enemylist.Add(new enemyObject(new int[] { 8, 3 }, 8));
            f1.enemylist.Add(new enemyObject(new int[] { 7, 3 }, 6));
            f1.enemylist.Add(new enemyObject(new int[] { 8, 9 }, 13));
            f1.enemylist.Add(new enemyObject(new int[] { 10, 2 }, 1));
            f1.enemylist.Add(new enemyObject(new int[] { 10, 3 }, 2));
            f1.enemylist.Add(new enemyObject(new int[] { 10, 4 }, 1));
            f1.enemylist.Add(new enemyObject(new int[] { 3, 2 }, 3));
            f1.enemylist.Add(new enemyObject(new int[] { 2, 5 }, 4));
            f1.enemylist.Add(new enemyObject(new int[] { 1, 5 }, 4));
            f1.enemylist.Add(new enemyObject(new int[] { 0, 5 }, 3));
            f1.enemylist.Add(new enemyObject(new int[] { 3, 5 }, 2));
            f1.enemylist.Add(new enemyObject(new int[] { 3, 4 }, 1));
            f1.enemylist.Add(new enemyObject(new int[] { 3, 3 }, 2));
            f1.enemylist.Add(new enemyObject(new int[] { 2, 7 }, 5));
            f1.enemylist.Add(new enemyObject(new int[] { 3, 9 }, 6));
            f1.enemylist.Add(new enemyObject(new int[] { 2, 10 }, 6));
            f1.enemylist.Add(new enemyObject(new int[] { 2, 8 }, 7));
            f1.enemylist.Add(new enemyObject(new int[] { 1, 9 }, 7));
            f1.enemylist.Add(new enemyObject(new int[] { 1, 7 }, 7));
            f1.enemylist.Add(new enemyObject(new int[] { 0, 8 }, 4));
            f1.enemylist.Add(new enemyObject(new int[] { 0, 10 }, 5));
            f1.enemylist.Add(new enemyObject(new int[] { 3, 7 }, 7));
            f1.enemylist.Add(new enemyObject(new int[] { 3, 8 }, 7));
            f1.enemylist.Add(new enemyObject(new int[] { 1, 10 }, 6));

            //门初始化
            f1.doorlist.Add(new doorObject("yellow", new int[] { 8, 8 }));
            f1.doorlist.Add(new doorObject("red", new int[] { 6, 5 }));
            f1.doorlist.Add(new doorObject("yellow", new int[] { 4, 2 }));
            f1.doorlist.Add(new doorObject("blue", new int[] { 2, 6 }));

            //物品初始化
            f1.wupinglist.Add(new wupingObject(new int[] { 0, 2 }, wupingType.yellowKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 8, 2 }, wupingType.Swordlevel_1));
            f1.wupinglist.Add(new wupingObject(new int[] { 7, 4 }, wupingType.bigHp));
            f1.wupinglist.Add(new wupingObject(new int[] { 8, 5 }, wupingType.Atkup));
            f1.wupinglist.Add(new wupingObject(new int[] { 8, 4 }, wupingType.blueKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 9, 9 }, wupingType.yellowKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 9, 10 }, wupingType.yellowKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 10, 9 }, wupingType.redKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 10, 10 }, wupingType.blueKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 8, 10 }, wupingType.Atkup));
            f1.wupinglist.Add(new wupingObject(new int[] { 7, 10 }, wupingType.Defup));
            f1.wupinglist.Add(new wupingObject(new int[] { 7, 9 }, wupingType.smallHp));
            f1.wupinglist.Add(new wupingObject(new int[] { 2, 2 }, wupingType.smallHp));
            f1.wupinglist.Add(new wupingObject(new int[] { 1, 2 }, wupingType.smallHp));
            f1.wupinglist.Add(new wupingObject(new int[] { 2, 3 }, wupingType.yellowKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 1, 3 }, wupingType.yellowKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 0, 3 }, wupingType.blueKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 0, 4 }, wupingType.redKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 1, 4 }, wupingType.Atkup));
            f1.wupinglist.Add(new wupingObject(new int[] { 2, 4 }, wupingType.Atkup));
            f1.wupinglist.Add(new wupingObject(new int[] { 3, 10 }, wupingType.redKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 0, 7 }, wupingType.yellowKey));
            f1.wupinglist.Add(new wupingObject(new int[] { 1, 8 }, wupingType.smallHp));
            f1.wupinglist.Add(new wupingObject(new int[] { 0, 9 }, wupingType.Atkup));
            f1.wupinglist.Add(new wupingObject(new int[] { 2, 9 }, wupingType.Defup));

            //层玩家初始位置初始化
            f1.init = new int[] { 5, 10 };
            f1.initUp = new int[] { 1, 0 };

            floorDataList.Add(f1);
            #endregion
            //第二层数据初始化
            #region
            floorData f2 = new floorData();

            //怪物初始化     
            f2.enemylist.Add(new enemyObject(new int[] { 1, 0 }, 3));
            f2.enemylist.Add(new enemyObject(new int[] { 7, 0 }, 3));
            f2.enemylist.Add(new enemyObject(new int[] { 9, 0 }, 5));
            f2.enemylist.Add(new enemyObject(new int[] { 6, 1 }, 3));
            f2.enemylist.Add(new enemyObject(new int[] { 8, 1 }, 5));
            f2.enemylist.Add(new enemyObject(new int[] { 10, 1 }, 6));
            f2.enemylist.Add(new enemyObject(new int[] { 1, 2 }, 5));
            f2.enemylist.Add(new enemyObject(new int[] { 4, 2 }, 4));
            f2.enemylist.Add(new enemyObject(new int[] { 7, 2 }, 5));
            f2.enemylist.Add(new enemyObject(new int[] { 9, 2 }, 5));
            f2.enemylist.Add(new enemyObject(new int[] { 8, 3 }, 4));
            f2.enemylist.Add(new enemyObject(new int[] { 1, 4 }, 5));
            f2.enemylist.Add(new enemyObject(new int[] { 0, 4 }, 4));
            f2.enemylist.Add(new enemyObject(new int[] { 2, 4 }, 4));
            f2.enemylist.Add(new enemyObject(new int[] { 1, 5 }, 4));
            f2.enemylist.Add(new enemyObject(new int[] { 7, 5 }, 2));
            f2.enemylist.Add(new enemyObject(new int[] { 0, 6 }, 3));
            f2.enemylist.Add(new enemyObject(new int[] { 1, 6 }, 3));
            f2.enemylist.Add(new enemyObject(new int[] { 2, 6 }, 3));
            f2.enemylist.Add(new enemyObject(new int[] { 7, 6 }, 1));
            f2.enemylist.Add(new enemyObject(new int[] { 4, 7 }, 1));
            f2.enemylist.Add(new enemyObject(new int[] { 4, 8 }, 2));
            f2.enemylist.Add(new enemyObject(new int[] { 8, 8 }, 4));
            f2.enemylist.Add(new enemyObject(new int[] { 7, 9 }, 4));
            f2.enemylist.Add(new enemyObject(new int[] { 10, 9 }, 6));
            f2.enemylist.Add(new enemyObject(new int[] { 9, 10 }, 6));

            //门初始化
            f2.doorlist.Add(new doorObject("red", new int[] { 1, 1 }));
            f2.doorlist.Add(new doorObject("yellow", new int[] { 8, 4 }));
            f2.doorlist.Add(new doorObject("yellow", new int[] { 9, 7 }));

            //物品初始化
            f2.wupinglist.Add(new wupingObject(new int[] { 6, 0 }, wupingType.Atkup));
            f2.wupinglist.Add(new wupingObject(new int[] { 8, 0 }, wupingType.yellowKey));
            f2.wupinglist.Add(new wupingObject(new int[] { 7, 1 }, wupingType.blueKey));
            f2.wupinglist.Add(new wupingObject(new int[] { 9, 1 }, wupingType.yellowKey));
            f2.wupinglist.Add(new wupingObject(new int[] { 0, 2 }, wupingType.Atkup));
            f2.wupinglist.Add(new wupingObject(new int[] { 2, 2 }, wupingType.Atkup));
            f2.wupinglist.Add(new wupingObject(new int[] { 6, 2 }, wupingType.blueKey));
            f2.wupinglist.Add(new wupingObject(new int[] { 8, 2 }, wupingType.smallHp));
            f2.wupinglist.Add(new wupingObject(new int[] { 10, 2 }, wupingType.smallHp));
            f2.wupinglist.Add(new wupingObject(new int[] { 0, 3 }, wupingType.Defup));
            f2.wupinglist.Add(new wupingObject(new int[] { 1, 3 }, wupingType.Defup));
            f2.wupinglist.Add(new wupingObject(new int[] { 2, 3 }, wupingType.Defup));
            f2.wupinglist.Add(new wupingObject(new int[] { 6, 3 }, wupingType.Defup));
            f2.wupinglist.Add(new wupingObject(new int[] { 7, 3 }, wupingType.Atkup));
            f2.wupinglist.Add(new wupingObject(new int[] { 9, 3 }, wupingType.Atkup));
            f2.wupinglist.Add(new wupingObject(new int[] { 10, 3 }, wupingType.Defup));
            f2.wupinglist.Add(new wupingObject(new int[] { 0, 5 }, wupingType.normalHp));
            f2.wupinglist.Add(new wupingObject(new int[] { 2, 5 }, wupingType.normalHp));
            f2.wupinglist.Add(new wupingObject(new int[] { 6, 8 }, wupingType.blueKey));
            f2.wupinglist.Add(new wupingObject(new int[] { 7, 8 }, wupingType.yellowKey));
            f2.wupinglist.Add(new wupingObject(new int[] { 9, 8 }, wupingType.Atkup));
            f2.wupinglist.Add(new wupingObject(new int[] { 10, 8 }, wupingType.Atkup));
            f2.wupinglist.Add(new wupingObject(new int[] { 6, 9 }, wupingType.yellowKey));
            f2.wupinglist.Add(new wupingObject(new int[] { 8, 9 }, wupingType.Defup));
            f2.wupinglist.Add(new wupingObject(new int[] { 9, 9 }, wupingType.Defup));
            f2.wupinglist.Add(new wupingObject(new int[] { 7, 10 }, wupingType.smallHp));
            f2.wupinglist.Add(new wupingObject(new int[] { 8, 10 }, wupingType.smallHp));
            f2.wupinglist.Add(new wupingObject(new int[] { 10, 10 }, wupingType.blueKey));

            //层玩家初始位置初始化
            f2.init = new int[] { 1, 10 };
            f2.initUp = new int[] { 7, 10 };

            floorDataList.Add(f2);
            #endregion
            //第三层数据初始化
            #region
            floorData f3 = new floorData();

            //怪物初始化     
            f3.enemylist.Add(new enemyObject(new int[] { 0, 0 }, 1));

            //门初始化
            f3.doorlist.Add(new doorObject("yellow", new int[] { 2, 4 }));

            //物品初始化
            f3.wupinglist.Add(new wupingObject(new int[] { 10, 0 }, wupingType.redKey));

            //层玩家初始位置初始化
            f3.init = new int[] { 5, 9 };
            f3.initUp = new int[] { 5, 1 };

            floorDataList.Add(f3);
            #endregion
        }
    }

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
