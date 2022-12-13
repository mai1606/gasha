﻿using UnityEngine;
using System.Collections;

public class SaveSystemSetup : MonoBehaviour {

	[SerializeField] private string fileName = "Profile.bin"; // file to save with the specified resolution
    [SerializeField] private bool dontDestroyOnLoad; // the object will move from one scene to another (you only need to add it once)
    public static SaveSystemSetup _SaveSystemSetup;
    void Awake()
	{
		SaveSystem.Initialize(fileName);
        //if(dontDestroyOnLoad) DontDestroyOnLoad(transform.gameObject);
       
         if (_SaveSystemSetup == null)
         {
             _SaveSystemSetup = this;
             DontDestroyOnLoad(gameObject);
             Debug.Log("test ......... 1");
         }
         else
         {
             Destroy(gameObject);
             Debug.Log("test ......... 2");
         }
    }

    // if the object is present in all game scenes, auto save before exiting
    // on some platforms there may not be an exit function, see the Unity help
    void OnApplicationQuit()
	{
		SaveSystem.SaveToDisk();
	}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
