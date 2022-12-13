using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playanimtimeUpdown : MonoBehaviour
{
    public  Animator m_Animator;
    private void OnEnable()
    {
        m_Animator.SetBool("play", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
