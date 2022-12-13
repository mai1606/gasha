using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDisplayCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    float posx = 0;
    void Start()
    {
        if (SaveSystem.HasKey("canvasPosition") && SaveSystem.HasKey("canvasScale"))
        {          
            Debug.Log("hasKey"+SaveSystem.GetVector3("canvasPosition"));
            gameObject.GetComponent<RectTransform>().anchoredPosition = SaveSystem.GetVector3("canvasPosition");
            gameObject.transform.localScale = SaveSystem.GetVector3("canvasScale");
        }
        else
        {
            Debug.Log("dont hasKey");
        }      
    }

    // Update is called once per frame
    void Update()
    {    
     
    }

}
