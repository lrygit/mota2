using UnityEngine;
using System.Collections;

public class wupingMain : MonoBehaviour {

    public int hpVar=0;
    public int atkVar=0;
    public int defVar=0;
    public int yellowKeyVar=0;
    public int blueKeyVar=0;
    public int redKeyVar=0;
    public int emVar = 0;
    public int coinVar = 0;


    public string Infostring="";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void useWuping() {
        //服用药物,更改后台数据
        player.HP += hpVar;
        player.ATK += atkVar;
        player.DEF += defVar;
        player.yellowKey += yellowKeyVar;
        player.blueKey += blueKeyVar;
        player.redKey += redKeyVar;
        player.empiric += emVar;
        player.coin += coinVar;
        //更改面板显示
        GameObject lables = GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").gameObject;
        lables.transform.Find("hp").GetComponent<UILabel>().text = player.HP.ToString();
        lables.transform.Find("atk").GetComponent<UILabel>().text = player.ATK.ToString();
        lables.transform.Find("def").GetComponent<UILabel>().text = player.DEF.ToString();
        lables.transform.Find("yellowCount").GetComponent<UILabel>().text = player.yellowKey.ToString();
        lables.transform.Find("blueCount").GetComponent<UILabel>().text = player.blueKey.ToString();
        lables.transform.Find("redCount").GetComponent<UILabel>().text = player.redKey.ToString();
        lables.transform.Find("jy").GetComponent<UILabel>().text = player.empiric.ToString();
        lables.transform.Find("coin").GetComponent<UILabel>().text = player.coin.ToString();

        //更改人物属性
        playerpro p1 = GameObject.Find("hero_0(Clone)").GetComponent<playerpro>();
        p1.hp = player.HP;
        p1.atk = player.ATK;
        p1.def = player.DEF;

        Destroy(gameObject);//删除道具
        GameObject.Find("battle0" + player.playerInfloor.ToString()+"(Clone)").GetComponent<myTweenAlpha>()._thisSprite.Remove(gameObject);


        //弹出此道具的信息提示框
        GameObject info = (GameObject)Instantiate(Resources.Load("Prefabs/UIPanel"));
        info.transform.parent = GameObject.Find("UI Root").transform.Find("main").transform;
        info.transform.localScale = new Vector3(1f, 1f, 1f);     

        info.transform.Find("labelc_Coin").GetComponent<UILabel>().text = "";
        info.transform.Find("labelc_em").GetComponent<UILabel>().text = "";
        info.transform.Find("Label").GetComponent<UILabel>().text = "";
        info.transform.Find("Label 1").GetComponent<UILabel>().text = "";
        info.transform.Find("Label 2").GetComponent<UILabel>().text = "";
        info.transform.Find("Label 3").GetComponent<UILabel>().text = Infostring;

        Destroy(info, 0.7f);

        //更新后台当前层缓存
        floor_01 f1 = GameObject.Find("battle0" + player.playerInfloor.ToString() + "(Clone)").GetComponent<floor_01>();
        int[] wupingpos = f1.transMaptoArray(gameObject.transform.position);
        for (int i = 0; i <= f1.wupinglist.Count - 1; i++)
        {
            if (f1.CompareArray(wupingpos, f1.wupinglist[i].zuobiao))
            {
                f1.wupinglist.RemoveAt(i);
            }
        }
        GameObject.Find("Main Camera").GetComponent<gameData>().floorDataList[player.playerInfloor - 1].wupinglist = f1.wupinglist;//将层数据同步到后台
    }

    public wupingMain(int hp,int atk,int def,int yellowkey,int bluekey,int redkey,int em,int coin,string info) {
        hpVar = hp;
        atkVar = atk;
        defVar = def;
        yellowKeyVar = yellowkey;
        blueKeyVar = bluekey;
        redKeyVar = redkey;
        emVar = em;
        coinVar = coin;
        Infostring = info;
    }
}
