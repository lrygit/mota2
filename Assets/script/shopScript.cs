using UnityEngine;
using System.Collections;

public class shopScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addATK() {
        if (player.coin >= 25) {//金币足够时
            //更改后台数据
            player.coin -= 25;
            player.ATK += 5;
            //更改面板属性
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("coin").GetComponent<UILabel>().text = player.coin.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("atk").GetComponent<UILabel>().text = player.ATK.ToString();
            //同步人物属性
            GameObject.Find("hero_0(Clone)").GetComponent<playerpro>().atk = player.ATK;
        }
    }

    public void addDEF() {
        if (player.coin >= 25)
        {//金币足够时
            //更改后台数据
            player.coin -= 25;
            player.DEF += 5;
            //更改面板属性
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("coin").GetComponent<UILabel>().text = player.coin.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("def").GetComponent<UILabel>().text = player.DEF.ToString();
            //同步人物属性
            GameObject.Find("hero_0(Clone)").GetComponent<playerpro>().def = player.DEF;
        }
    }

    public void addHP()
    {
        if (player.coin >= 25)
        {//金币足够时
            //更改后台数据
            player.coin -= 25;
            player.HP += 500;
            //更改面板属性
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("coin").GetComponent<UILabel>().text = player.coin.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("hp").GetComponent<UILabel>().text = player.HP.ToString();
            //同步人物属性
            GameObject.Find("hero_0(Clone)").GetComponent<playerpro>().hp = player.HP;
        }
    }

    public void quit()
    {
        //关闭商店
        gameObject.SetActive(false);
        //开启移动标识
        GameObject.Find("hero_0(Clone)").GetComponent<controller>().isShop = false;
    }
}
