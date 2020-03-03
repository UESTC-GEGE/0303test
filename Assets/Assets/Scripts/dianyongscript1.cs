using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dianyongscript1 : MonoBehaviour
{
   
     public void Click_water()
    {
        conical_flask.instance.watervol+=1;
    }
    public void Click_tentimeswater(){
        conical_flask.instance.tentimewater+=1;
    }
    public void Click_ninggu(){
        conical_flask.instance.ningguji+=1;
    }
    public void Click_waterR()
    {
        conical_flask.instance.watervol-=1;
    }
    public void Click_tentimeswaterR(){
        conical_flask.instance.tentimewater-=1;
    }
    public void Click_ningguR(){
        conical_flask.instance.ningguji-=1;
    }
    public void heat(){
        transform.parent.gameObject.SetActive(false);
        conical_flask.instance.ifheat=1;
    }
  
}

