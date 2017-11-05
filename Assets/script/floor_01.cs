using UnityEngine;
using System.Collections;

public class floor_01 : floorFather
{
    private floorData ff;
    void Awake() {
        
    }

    void Start() {
        //从缓存中读取数据
        ff = GameObject.Find("Main Camera").GetComponent<gameData>().floorDataList[player.playerInfloor - 1];
        enemylist = ff.enemylist;
        doorlist = ff.doorlist;
        wupinglist = ff.wupinglist;
        init = ff.init;
        initUp = ff.initUp;

        showEnemy();
        showDoor();
        showWuping();
        if (!player.isLoad)//非加载存档
        {
            if (player.upOrdown == "up")
            {
                showHero(transMap(init));
            }
            else if (player.upOrdown == "down")
            {
                showHero(transMap(initUp));
            }
        }
        else
        {//加载存档
            showHero(transMap(player.playerPos));
        }
      
    }

    void Update() {

    }
}


