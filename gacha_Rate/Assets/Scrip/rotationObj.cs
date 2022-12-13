using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationObj : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public int  _types = 0;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(_types == 0)
        {
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }
        else
        {
            transform.Rotate(0, 0, -(Time.deltaTime * speed), Space.Self);
        }
       
    }
}
