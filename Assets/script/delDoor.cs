using UnityEngine;
using System.Collections;

public class delDoor : MonoBehaviour
{

    public string doorColor;
    private Animator doorAni;

    // Use this for initialization
    void Start()
    {
        doorAni = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = doorAni.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("yellowDoor") || info.IsName("blueDoor") || info.IsName("redDoor") )
        {
            //判断是否播放完成
            if (info.normalizedTime >= 0.9f)
            {
                openMoveFlag();
                GameObject.Find("battle0" + player.playerInfloor.ToString()+"(Clone)").GetComponent<myTweenAlpha>()._thisSprite.Remove(gameObject);
                Destroy(gameObject);

                //更新后台当前层缓存
                floor_01 f1 = GameObject.Find("battle0" + player.playerInfloor.ToString() + "(Clone)").GetComponent<floor_01>();
                int[] doorpos = f1.transMaptoArray(gameObject.transform.position);
                for (int i = 0; i <= f1.doorlist.Count - 1; i++)
                {
                    if (f1.CompareArray(doorpos, f1.doorlist[i].zuobiao))
                    {
                        f1.doorlist.RemoveAt(i);
                    }
                }
                GameObject.Find("Main Camera").GetComponent<gameData>().floorDataList[player.playerInfloor - 1].doorlist = f1.doorlist;//将层数据同步到后台
            }
        }
    }

    //设置开门动画
    public void setOpen()
    {
        doorAni.SetTrigger("open");
    }
    //判断是否有此颜色的钥匙
    public bool isOpened()
    {
        bool result = false;
        switch (doorColor)
        {
            case "yellow":
                if (player.yellowKey > 0)
                {
                    player.yellowKey--;
                    result = true;
                }

                break;
            case "blue":
                if (player.blueKey > 0)
                {
                    player.blueKey--;
                    result = true;
                }

                break;
            case "red":
                if (player.redKey > 0)
                {
                    player.redKey--;
                    result = true;
                }
                break;
        }
        return result;
    }

    //播放完毕以后恢复人物的移动
    public void openMoveFlag() {
        GameObject.Find("hero_0(Clone)").GetComponent<controller>().isOpenDoor = false;
    }
}
