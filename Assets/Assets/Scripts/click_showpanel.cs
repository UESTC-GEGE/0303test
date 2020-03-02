using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_showpanel : MonoBehaviour
{
    /// <summary>
    /// 显示各种面板
    /// </summary>
    public void ShowPanel()
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = transform.Find("panel").gameObject;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
