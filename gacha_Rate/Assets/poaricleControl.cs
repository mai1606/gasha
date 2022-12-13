using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poaricleControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("callDestroy", 1f);
    }

    // Update is called once per frame
    private void callDestroy()
    {
        Destroy(this.gameObject);
    }
}
