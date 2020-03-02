using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //评分系统声明
    public int score;
    //游戏阶段控制
    public int stage;
    //场景物体控制
    GameObject RongQi;
    GameObject LiXinJi;
    GameObject ShuiYuGuo;
    GameObject DianYongYi;
    GameObject PCR;

    // Start is called before the first frame update
    void Start()
    {
        score = 70;
        stage = 1;
        RongQi = GameObject.Find("Canvas/mid_instruments/instru1");
        LiXinJi = GameObject.Find("Canvas/upper_instruments/instru1");
        ShuiYuGuo = GameObject.Find("Canvas/upper_instruments/instru2");
        PCR = GameObject.Find("Canvas/upper_instruments/instru3");
        DianYongYi = GameObject.Find("Canvas/upper_instruments/instru4");

        RongQi.SetActive(false);
        LiXinJi.SetActive(false);
        ShuiYuGuo.SetActive(false);
        PCR.SetActive(false);
        DianYongYi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stage == 1)
        {
            RongQi.SetActive(true);
            LiXinJi.SetActive(true);
            ShuiYuGuo.SetActive(true);
            PCR.SetActive(false);
            DianYongYi.SetActive(true);
        }
        else if (stage == 2)
        {

        }
    }
}
