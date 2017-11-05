using UnityEngine;
using System.Collections;

public class battleMain : MonoBehaviour {

    public battleRound thisRound = battleRound.player;

    public enum battleRound {
        player,
        enemy
    }


    void Start () {
	
	}
	
	void Update () {
	
	}

    //单回合伤害计算返回值
    public int battleSinglehit(int atker,int defer) {
        int result;
        if (atker < defer) {
            result = 0;
        }
        else {
            result = atker - defer;
        }
        return result;
    }

    //两个单位进行决斗
    public void duel(GameObject Player,GameObject enemy) {
        GameObject labels = GameObject.Find("UI Root").transform.Find("main").Find("battlePanel").gameObject;
        playerpro playerbp = Player.GetComponent<playerpro>();
        enemypro enemybp = enemy.GetComponent<enemypro>();
        bool canFight = true;
        int i = 1;
        Debug.Log(playerbp.hp);
        while ((playerbp.atk - enemybp.def) * i < enemybp.hp) {
            if ((enemybp.atk - playerbp.def) * i >= playerbp.hp) {
                Debug.Log("玩家无法打赢这场战斗");
                canFight = false;

                labels.gameObject.SetActive(false);
                labels.transform.Find("enemysprite").GetComponent<UISprite>().spriteName = "";//清空sprite
                Destroy(labels.transform.Find("enemysprite").gameObject.GetComponent<UISpriteAnimation>());//删除动画组件
                break;
            }
            i++;
        }

        if (canFight)
        {
            Debug.Log("开始战斗");
            StartCoroutine(fight(Player, enemy));
            //关闭长按事件
            gameObject.GetComponent<controller>().isBeginLongpush = false;
            gameObject.GetComponent<controller>().isPush = false;
            gameObject.GetComponent<controller>().maxCd = 0.8f;
        }
    }

    IEnumerator fight(GameObject player0,GameObject enemy) {
        playerpro playerbp = player0.GetComponent<playerpro>();
        enemypro enemybp = enemy.GetComponent<enemypro>();
        GameObject labels = GameObject.Find("UI Root").transform.Find("main").Find("battlePanel").gameObject;

        while (playerbp.hp>0 && enemybp.hp>0) {
            //玩家出手回合
            if (thisRound == battleRound.player)
            {
                enemybp.hp -= battleSinglehit(playerbp.atk, enemybp.def);
                if (enemybp.hp < 0)
                {
                    enemybp.hp = 0;
                }
                labels.transform.Find("enemy_hp").GetComponent<UILabel>().text = enemybp.hp.ToString();
                thisRound = battleRound.enemy;
            }
            else if (thisRound == battleRound.enemy)
            {
                playerbp.hp -= battleSinglehit(enemybp.atk, playerbp.def);
                if (playerbp.hp < 0)
                {
                    playerbp.hp = 0;
                }
                labels.transform.Find("hero_hp").GetComponent<UILabel>().text = playerbp.hp.ToString();
                thisRound = battleRound.player;
            }

            yield return new WaitForSeconds(0.4f);
        }

        if (playerbp.hp <= 0)
        {           
            Debug.Log("玩家死亡");
        }
        else if (enemybp.hp <= 0) {            
            Debug.Log("怪物死亡");//玩家面板更新血量，钱币，经验
            Destroy(enemy.gameObject);
            GameObject.Find("battle0" + player.playerInfloor.ToString()+"(Clone)").GetComponent<myTweenAlpha>()._thisSprite.Remove(enemy.gameObject);
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("hp").GetComponent<UILabel>().text = playerbp.hp.ToString();
            player.empiric += enemybp.deadEmpiric;//更新后台数据
            player.HP = playerbp.hp;
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("jy").GetComponent<UILabel>().text = player.empiric.ToString();
            player.coin += enemybp.deadCoin;//更新后台数据
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("coin").GetComponent<UILabel>().text = player.coin.ToString();

            //更新后台当前层缓存
            floor_01 f1 = GameObject.Find("battle0" + player.playerInfloor.ToString() + "(Clone)").GetComponent<floor_01>();
            int[] enemypos = f1.transMaptoArray(enemy.transform.position);
            for (int i = 0; i <= f1.enemylist.Count - 1; i++) {               
                if (f1.CompareArray(enemypos, f1.enemylist[i].zuobiao)) {
                    f1.enemylist.RemoveAt(i);
                }
            }
            GameObject.Find("Main Camera").GetComponent<gameData>().floorDataList[player.playerInfloor - 1].enemylist = f1.enemylist;//将层数据同步到后台

            //弹出战斗奖励
            GameObject info = (GameObject)Instantiate(Resources.Load("Prefabs/UIPanel"));
            info.transform.parent = GameObject.Find("UI Root").transform.Find("main").transform;
            info.transform.localScale = new Vector3(1f, 1f, 1f);

            //info.transform.FindChild("labelc_Coin").GetComponent<UILabel>().text = "";
            //info.transform.FindChild("labelc_em").GetComponent<UILabel>().text = "";
            //info.transform.FindChild("Label").GetComponent<UILabel>().text = "";
            //info.transform.FindChild("Label 1").GetComponent<UILabel>().text = "";
            //info.transform.FindChild("Label 2").GetComponent<UILabel>().text = "";
            //info.transform.FindChild("Label 3").GetComponent<UILabel>().text = "";

            info.transform.Find("labelc_Coin").GetComponent<UILabel>().text = enemybp.deadCoin.ToString();
            info.transform.Find("labelc_em").GetComponent<UILabel>().text = enemybp.deadEmpiric.ToString();

            Destroy(info, 0.7f);
        }
        thisRound = battleRound.player;
        labels.SetActive(false);//战斗结束关闭面板
        labels.transform.Find("enemysprite").GetComponent<UISprite>().spriteName = "";//清空sprite
        Destroy(labels.transform.Find("enemysprite").gameObject.GetComponent<UISpriteAnimation>());//删除动画组件

        //等待1秒后，再开启移动
        //yield return new WaitForSeconds(1f);
        //gameObject.GetComponent<controller>().isBattle = false;//开启移动标示

        StopCoroutine("fight");
    }

    public void vectory(GameObject enemy) {

    }

}
