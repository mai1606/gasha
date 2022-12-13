using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlAnimetionMain : MonoBehaviour
{
    public GameObject itemReword;
    public GameObject detailReword;
    void Start()
    {
       
    }

   
    void Update()
    {
       if(itemReword.activeSelf)
        {
            detailReword.SetActive(true);
        }
       
        
    }
    
}
