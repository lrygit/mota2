using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class myTweenAlpha : MonoBehaviour {

    public List<GameObject> _thisMesh = new List<GameObject>();
    public List<GameObject> _thisSprite = new List<GameObject>();

    private float AlphaValue = 1.0f;
    private float time = 0.0f;
    private bool state = false;

    private bool isOut = false;

    // Use this for initialization
    void Start () {
        _thisMesh.Add(gameObject.transform.Find("地板").Find("All").gameObject);
        _thisMesh.Add(gameObject.transform.Find("墙壁").Find("terrain").gameObject);
        if (gameObject.transform.Find("块层 3").Find("up_floor"))
        {
            _thisMesh.Add(gameObject.transform.Find("块层 3").Find("up_floor").gameObject);
        }
        if (gameObject.transform.Find("块层 3").Find("down_floor")) {
            _thisMesh.Add(gameObject.transform.Find("块层 3").Find("down_floor").gameObject);
        }

        foreach(Transform t1 in gameObject.transform.Find("块层 3").transform) {
            if (t1.tag == "npc") {
                _thisSprite.Add(t1.gameObject);
            }
        }
       
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void tweenOut() {
        if (!isOut)
        {
            StartCoroutine("tweenOutMain");
            isOut = true;

            GameObject g1 = Instantiate(Resources.Load("prefabs/passFloor")) as GameObject;
            g1.transform.parent = GameObject.Find("UI Root").transform.Find("main").transform;
            g1.transform.localScale = new Vector3(1f, 1f, 1f);
            g1.SetActive(true);
            g1.transform.localPosition = Vector3.zero;

            int floorid=0;
            if (player.upOrdown == "up") {floorid = player.playerInfloor+1; }
            else if (player.upOrdown == "down") {floorid = player.playerInfloor-1; }

            g1.transform.Find("floorID").GetComponent<UILabel>().text = floorid.ToString();
        }
    }

    IEnumerator tweenOutMain() {
        while (AlphaValue > 0f)
        {
            time += Time.deltaTime;
            if (time > 0.1f)
            {
                state = true;
                time = 0;
            }
            if (state)
            {
                AlphaValue -= 0.05f;

            }

            for (int i = 0; i <= _thisMesh.Count - 1; i++)
            {
                _thisMesh[i].GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1F, AlphaValue);
            }

            for (int j = 0; j <= _thisSprite.Count - 1; j++)
            {
                _thisSprite[j].GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1F, AlphaValue);
            }
            yield return 0;
        }
        
        //删除所有游戏物体
        for (int i = 0; i <= _thisMesh.Count - 1; i++)
        {
            Destroy(_thisMesh[i]);
        }

        for (int j = 0; j <= _thisSprite.Count - 1; j++)
        {
            Destroy(_thisSprite[j]);
        }
        Destroy(GameObject.Find("battle0" + player.playerInfloor.ToString() + "(Clone)").gameObject);

        //加载下一个层的怪物
        if (player.upOrdown == "up") { player.playerInfloor++; }
        else if (player.upOrdown == "down") { player.playerInfloor--; }

        Instantiate(Resources.Load("Prefabs/battle0" + player.playerInfloor.ToString()));
        GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("floorNum").GetComponent<UILabel>().text = player.playerInfloor.ToString();

        Destroy(GameObject.Find("UI Root").transform.Find("main").Find("passFloor(Clone)").gameObject);
        StopCoroutine("tweenOutMain");
    }
}
