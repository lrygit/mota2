using UnityEngine;
using System.Collections;

public class npcScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showShop() {
        switch (gameObject.name) {
            case "NPCEM":
                GameObject.Find("UI Root").transform.Find("main").Find("ExperienceShopPanel").gameObject.SetActive(true);
                GameObject.Find("hero_0(Clone)").GetComponent<controller>().isShop = true;
                break;
            case "NPCKEY":            
                GameObject.Find("UI Root").transform.Find("main").Find("KeyShopPanel").gameObject.SetActive(true);
                GameObject.Find("hero_0(Clone)").GetComponent<controller>().isShop = true;
                break;
            case "NPCSHOP":
                GameObject.Find("UI Root").transform.Find("main").Find("shopPanel").gameObject.SetActive(true);
                GameObject.Find("hero_0(Clone)").GetComponent<controller>().isShop = true;
                break;
        }
    }
}
