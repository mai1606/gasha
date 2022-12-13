using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[Serializable]
public class tiemboll
{
    public GameObject momTiem;
    public GameObject _itemboll;
}
public class chooseGameCasha : MonoBehaviour
{
    public GameObject[] itemChoose;
    public tiemboll[] _itemboll;
    public GameObject showReword;
    [SerializeField] private GameObject obj_success;
    [SerializeField] private GameObject obj_error;
    public GameObject step2;
    public GameObject textInputbtn;
    public int countitem =0;
    public float speed = 0.1f;
    bool checkPlayChooseCasha = true;
    bool delayPlaychooseCasha = false;
    [SerializeField] private api _api;
    [SerializeField] private Cards _Cards;

    private bool checkApiImage = false;
    private float timeold = 10f;
    private float time;
    private bool checkApi = false;
    private bool timeOut = false;
    public string priority = "0";
    public  Texture Oldimage;
    bool testapi = false;
    private void OnEnable()
    {
        time = timeold;
        checkApi = false;
        for (int i = 0; i < itemChoose.Length; i++)
        {
            itemChoose[i].SetActive(false);
        }
        checkPlayChooseCasha = true;
        delayPlaychooseCasha = false;
        textInputbtn.SetActive(false);
        staticVariable.urlIamgeReword = "";
        staticVariable.IamgeReword = null;
       
    }
    void Start()
    {
        for (int i = 0; i < _itemboll.Length; i++)
        {
            _itemboll[i]._itemboll.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f); 
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (delayPlaychooseCasha)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {

                if (checkPlayChooseCasha)
                {
                    textInputbtn.SetActive(false);
                    checkPlayChooseCasha = false;
                    soundControl.playSound("eff12");
                }

            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                testapi = true;
                if (checkPlayChooseCasha)
                {
                    textInputbtn.SetActive(false);
                    checkPlayChooseCasha = false;
                    soundControl.playSound("eff12");
                }

            }
        }
       
        if(checkApi)
        {
            if(time <= 0)
            {
                time = 0;
                timeOut = true;
                checkApi = false;
                priority = "0";
                _Cards.replaceReword(false);
               
                    Invoke("delayShowReword", 1f);
                
                
            }
            else
            {
                timeOut = false; 
                time -= Time.deltaTime;
            }
           
        }
       
        if (Input.GetKeyDown(KeyCode.H))
        {
            _itemboll[1].momTiem.transform.localScale = new Vector3(5f, 5f, 5f);
        }
    }
    public void delayOnclick()
    {
        // call form animetion
        Invoke("delayPlay", 2f);      
    }
    void delayPlay()
    {
        soundControl.playSound("eff11");
        textInputbtn.SetActive(true);
        Invoke("delayPlayLoop", 1f);
    }
    void delayPlayLoop()
    {
        delayPlaychooseCasha = true;
        SerialController._SerialController.SendSerialMessage("Z");
        StartCoroutine(lootshowItem());
        soundControl.playSound("eff10");
    }
    public void delayShowReword()
    {
       
        //delayPlaychooseCasha = false;
        checkPlayChooseCasha = true;
        showReword.SetActive(true);
        obj_success.SetActive(false);
        Debug.Log("staticVariable.statusApi " + staticVariable.statusApi);
        if (staticVariable.statusReword == 1 && staticVariable.statusApi == 1)
        {
            obj_error.SetActive(false);
            obj_success.SetActive(false);
        }
        else if(staticVariable.statusReword == 0 && staticVariable.statusApi == 1)
        {
            obj_error.SetActive(false);
            obj_success.SetActive(true);
        }
        else
        {
            obj_success.SetActive(false);
            obj_error.SetActive(true);
        }
      
        
        step2.SetActive(false);
        this.gameObject.SetActive(false);
    }
    IEnumerator lootshowItem()
    {
     
        yield return new WaitForSeconds(speed);
        for (int i = 0; i < itemChoose.Length; i++)
        {
            _itemboll[i]._itemboll.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.9f);
            itemChoose[i].SetActive(false);
            _itemboll[i]._itemboll.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
       
        if (countitem >= itemChoose.Length)
        {
            countitem = 0;
            itemChoose[countitem].SetActive(true);
            _itemboll[countitem]._itemboll.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            _itemboll[countitem]._itemboll.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        else
        {
            _itemboll[countitem]._itemboll.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            _itemboll[countitem]._itemboll.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            itemChoose[countitem].SetActive(true);
        }
        countitem++;
        if(checkPlayChooseCasha)
        {
            StartCoroutine(lootshowItem());
        }
        else
        {
            //_Cards.bonusImage();
            int win = 0;
            if(countitem == 2 || testapi)
            {
                win = 1;
                SerialController._SerialController.SendSerialMessage("A");
            }
            else
            {
                win = 0;
                SerialController._SerialController.SendSerialMessage("J");
            }
            soundControl.stopSound("eff10");
            checkApi = true;
            _api.call_function_apirandom(staticVariable.code_branch, staticVariable.typeUsers, win, _action: () => {
                
                if (checkApi = true) {
                    StartCoroutine(GetTexture(staticVariable.urlIamgeReword, _action: () => {
                                    
                        if (checkApiImage)
                        {
                            _Cards.replaceReword(true);
                          //  obj_success.SetActive(true);
                           
                            priority = _api._priority;
                            Debug.Log("sucsse");
                            if(win == 1)
                            {
                                SerialController._SerialController.SendSerialMessage("A");
                            }
                            else
                            {
                                SerialController._SerialController.SendSerialMessage("J");
                            }
                        }
                        else
                        {
                            priority = "0";
                            _Cards.replaceReword(false);
                          
                            Debug.Log("error");
                        }
                        Invoke("delayShowReword", 5f);
                        testapi = false;
                    }));
                }
            });
           
        }
       
       
    }

    IEnumerator GetTexture(string url, Action _action = null)
    {
        checkApi = false;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
            staticVariable.IamgeReword = Oldimage;
            checkApiImage = false;
            _action();
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            staticVariable.IamgeReword = myTexture;
            checkApiImage = true;
            _action();
        }
        if(timeOut == true)
        {
            _action();
        }
       
    }
}
