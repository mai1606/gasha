using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callPlaySoundBytype : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] typeSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSound(int type)
    {
        soundControl.playSound(typeSound[type]);
    }
}
