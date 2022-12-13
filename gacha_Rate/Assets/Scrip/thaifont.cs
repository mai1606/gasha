using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class thaifont : MonoBehaviour
{
    // Start is called before the first frame update
    
    TextMeshProUGUI textDisplay;
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = ThaiFontAdjuster.Adjust(GetComponent<TextMeshProUGUI>().text);
    }
    // Update is called once per frame
    void Update()
    {

        
    }
}
