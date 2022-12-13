using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    public cardInfo cards;
 //   public GameObject effBoom;
   // public GameObject bgBlack;
    GameObject Eff;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (cards != null)
        {

            gameObject.GetComponent<SpriteRenderer>().sprite = cards.IamgeCard;
        }
    }
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
