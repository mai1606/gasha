using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlAnimetion : MonoBehaviour
{
    public GameObject _controlAnimetionMain;
    public int type = 0;
    void Start()
    {
    //   Debug.Log( soundControl.b);
     //   this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showAnimetion() 
    {
        if(type == 1)
        {
            _controlAnimetionMain.SetActive(true);
        }
        else
        {
            _controlAnimetionMain.SetActive(true);
            gameObject.SetActive(false);
        }
       
    }


}
