using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eFfboomControl : MonoBehaviour
{
   // [SerializeField] public GachaManager _GachaManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyeFfboomControl()
    {
        //_GachaManager.InvokeEffOpenCard();
        Destroy(gameObject);
    }
}
