using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class set_Text_errorReword : MonoBehaviour
{
   // public TextMeshPro text;
    void OnEnable()
    {
        gameObject.transform.GetComponent<TextMeshProUGUI>().text = staticVariable.reword;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
