using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour
{

    public float moveCD = 1f;
    public float maxCd = 0.8f;

    public bool isBattle = false;//是否处于战斗中，若处于战斗中，则无法移动
    public bool isOpenDoor = false;//是否处于开门状态中，若处于开门状态，则无法移动
    public bool isDoor = false;//遇到门，并且没钥匙
    public bool isPush = false;//是否处于长按按钮状态,若没有则无视移动CD
    public bool isBeginLongpush = false;//是否开始计时，判断是否进入长按状态
    public bool isShop = false;//是否正在浏览商店

    RaycastHit2D[] hitInfo;
    Animator ani;
    // Use this for initialization
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果场景内不存在战斗面板，也不存在信息提示面板，并且不处于战斗中时，自动开启移动标示
        if (GameObject.Find("UI Root").transform.Find("main").Find("battlePanel").gameObject.activeSelf == false && isBattle && !GameObject.Find("UI Root").transform.Find("main").Find("UIPanel(Clone)")) {
            isBattle = false;
        }

        moveCD += Time.deltaTime;
               
        if (moveCD > maxCd || !isPush)
        {
            //Debug.Log("keyCanDown");
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
                moveCD = 0f;
            }

            if (Input.GetKey(KeyCode.W))
            {
                maxCd = 0.8f;
                isPush = true;
                if (!isCollider(KeyCode.W) && !isBattle && !isOpenDoor && !isDoor && !isShop)
                {
                    ani.SetTrigger("startup");
                    gameObject.transform.position += new Vector3(0f, 0.32f, 0f);

                    if (isBeginLongpush) { maxCd = 0.05f; }

                    if (!isBeginLongpush && moveCD > maxCd) { isBeginLongpush = true; maxCd = 0.05f; }
                    moveCD = 0f;

                }

            }
            else if (Input.GetKey(KeyCode.S))
            {
                maxCd = 0.8f;
                isPush = true;
                if (!isCollider(KeyCode.S) && !isBattle && !isOpenDoor && !isDoor && !isShop)
                {
                    ani.SetTrigger("startdown");
                    gameObject.transform.position -= new Vector3(0f, 0.32f, 0f);
                    if (isBeginLongpush) { maxCd = 0.05f; }

                    if (!isBeginLongpush && moveCD > maxCd) { isBeginLongpush = true; maxCd = 0.05f; }
                    moveCD = 0f;
                }

            }
            else if (Input.GetKey(KeyCode.A))
            {
                maxCd = 0.8f;
                isPush = true;
                if (!isCollider(KeyCode.A) && !isBattle && !isOpenDoor && !isDoor && !isShop)
                {
                    ani.SetTrigger("startleft");
                    gameObject.transform.position -= new Vector3(0.32f, 0f, 0f);
                    if (isBeginLongpush) { maxCd = 0.05f; }

                    if (!isBeginLongpush && moveCD > maxCd) { isBeginLongpush = true; maxCd = 0.05f; }
                    moveCD = 0f;
                }

            }
            else if (Input.GetKey(KeyCode.D))
            {
                maxCd = 0.8f;
                isPush = true;
                if (!isCollider(KeyCode.D) && !isBattle && !isOpenDoor && !isDoor && !isShop)
                {
                    ani.SetTrigger("startright");
                    gameObject.transform.position += new Vector3(0.32f, 0f, 0f);
                    if (isBeginLongpush) { maxCd = 0.05f; }

                    if (!isBeginLongpush && moveCD > maxCd) { isBeginLongpush = true; maxCd = 0.05f; }
                    moveCD = 0f;
                }

            }
        }



        //解除长按事件
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            isBeginLongpush = false;
            isPush = false;
            isDoor = false;
            maxCd = 0.8f;
            Debug.Log("keyup");
        }

    }

    private bool isCollider(KeyCode dir)
    {
        bool result = false;
        Vector2 v2 = transform.position;
        Vector2 dirv2 = new Vector2();
        Vector2 v3 = new Vector2();
        switch (dir)
        {
            case KeyCode.W:
                //Debug.Log(v2);
                dirv2 = Vector2.up;
                v3 = v2 + new Vector2(0f, 0.32f);
                break;
            case KeyCode.S:
                dirv2 = -Vector2.up;
                v3 = v2 + new Vector2(0f, -0.32f);
                break;
            case KeyCode.A:
                dirv2 = -Vector2.right;
                v3 = v2 + new Vector2(-0.32f, 0f);
                break;
            case KeyCode.D:
                dirv2 = Vector2.right;
                v3 = v2 + new Vector2(0.32f, 0f);
                break;
        }

        if (v3.x < 0.158f || v3.x > 3.36f || v3.y < -3.36f || v3.y > -0.158f)
        {
            result = true;
        }

        if (Physics2D.Raycast(v2, -Vector2.up))
        {
            hitInfo = Physics2D.RaycastAll(v2, dirv2, 0.32f);
            if (hitInfo.Length > 1)
            {
                //Debug.Log(hitInfo.Length);
                foreach (RaycastHit2D info in hitInfo)
                {
                    //遇到墙的事件
                    if (info.collider.name == "Collision")
                    {
                        //Debug.Log(info.collider.name);
                        result = true;
                    }
                    //遇到怪物时的事件
                    else if (info.collider.tag == "enemy" && !isBattle && !isShop)
                    {
                        //弹出战斗面板，禁止主角移动
                        isBattle = true;
                        GameObject labels = GameObject.Find("UI Root").transform.Find("main").Find("battlePanel").gameObject;
                        labels.gameObject.SetActive(true);
                        //增加动画组件
                        UISpriteAnimation usa = labels.transform.Find("enemysprite").gameObject.AddComponent<UISpriteAnimation>();
                        usa.framesPerSecond = 6;
                        //根据属性给面板赋值
                        UIAtlas atlasX = (UIAtlas)Resources.Load("enemy_" + info.collider.gameObject.GetComponent<enemypro>().enemyTypeID.ToString() + "Ani", typeof(UIAtlas));
                        labels.transform.Find("enemysprite").GetComponent<UISprite>().atlas = atlasX;
                        Debug.Log(atlasX.spriteList[0].name + "lll" + atlasX.spriteList.Count);
                        labels.transform.Find("enemysprite").GetComponent<UISprite>().spriteName = atlasX.spriteList[0].name;
                        labels.transform.Find("enemy_hp").GetComponent<UILabel>().text = info.collider.GetComponent<enemypro>().hp.ToString();
                        labels.transform.Find("enemy_atk").GetComponent<UILabel>().text = info.collider.GetComponent<enemypro>().atk.ToString();
                        labels.transform.Find("enemy_def").GetComponent<UILabel>().text = info.collider.GetComponent<enemypro>().def.ToString();
                        labels.transform.Find("hero_hp").GetComponent<UILabel>().text = gameObject.GetComponent<playerpro>().hp.ToString();
                        labels.transform.Find("hero_atk").GetComponent<UILabel>().text = gameObject.GetComponent<playerpro>().atk.ToString();
                        labels.transform.Find("hero_def").GetComponent<UILabel>().text = gameObject.GetComponent<playerpro>().def.ToString();

                        gameObject.GetComponent<battleMain>().duel(gameObject, info.collider.gameObject);



                    }
                    //遇到门的事件
                    else if (info.collider.tag == "door" && !isOpenDoor)
                    {
                        if (info.collider.GetComponent<delDoor>().isOpened())
                        {
                            //同步钥匙数量面板,并开门
                            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("yellowCount").GetComponent<UILabel>().text = player.yellowKey.ToString();
                            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("blueCount").GetComponent<UILabel>().text = player.blueKey.ToString();
                            GameObject.Find("UI Root").transform.Find("main").Find("labelPanel").Find("redCount").GetComponent<UILabel>().text = player.redKey.ToString();

                            info.collider.GetComponent<delDoor>().setOpen();
                            isOpenDoor = true;
                        }
                        else
                        {
                            isDoor = true;
                        }
                    }
                    //遇到道具时的事件
                    else if (info.collider.tag == "wuping" && !isBattle)
                    {
                        isBattle = true;
                        result = true;
                        wupingMain wm = info.collider.GetComponent<wupingMain>();
                        wm.useWuping();
                    }
                    //遇到楼梯时的事件
                    else if (info.collider.tag == "floor")
                    {
                        if (info.collider.name == "up_floor")
                        {//上楼
                            isOpenDoor = true;
                            player.upOrdown = "up";
                            Debug.Log("battle0" + player.playerInfloor.ToString() + "(Clone)");
                            GameObject.Find("battle0" + player.playerInfloor.ToString() + "(Clone)").GetComponent<myTweenAlpha>().tweenOut();
                        }
                        else if (info.collider.name == "down_floor")
                        {//下楼
                            isOpenDoor = true;
                            player.upOrdown = "down";
                            GameObject.Find("battle0" + player.playerInfloor.ToString() + "(Clone)").GetComponent<myTweenAlpha>().tweenOut();
                        }
                    }
                    //遇到NPC时的事件
                    else if (info.collider.tag == "npc" && !isBattle) {
                        info.collider.GetComponent<npcScript>().showShop();
                    }
                }
            }
            //Debug.Log(v2);
            //Debug.DrawRay(v2, -Vector2.up);
        }

        //Debug.Log(result);
        return result;
    }

}
