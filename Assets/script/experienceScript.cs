using UnityEngine;
using System.Collections;

public class experienceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addDEF() {
        if (player.empiric >= 30) {//经验足够时
            //更新后台数据
            player.empiric -= 30;
            player.DEF += 5;

            //更新面板属性
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("jy").GetComponent<UILabel>().text = player.empiric.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("def").GetComponent<UILabel>().text = player.DEF.ToString();

            //更新人物属性
            GameObject.Find("hero_0(Clone)").GetComponent<playerpro>().def = player.DEF;
            
        }
    }

    public void addATK()
    {
        if (player.empiric >= 30)
        {//经验足够时
            //更新后台数据
            player.empiric -= 30;
            player.ATK += 5;

            //更新面板属性
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("jy").GetComponent<UILabel>().text = player.empiric.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("atk").GetComponent<UILabel>().text = player.ATK.ToString();

            //更新人物属性
            GameObject.Find("hero_0(Clone)").GetComponent<playerpro>().atk = player.ATK;

        }
    }

    public void addLEVEL()
    {
        if (player.empiric >= 100)
        {//经验足够时
            //更新后台数据
            player.empiric -= 100;
            player.DEF += 7;
            player.ATK += 7;
            player.HP += 200;
            player.level++;

            //更新面板属性
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("jy").GetComponent<UILabel>().text = player.empiric.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("def").GetComponent<UILabel>().text = player.DEF.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("atk").GetComponent<UILabel>().text = player.ATK.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("hp").GetComponent<UILabel>().text = player.HP.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("level").GetComponent<UILabel>().text = player.level.ToString();

            //更新人物属性
            GameObject.Find("hero_0(Clone)").GetComponent<playerpro>().def = player.DEF;
            GameObject.Find("hero_0(Clone)").GetComponent<playerpro>().atk = player.ATK;
            GameObject.Find("hero_0(Clone)").GetComponent<playerpro>().hp = player.HP;
        }
    }

    public void quit() {
        //关闭商店
        gameObject.SetActive(false);
        //开启移动标识
        GameObject.Find("hero_0(Clone)").GetComponent<controller>().isShop = false;
    }
}
