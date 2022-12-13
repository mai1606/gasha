using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnable_obj_load : MonoBehaviour
{
    public GameObject show_loadtimeout;
    void OnEnable()
    {
        show_loadtimeout.SetActive(true);
    }
    private void OnDisable()
    {
        show_loadtimeout.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
