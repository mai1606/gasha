using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using TMPro;
using UnityEngine.UI;


/*public class Datum
{
    public string status;
    public string title;
    public string text;
    public string code;
}

public class Root
{
    public List<Datum> data;
}*/
[Serializable]
public class Award
{
    public string award_date_id;
    public string award_id;
    public string event_time_id;
    public string amount;
    public string log;
    public string priority;
    public string branch_id;
    public string award_name;
    public string award_code;
    public string award_department;
    public string image;
    public string award_stock;
}
[Serializable]
public class AwardList
{
    public string award_date_id;
    public string award_id;
    public string event_time_id;
    public string amount;
    public string log;
    public string priority;
    public string branch_id;
    public string award_name;
    public string award_code;
    public string award_department;
    public string image;
    public string award_stock;
}
[Serializable]
public class Root
{
    public string status;
    public string title;
    public string text;
    public string date;
    public string time;
    public int priority;
    public int random_keys;
    public Award award;
    public List<AwardList> award_list;
}
[Serializable]
public class checktime
{
    public string status;
    public string title;
    public string datetime;
    public int setting;
}
public class api : MonoBehaviour
{
    // Start is called before the first frame update
    private const string URL_get_randow = "https://themall-jumbojoy.nabla.co.th/service/random";
    private const string URL_get_check_time = "https://themall-jumbojoy.nabla.co.th/service/check_status";
    public GameObject _loading;
    public GameObject status_api_color;
    bool checkApicountdown = false;
    [SerializeField] public Root random;
    [SerializeField] public checktime timeapi;
    float time_Network = 10;
    string _branch_code = "";
    int _type = 0;
    Action a_Action;
    public string _priority = "0";
    int _score = 0;
    // private float timeold = 30f;
    [SerializeField] private float time;
    void Start()
    {
        time = staticVariable.timeStatusApi;
        check_status();

    }
    void check_status()
    {
        checkApicountdown = false;
        call_function_check_time(
           _action: (a) =>
           {
               if (a)
               {
                   staticVariable.timeStatusApi = timeapi.setting;
                   time = staticVariable.timeStatusApi;
                   checkApicountdown = true;
                   status_api_color.GetComponent<SpriteRenderer>().color = new Color32(0, 190, 2, 255);
               }
               else
               {
                   Invoke("check_status", 1f);
                   status_api_color.GetComponent<SpriteRenderer>().color = new Color32(250, 0, 0, 255);
               }

           }
       );
        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkApicountdown)
        {
            if(time <= 0)
            {
                //Debug.Log("testt call api "+time);
                check_status();
            }
            else
            {
                time -= Time.deltaTime;
            }
           
        }
        if (staticVariable.cheackDelayGachaOnPlay || staticVariable.cheackGachaOnPlay)
        {
            status_api_color.SetActive(true);
        }
        else
        {
            status_api_color.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            random = new Root();
        }
    }
    public void call_function_check_time(string branch_code = "M7", int type = 1, Action<bool> _action = null)
    {
        time_Network = 10;
      
        StartCoroutine(check_time(URL_get_check_time, branch_code, type, _action));
    }
    public void call_function_apirandom(string branch_code = "M7", int type = 1, int priority = 0, int score = 2000, Action _action = null)
    {
        
        time_Network = 10;
        _loading.SetActive(false);
        Debug.Log(branch_code + " " + type + " " + priority + " " + score);
        StartCoroutine(api_random(URL_get_randow, branch_code, type, priority, score, _action));
    }
    private IEnumerator api_random(string uri, string branch_code = "M7", int type = 1, int priority = 0, int score = 2000, Action _action = null)
    {
        WWWForm form = new WWWForm();
        form.AddField("branch_code", branch_code);
        form.AddField("type", (type+1));
        form.AddField("result", (priority ));

        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {

            yield return request.SendWebRequest();
            random = new Root();
            if (request.isNetworkError)
            {
                Debug.Log("Error");
              
            }
            else
            {
                
                Debug.Log("request.downloadHandler.text"+ request.downloadHandler.text);
                random = JsonUtility.FromJson<Root>(request.downloadHandler.text);
                if (random.status == "success")
                {
                    staticVariable.reword = random.award.award_name;
                    staticVariable.urlIamgeReword = random.award.image;
                    _priority = random.award.priority;
                    staticVariable.statusReword = 1;
                }
                else
                {
                    staticVariable.statusReword = 0;
                    staticVariable.reword = random.title + " " + random.text;
                  
                }
               
            }
            _action();
        }
    }
    private IEnumerator check_time(string url, string branch_code = "M7", int type = 1, Action<bool> _action = null)
    {
       
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {

            yield return request.SendWebRequest();
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
                staticVariable.statusApi = 0;
                _action(false);

            }
            else
            {
                staticVariable.statusApi = 1;
                timeapi = JsonUtility.FromJson<checktime>(request.downloadHandler.text);
                _action(true);
               // Debug.Log(request.downloadHandler.text);
            }
           

        }
    }
}
