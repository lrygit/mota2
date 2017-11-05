using UnityEngine;
using System.Collections;

public class keyShopScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addYellow() {
        if (player.coin >= 30) {//金币足够时
            //更新后台数据
            player.coin -= 30;
            player.yellowKey++;
            //更新游戏面板
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("coin").GetComponent<UILabel>().text = player.coin.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("yellowCount").GetComponent<UILabel>().text = player.yellowKey.ToString();
        }
    }

    public void addBlue()
    {
        if (player.coin >= 80)
        {//金币足够时
            //更新后台数据
            player.coin -= 80;
            player.blueKey++;
            //更新游戏面板
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("coin").GetComponent<UILabel>().text = player.coin.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("blueCount").GetComponent<UILabel>().text = player.blueKey.ToString();
        }
    }

    public void addRed()
    {
        if (player.coin >= 200)
        {//金币足够时
            //更新后台数据
            player.coin -= 200;
            player.redKey++;
            //更新游戏面板
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("coin").GetComponent<UILabel>().text = player.coin.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("redCount").GetComponent<UILabel>().text = player.redKey.ToString();
        }
    }

    public void quit() {
        //关闭商店
        gameObject.SetActive(false);
        //开启移动标识
        GameObject.Find("hero_0(Clone)").GetComponent<controller>().isShop = false;
    }
}
