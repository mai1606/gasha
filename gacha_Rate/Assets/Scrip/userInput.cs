using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class typeUserBg
{
    public Sprite bgFrame;
    public Sprite bgMain;
    public Sprite bgNiche;
    public Sprite ojText;
}
public class userInput : MonoBehaviour
{
    // Start is called before the first frame update
    public GachaManager _GachaManager;
    public GameObject[] _BoxColliderTop;
    // public GameObject[] _TextPutInButton;
    public GameObject BgFrame, BgMain, bgNiche, ojtext;
    public typeUserBg[] typeUserBg;
    public GameObject turbine,yukiparticale;
    public Image cooldown;

    private const float _COROUTINE_FREQUENCY = 0.05f;
    private Vector3 _initCamPos;
    private bool _shaking;
    int typeText = 1;
    typeSound _typeSound;
    public float timechangePage = 60f;
    public float oldtimechangePage = 60f;
    void Start()
    {
        Debug.Log("staticVariable.code_branch : " + staticVariable.code_branch);
      //  Cursor.visible = false;
        for (int i = 0; i< _BoxColliderTop.Length;i++)
        {
            _BoxColliderTop[i].SetActive(false);
        }
      
        ojtext.SetActive(false);
        //_TextPutInButton[1].SetActive(false);
        yukiparticale.SetActive(true);
        staticVariable.playgame();
        Invoke("delayScenes", 3f);
        soundControl.playSound("bg");
        setImageBg(staticVariable.typeUsers);
    }
    void delayScenes()
    {
        // _TextPutInButton[staticVariable.typeUsers].SetActive(true);
        SerialController._SerialController.SendSerialMessage("S");
        staticVariable.canplayGame();
        staticVariable.changePage = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            cooldown.fillAmount = 1f;
            timechangePage = oldtimechangePage;
            if (staticVariable.cheackDelayGachaOnPlay)
            {
                if (staticVariable.cheackGachaOnPlay)
                {
                    if(PlayerPrefs.HasKey("Branch"))
                    {
                        staticVariable.code_branch = PlayerPrefs.GetString("Branch");
                    }
                    
                    staticVariable.changePage = false;
                    SerialController._SerialController.SendSerialMessage("Z");
                    for (int i = 0; i < _BoxColliderTop.Length; i++)
                    {
                        _BoxColliderTop[i].SetActive(true);
                    }
                    _GachaManager.BeforGacha();
                }
                else
                {
                    _GachaManager.DestroyOldGacha();
                 
                }
            }
     
        }
        if(staticVariable.changePage)
        {
            timechangePage -= Time.deltaTime;
            cooldown.fillAmount -= 1.0f / oldtimechangePage * Time.deltaTime;
            if (timechangePage <= 0)
            {
                SceneManager.LoadScene("0-SaveScenes");
            }
        }
        else
        {
           cooldown.fillAmount = 1f;
           timechangePage = oldtimechangePage;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Invoke("changeScene", 2f);
        }

        if (!staticVariable.cheackGachaOnPlay)
        {
            ojtext.SetActive(false);
            yukiparticale.SetActive(false);
            turbine.SetActive(false);
        }
        else
        {
            ojtext.SetActive(true);
            yukiparticale.SetActive(true);
            turbine.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            staticVariable.typeUsers = 0;
            setImageBg(staticVariable.typeUsers);
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            staticVariable.typeUsers = 1;
            setImageBg(staticVariable.typeUsers);
        }

    }
    void changeScene()
    {
        SceneManager.LoadScene("0-SaveScenes");
    }
    public void call_ShakingCamera()
    {
        //if (!_shaking)
         //   StartCoroutine(_ShakingCamera());
    }
    public void setImageBg(int type)
    {
        Debug.Log("bg type" + type);
        BgFrame.GetComponent<SpriteRenderer>().sprite = typeUserBg[type].bgFrame;
        BgMain.GetComponent<SpriteRenderer>().sprite = typeUserBg[type].bgMain;
        bgNiche.GetComponent<SpriteRenderer>().sprite = typeUserBg[type].bgNiche;
        ojtext.GetComponent<SpriteRenderer>().sprite = typeUserBg[type].ojText;

    }
    private IEnumerator _ShakingCamera(float magnitude = 0.25f)
    {
        _shaking = true;
      
        float t = 0f, x, y;
        while (t < 0.35f)
        {
            x = Random.Range(-4f, 4f) * magnitude;
            y = Random.Range(-4f, 4f) * magnitude;

          //  bgGacha.transform.position = new Vector3(x, y, _initCamPos.z);

            t += _COROUTINE_FREQUENCY;
            yield return new WaitForSeconds(_COROUTINE_FREQUENCY);
        }

      //  bgGacha.transform.position = _initCamPos;
        _shaking = false;
    }

}
