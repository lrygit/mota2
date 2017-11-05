using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    void Awake() {
        Screen.SetResolution(460, 340, false);
        //设置屏幕自动旋转， 并置支持的方向
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;

        Instantiate(Resources.Load("Prefabs/battle0" + player.playerInfloor.ToString()));
        
    }

	// Use this for initialization
	void Start () {
        //加载人物属性
        if (!player.isNewGame)//不是新开的进度时,不使用默认的人物属性,从读取到的存档中来加载人物属性
        {

        }
        else
        {
            //游戏面板
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("floorNum").GetComponent<UILabel>().text = player.playerInfloor.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("level").GetComponent<UILabel>().text = player.level.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("hp").GetComponent<UILabel>().text = player.HP.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("atk").GetComponent<UILabel>().text = player.ATK.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("def").GetComponent<UILabel>().text = player.DEF.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("jy").GetComponent<UILabel>().text = player.empiric.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("coin").GetComponent<UILabel>().text = player.coin.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("yellowCount").GetComponent<UILabel>().text = player.yellowKey.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("blueCount").GetComponent<UILabel>().text = player.blueKey.ToString();
            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("redCount").GetComponent<UILabel>().text = player.redKey.ToString();

            
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
