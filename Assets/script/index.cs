using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class index : MonoBehaviour {

    public GameObject old_panel;
    public GameObject confirm_panel;
    public bool confirm_flag;

    // Use this for initialization
    void Start () {
        UIEventListener.Get(GameObject.Find("UI Root").transform.Find("option_new").gameObject).onHover +=on_hover;
        UIEventListener.Get(GameObject.Find("UI Root").transform.Find("option_old").gameObject).onHover += on_hover;
        UIEventListener.Get(GameObject.Find("UI Root").transform.Find("option_quit").gameObject).onHover += on_hover;
        UIEventListener.Get(confirm_panel.transform.Find("true").gameObject).onClick += operation_confirm;
        UIEventListener.Get(confirm_panel.transform.Find("false").gameObject).onClick += operation_confirm;
        UIEventListener.Get(GameObject.Find("UI Root").transform.Find("option_old").gameObject).onClick += go_old;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void on_hover(GameObject g1,bool isover) {
        if(isover)
            g1.transform.Find("option_hover").gameObject.SetActive(true);
        else
            g1.transform.Find("option_hover").gameObject.SetActive(false);
    }

    public void go_old(GameObject g1) {
        old_panel.SetActive(true);
    }

    public void operation_confirm(GameObject g1) {
        confirm_flag = bool.Parse (g1.name);
        if (confirm_flag)
        {
            Application.Quit();
        }
        else {
            confirm_panel.SetActive(false);
        }
    }

     
    public void quit() {
        confirm_panel.SetActive(true);
    }
}
