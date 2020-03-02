using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class click_closepanel : MonoBehaviour
{
    /// <summary>
    /// 关闭面板
    /// </summary>
    public void ClosePanel()
    {
        panel.SetActive(false);
    }
    GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
