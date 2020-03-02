using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_UIController : MonoBehaviour
{

    //游戏开始场景跳转
    public void GameStart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync(1);
    }
    //游戏程序退出
    public void GameExit()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    //游戏说明书展现
    public void GameHelp()
    {
        instructions.SetActive(true);
    }
    //说明书关闭
    public void InsClose()
    {
        instructions.SetActive(false);
    }


    //变量
    public GameObject instructions;         //说明书
    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(1280, 720, false);      //固定分辨率1280*800

        ////说明书初始化隐藏控制
        //if (name == "instructions")
        //{
        //    instructions = GameObject.Find("Canvas/instructions");
        //}
        //else if (name == "ButtonHelp")
        //{
        //    instructions = GameObject.Find("Canvas/instructions");
        //    instructions.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

}
