using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class showSettingGame 
{
    public TextMeshProUGUI SaveScenes;
    public TextMeshProUGUI Branch;
    public TextMeshProUGUI TimeSave;
    public TextMeshProUGUI COM;
}

public class SaveSceneControl : MonoBehaviour
{
    //public video_control _videoControl;
    string urlConfig = "";
    public GameObject mainPage;
    public GameObject videoPage;
    public GameObject popupSCBM, loading, DebogSaveDataSuccess, showSetting;
    public videoControl _videoControl;
    public showSettingGame _showSettingGame;
    public string[] sceneName;
    public AudioSource bgSound;
    //public static bool ScbmMember = false;
    float timer;
    private bool checkChangeScenne = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Invoke("invokeSeaddatatoarduno", 5f);
        staticVariable.typeUsers = 0;
        staticVariable.cheackStopMoveGacha = true;
        staticVariable.ResetVal();
        staticVariable.playgame();
        bgSound.Play();
        timer = staticVariable.timeSave;
        loading.SetActive(false);
        checkChangeScenne = false;
        if (
            PlayerPrefs.HasKey("SaveScenes") &&
            PlayerPrefs.HasKey("Branch") &&
            PlayerPrefs.HasKey("TimeSave") &&
            PlayerPrefs.HasKey("COM")
          )
        {
            staticVariable.videoName = PlayerPrefs.GetString("SaveScenes");
            staticVariable.code_branch = PlayerPrefs.GetString("Branch");
            timer = float.Parse(PlayerPrefs.GetString("TimeSave"));
            staticVariable.COM = PlayerPrefs.GetString("COM");

            _showSettingGame.SaveScenes.text = "video name :" + PlayerPrefs.GetString("SaveScenes");
            _showSettingGame.Branch.text = "Branch :" + staticVariable.code_branch;
            _showSettingGame.TimeSave.text = "time :" + timer / 60 + "s";
            _showSettingGame.COM.text = "COM :" + PlayerPrefs.GetString("COM");

            DebogSaveDataSuccess.SetActive(false);
            showSetting.SetActive(false);
            checkChangeScenne = false;
            if (PlayerPrefs.GetString("SaveScenes") == "" || PlayerPrefs.GetString("Branch") == "")
            {
                StartCoroutine(startSettingPage());
            }
        }
        else
        {
            showSetting.SetActive(true);
            StartCoroutine(startSettingPage());
            DebogSaveDataSuccess.SetActive(true);
            checkChangeScenne = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("time"+ timer);
        if (Input.GetKeyUp(KeyCode.I) || timer < 0)
        {

            if (videoPage.activeSelf == true)
            {
                _videoControl.playVideo();
                timer = 0;
                bgSound.Stop();
            }
            else
            {
                videoPage.SetActive(true);

            }



        } else if (Input.GetKeyUp(KeyCode.P) || timer > 0)
        {
            timer -= Time.deltaTime;
            if (_videoControl != null)
            {
                _videoControl.stopVideo();
            }

            videoPage.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.A) && !checkChangeScenne)
        {
            checkChangeScenne = true;
            staticVariable.typeUsers = 0;
            StartCoroutine(playGacha());
        }
        if (Input.GetKeyUp(KeyCode.B) && !checkChangeScenne)
        {
            checkChangeScenne = true;
            staticVariable.typeUsers = 1;
            StartCoroutine(startSCBM());
        }
        if (Input.GetKeyUp(KeyCode.O) && !checkChangeScenne)
        {
            StartCoroutine(startSettingPage());
        }
        if (Input.GetKeyUp(KeyCode.I) && !checkChangeScenne)
        {
            if (showSetting.activeSelf)
            {
                showSetting.SetActive(false);
            }
            else
            {
                showSetting.SetActive(true);
            }

        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            // SerialController.
            //_SerialController.se
            SerialController._SerialController.SendSerialMessage("S");
            //SerialController._SerialController.SendSerialMessage("A");

        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SerialController._SerialController.SendSerialMessage("Z");

        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SerialController._SerialController.SendSerialMessage("A");

        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            SerialController._SerialController.SendSerialMessage("J");

        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            SerialController._SerialController.SendSerialMessage("T");

        }
    }
    public void invokeSeaddatatoarduno()
    {
         SerialController._SerialController.SendSerialMessage("S");
    }
    IEnumerator playGacha()
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName[0]);
        loading.SetActive(false);
    }
     IEnumerator startSCBM()
    {
        loading.SetActive(true);
        popupSCBM.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName[0]);
        loading.SetActive(false);
    }
    IEnumerator startSettingPage()
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName[1]);
        loading.SetActive(false);
    }
}
