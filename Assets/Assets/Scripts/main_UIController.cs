using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//这是游戏主界面的UI控制，以及中间一排器材的UI控制

public class main_UIController : MonoBehaviour
{
    //冰盒加冰控制
    public void Addice()
    {
        Ice_quantity = 100;
    }

    /// <summary>
    /// 试管填装试剂面板确定按钮 并生成装有试剂的试管预制体
    /// </summary>
    public void fill_testtube()
    {
        GameObject pre_testtube;
        GameObject instance_testtube;
        Dropdown dropdown1;
        pre_testtube = Resources.Load<GameObject>("Prefabs/pretesttube");   //prefab加载
        if (pre_testtube)
        {
            instance_testtube = Instantiate(pre_testtube) as GameObject; //prefab实例化
            if (instance_testtube)
            {
                instance_testtube.name = "testtube";    //这里以后需要一个列表存储所有试管 以对应场景内初始化的prefab
                instance_testtube.transform.SetParent(GameObject.Find("Canvas/mid_instruments/instru2/panel/subpanel2/ScrollPanel").transform);
                dropdown1 = GameObject.Find("Canvas/mid_instruments/instru2/panel/subpanel1/Dropdown1").GetComponent<Dropdown>(); //获取下拉菜单

                //对此试管属性进行定义
                if (dropdown1.options[dropdown1.value].text != "空")
                {
                    instance_testtube.GetComponent<testtube>().tube.name = dropdown1.options[dropdown1.value].text;
                    instance_testtube.GetComponent<testtube>().tube.content.Add(dropdown1.options[dropdown1.value].text);
                }
                else  //空管无内容物content
                {
                    instance_testtube.GetComponent<testtube>().tube.name = dropdown1.options[dropdown1.value].text;
                }
                instance_testtube.transform.Find("content/Button_trans/Text").GetComponent<Text>().text = "转移到冰盒";
                GameObject.Find("Canvas/mid_instruments/instru2/panel/close").GetComponent<Button>().onClick.Invoke();
            }
        }

    }
    //填装EP管
    public void fill_ep()
    {
        GameObject pre_ep;
        GameObject instance_ep;
        Dropdown dropdown1;
        pre_ep = Resources.Load<GameObject>("Prefabs/preEP");   //prefab加载
        if (pre_ep)
        {
            instance_ep = Instantiate(pre_ep) as GameObject; //prefab实例化
            if (instance_ep)
            {
                instance_ep.name = "ep";    //这里以后需要一个列表存储所有试管 以对应场景内初始化的prefab
                instance_ep.transform.SetParent(GameObject.Find("Canvas/mid_instruments/instru3/panel/subpanel2/ScrollPanel").transform);
                dropdown1 = GameObject.Find("Canvas/mid_instruments/instru3/panel/subpanel1/Dropdown1").GetComponent<Dropdown>(); //获取下拉菜单

                //对此试管属性进行定义
                if(dropdown1.options[dropdown1.value].text != "空")
                {
                    instance_ep.GetComponent<EP>().EP_instance.name = dropdown1.options[dropdown1.value].text;
                    instance_ep.GetComponent<EP>().EP_instance.content.Add(dropdown1.options[dropdown1.value].text);
                }
                else
                {
                instance_ep.GetComponent<EP>().EP_instance.name = dropdown1.options[dropdown1.value].text;
                }
                instance_ep.transform.Find("content/Button_trans/Text").GetComponent<Text>().text = "转移到冰盒";
                GameObject.Find("Canvas/mid_instruments/instru3/panel/close").GetComponent<Button>().onClick.Invoke();
            }
        }

    }
    //setting按钮
    public void setting_func()
    {

    }

    //help按钮
    public void help_func()
    {
        if (count_help_button == 0)
        {
            GameObject.Find("Canvas/help/Image").GetComponent<TweenPosition>().PlayForward();
            GameObject.Find("Canvas/help/Image").GetComponent<TweenScale>().PlayForward();
            count_help_button = 1;
        }
        else if (count_help_button == 1)
        {
            GameObject.Find("Canvas/help/Image").GetComponent<TweenPosition>().PlayReverse();
            GameObject.Find("Canvas/help/Image").GetComponent<TweenScale>().PlayReverse();
            count_help_button = 0;
        }
    }

    //book按钮
    public void book_func()
    {

    }

    //GameObject icon;    //这是拖动仪器后产生的UI


    int count_help_button = 0;
    //bool region_instrument = false; //仪器是否被拖动到屏幕区域
    public float Ice_quantity = 100; //冰盒冰百分比

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*try{
            icon = GameObject.Find("Canvas/icon");
            if (icon)
            {
                //Debug.Log("y="+icon.transform.position.y);
                //Debug.Log("x=" + icon.transform.position.x);

                //拿出下方工具栏仪器时sprite的切换与使新物体放置于场上，可能后面还要加高光
                //限定好可以拖出物体的区域 屏幕是1280*720开发的
                if (icon.transform.position.y > 300 && icon.transform.position.y < 780 && icon.transform.position.x > 25 && icon.transform.position.x < 1000)
                {
                    //到时候肯定弄个预制体替换
                    //icon.GetComponent<Image>().sprite = GameObject.Find("Canvas/settings").GetComponent<Image>().sprite;
                    //换新贴图
                    icon.GetComponent<Image>().sprite = Resources.Load("Textures/Button Round Foreground", typeof(Sprite)) as Sprite;
                    region_instrument = true;
                }
                else
                {
                    //icon.GetComponent<Image>().sprite = GameObject.Find("Canvas/instruments/1").GetComponent<Image>().sprite;
                    icon.GetComponent<Image>().sprite = Resources.Load("Textures/Button Yellow A", typeof(Sprite)) as Sprite;
                    region_instrument = false;
                }
            }
        }
        catch(NullReferenceException e)
        {

        }

        //仪器拖动入场景的判定
        if (Input.GetMouseButtonUp(0))
        {
            if (region_instrument)
            {
                Debug.Log("ojbk");
                //在鼠标位置生成一个新的预制体

                region_instrument = false;
            }
        }*/

        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject.Find("Canvas/taskbook/space").GetComponent<Button>().onClick.Invoke();
        }
        if (Ice_quantity > 0)
        {
            Ice_quantity -= Time.deltaTime * 0.133f; //6s=1s
            GameObject.Find("Canvas/mid_instruments/instru4/panel/Text").GetComponent<Text>().text = string.Format("冰量：{0:0.}%", Ice_quantity);
            if (Ice_quantity <= 10)
            {
                GameObject.Find("Canvas/mid_instruments/instru4/panel/Text").GetComponent<Text>().color = Color.red;
            }
            else
            {
                GameObject.Find("Canvas/mid_instruments/instru4/panel/Text").GetComponent<Text>().color = Color.black;
            }
        }
        else
        {
            Ice_quantity = 0;
            GameObject.Find("Canvas/mid_instruments/instru4/panel/Text").GetComponent<Text>().text = string.Format("冰量：{0:0.}%", 0);
        }


        //Debug.Log(Ice_quantity);
    }
}
