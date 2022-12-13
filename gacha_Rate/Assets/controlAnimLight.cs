using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlAnimLight : MonoBehaviour
{
    Animator m_Animator;
    float oldSpeed;
    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (staticVariable.speedAnim == oldSpeed)
        {

        }
        else
        {
            oldSpeed = staticVariable.speedAnim;
            m_Animator.SetFloat("speedup", oldSpeed);

        }
        
    }
}
