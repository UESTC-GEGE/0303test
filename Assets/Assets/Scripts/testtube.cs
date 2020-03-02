using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruments;
using UnityEngine.UI;


public class testtube : MonoBehaviour
{
    //用于转移物体到管架or冰盒
    public void Transport()
    {
        //向冰盒转移
        if (transform.parent.parent.parent.parent.name == "instru2")
        {
            transform.SetParent(GameObject.Find("Canvas/mid_instruments/instru4/panel/ScrollPanel").transform);
            transform.Find("content/Button_trans/Text").GetComponent<Text>().text = "转移到管架";
            //酶活降低速率变为正常
            tube.activity_downrate /= 10.0f;
        }
        //向试管架/EP管架转移
        else if (transform.parent.parent.parent.name == "instru4")
        {
            transform.SetParent(GameObject.Find("Canvas/mid_instruments/instru2/panel/subpanel2/ScrollPanel").transform);
            transform.Find("content/Button_trans/Text").GetComponent<Text>().text = "转移到冰盒";
            //酶活降低速率减小
            tube.activity_downrate /= 10.0f;
            
        }

    }

    //用于EventSystem，鼠标移动上去显示详细信息，离开关闭
    public void Pointenter()
    {
        content_string = "";
        foreach (var item in tube.content)
        {
            content_string = content_string + "    " + item + "\n";
        }
        content_panel.SetActive(true);
    }
    public void Pointexit()
    {
        content_panel.SetActive(false);
        content_string = "";
    }

    // 用于删除该试管及试剂
    public void Deleteinstance()
    {
        Destroy(gameObject, 0.0f);
    }


    /// <summary>
    /// 用于Event System的鼠标抬起事件：移液枪放液，与1合并了
    /// </summary>
    //public void Rightpointup()
    //{
    //    if (Input.GetMouseButtonUp(1))
    //    {
    //        //调用main_UIController是否使用仪器1
    //        bool is_using_click_instru1 = GameObject.Find("UIController").GetComponent<clickedinstru_controller>().is_using_click_instru1;
    //        //是否在使用移液枪？ 使用移液枪的时候才进行相关操作
    //        if (is_using_click_instru1)
    //        {
    //            //枪头的液体是什么
    //            List<string> current_liquid = GameObject.Find("UIController").GetComponent<clickedinstru_controller>().current_liquid;
    //            //上次放液里面的内容
    //            List<string> last_liquid = GameObject.Find("UIController").GetComponent<clickedinstru_controller>().last_liquid;

    //            //有液体时才放液
    //            if (current_liquid.Count != 0)
    //            {
    //                //该试管加入此试剂的内容物
    //                foreach (var item in current_liquid)
    //                {
    //                    if (!tube.content.Contains(item))
    //                    {
    //                        tube.content.Add(item);                          
    //                    }
    //                }
    //                //这里必不能用==，==是会比较引用，也不能用Equals，使用自己写的方法。（这也太麻烦了。。）
    //                if (last_liquid.Count != 0 && !ListCompareClass.ListCompare(last_liquid, current_liquid))
    //                {
    //                    Debug.Log("枪头不干净哈");
    //                }
    //                Debug.Log("放" + current_liquid[0]);
    //                //上次放液内容更改
    //                GameObject.Find("UIController").GetComponent<clickedinstru_controller>().last_liquid = new List<string> (current_liquid);
    //                //清空移液枪
    //                GameObject.Find("UIController").GetComponent<clickedinstru_controller>().current_liquid = new List<string>();
    //                Pointenter();

    //            }
    //        }
    //    }
    //}
    /// <summary>
    /// 移液枪吸液放液
    /// </summary>
    public void Leftpointup()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //调用main_UIController是否使用仪器1
            bool is_using_click_instru1 = GameObject.Find("UIController").GetComponent<clickedinstru_controller>().is_using_click_instru1;
            //是否在使用移液枪？ 使用移液枪的时候才进行相关操作
            if (is_using_click_instru1)
            {
                //枪头的液体是什么
                List<string> current_liquid = GameObject.Find("UIController").GetComponent<clickedinstru_controller>().current_liquid;
                //上次放液里面的内容
                List<string> last_liquid = GameObject.Find("UIController").GetComponent<clickedinstru_controller>().last_liquid;

                //无液体时才吸液
                if (current_liquid.Count == 0 && tube.content.Count != 0)
                {
                    //填满移液枪,一定注意不能用等号！！！要new！！！！！！！
                    GameObject.Find("UIController").GetComponent<clickedinstru_controller>().current_liquid = new List<string> (tube.content);

                    if (last_liquid.Count != 0 && !ListCompareClass.ListCompare(last_liquid, tube.content))
                    {
                        Debug.Log("枪头不干净哈，扣分");
                        GameObject.Find("GameController").GetComponent<GameController>().score -= 1;
                    }
                    Debug.Log("吸" + tube.name);
                }
                //有液体时才放液
                else if (current_liquid.Count != 0)
                {
                    //该试管加入此试剂的内容物
                    foreach (var item in current_liquid)
                    {
                        if (!tube.content.Contains(item))
                        {
                            tube.content.Add(item);
                        }
                    }
                    //这里必不能用==，==是会比较引用，也不能用Equals，使用自己写的方法。（这也太麻烦了。。）
                    if (last_liquid.Count != 0 && !ListCompareClass.ListCompare(last_liquid, current_liquid))
                    {
                        Debug.Log("枪头不干净哈，扣分");
                        GameObject.Find("GameController").GetComponent<GameController>().score -= 1;
                    }
                    Debug.Log("放" + current_liquid[0]);
                    //上次放液内容更改
                    GameObject.Find("UIController").GetComponent<clickedinstru_controller>().last_liquid = new List<string>(current_liquid);
                    //清空移液枪
                    GameObject.Find("UIController").GetComponent<clickedinstru_controller>().current_liquid = new List<string>();
                    Pointenter();

                }
            }
        }
    }


    //调用Instruments脚本的试管类
    public Testtube tube = new Testtube();
    public GameObject content_panel;
    string content_string = "";
    

    // Start is called before the first frame update
    void Start()
    {
        //content_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tube.content.Count > 1)
        {
            tube.name = "mixture";
        }
        else if (tube.content.Count == 1)
        {
            tube.name = tube.content[0];
        }

        if (tube.enzyme_activity == -1)
        {
            content_panel.transform.Find("Text").GetComponent<Text>().text = "name: \n    " + tube.name + "\n" + "content: \n" + content_string;
        }
        else
        {
            content_panel.transform.Find("Text").GetComponent<Text>().text = "name: \n    " + tube.name + "\n" + "content: \n" + content_string + "活性：" + tube.enzyme_activity + "%";
        }
        //根据冰盒冰量决定此管酶活降低速度...
        if (tube.enzyme_activity > 0)
        {
            if(transform.parent.parent.parent.name == "instru4")
            {
                tube.enzyme_activity -= Time.deltaTime * 0.2f * tube.activity_downrate * (GameObject.Find("UIController").GetComponent<main_UIController>().Ice_quantity * -0.09f + 10);

            }
            else
            {
                tube.enzyme_activity -= Time.deltaTime * 0.2f * tube.activity_downrate;

            }
            transform.Find("content/Text_enzyme").GetComponent<TextMesh>().text = string.Format("酶活：{0:.00}%", tube.enzyme_activity);

        }

    }
}
