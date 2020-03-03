using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class conical_flask : MonoBehaviour
{
    public static conical_flask instance { get; private set; }
    public int watervol;
    public int tentimewater;
    public int ningguji;
    public int ifheat;
    private int[] temp= new int[]{1,2,3,4};
    public Text waterrvol;
    public Text ningvol;
    public Text tenwatervoi;
    public int TotalTime=90;//总时间

    public Text TimeText;//在UI里显示时间
    private int mumite;//分

    private int second;//秒
    // Start is called before the first frame update
    void Awake() {
        instance=this;
    }
    void Start()
    {

        watervol=0;
        tentimewater=0;
        ningguji=0;
        //mousePos=this.transform;
        //canvasRec = this.GetComponentInParent<Canvas>().transform as RectTransform;
    }

    // Update is called once per frame
    void Update()
    {
        printt1(watervol,ningguji,tentimewater);
        if(ifheat==1)
        {
            ifheat=0;
            transform.Find("con1").gameObject.SetActive(true);
            Invoke("StartCount",4);
        }
    }
    public void printt1(int n,int nn,int nnn)
    {
        waterrvol.text="水量："+n.ToString();
        ningvol.text="凝固剂含量："+nn.ToString();
        tenwatervoi.text="浓缩缓冲液含量："+nnn.ToString();
    }
    void StartCount(){
        transform.Find("con2").gameObject.SetActive(true);
        StartCoroutine(startTime()); 

    }
     public IEnumerator  startTime() {

        while (TotalTime >= 0) {

            //Debug.Log(TotalTime);//打印出每一秒剩余的时间

            yield return new WaitForSeconds(1);//由于开始倒计时，需要经过一秒才开始减去1秒，
                                               //所以要先用yield return new WaitForSeconds(1);然后再进行TotalTime--;运算

            TotalTime--;

            TimeText.text="Time:"+TotalTime;

            /*if (TotalTime<= 0){                //如果倒计时剩余总时间为0时，就跳转场景

                LoadScene();

            }*/

            mumite=TotalTime/60; //输出显示分

            second=TotalTime%60; //输出显示秒

            string length = mumite.ToString ();
                if (second >= 10) {

                    TimeText.text = "0" + mumite + ":" + second;
                }     //如果秒大于10的时候，就输出格式为 00：00

                else
                    TimeText.text = "0" + mumite + ":0" + second;      //如果秒小于10的时候，就输出格式为 00：00

            } 


    }

    
   

}


