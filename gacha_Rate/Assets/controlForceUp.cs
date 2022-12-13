using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlForceUp : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public PhysicsMaterial2D[] _Material;
    public float m_Thrust = 20f;
    public float m_Thrust2 = 20f;
    bool a = false;
    public int id = 0;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        id = Random.Range(1, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (!staticVariable.cheackStopMoveGacha)
        {
            // m_Rigidbody.AddForce(transform.up * m_Thrust);   
            m_Rigidbody.gravityScale = 5 * Mathf.Sin(Time.time * 5f+ id);
            m_Rigidbody.sharedMaterial = _Material[0];
        }
        else
        {
            m_Rigidbody.gravityScale = 1;
            m_Rigidbody.sharedMaterial = _Material[1];
        }
    }
}
