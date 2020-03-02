using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickedinstru_controller : MonoBehaviour
{
    public bool is_using_click_instru1 = false; //正在使用下方仪器一（移液枪）与否
    public List<string> last_liquid = new List<string>(); //移液枪上次放液里面的内容
    public List<string> current_liquid = new List<string>(); //移液枪里面的内容

    //下方的仪器们 
    /// <summary>
    /// 点击仪器造成的影响（如弹出菜单或按钮变色）
    /// </summary>
    public void click_use_1()           //1号仪器-移液枪
    {
        if (!is_using_click_instru1)
        {
            Cursor.SetCursor(Resources.Load("Textures/移液枪", typeof(Texture2D)) as Texture2D, Vector2.zero, CursorMode.Auto);
            GameObject.Find("Canvas/click_instruments/Scrollpanel/1").GetComponent<Image>().sprite = Resources.Load("Textures/移液枪-触发", typeof(Sprite)) as Sprite;
            is_using_click_instru1 = true;
        }
        else if (is_using_click_instru1)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            GameObject.Find("Canvas/click_instruments/Scrollpanel/1").GetComponent<Image>().sprite = Resources.Load("Textures/移液枪-未触发", typeof(Sprite)) as Sprite;
            is_using_click_instru1 = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //键盘控制下方button
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            click_use_1();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {

        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {

        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {

        }
        else if (Input.GetMouseButtonUp(1) && is_using_click_instru1 == true)     //更换移液枪枪头
        {
            last_liquid = new List<string>();
            current_liquid = new List<string>();
            Debug.Log("更换枪头");
        }

    }
}
