using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conical_flask : MonoBehaviour
{
    public static conical_flask instance { get; private set; }
    public int watervol;
    int tentimewater;
    int ningguji;
    private int[] temp= new int[]{1,2,3,4};
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
        if(watervol==1){
            Debug.Log(111);
        }
    }

   

}
