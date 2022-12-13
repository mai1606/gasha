using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class textSetting
{
    public TextMeshProUGUI video;
    public TextMeshProUGUI time;
    public TextMeshProUGUI branch;
    public TextMeshProUGUI other;
    public TextMeshProUGUI scaleUp;
    public TextMeshProUGUI moveUp;

}
public class settingManager : MonoBehaviour
{
    public textSetting _text = new textSetting();
    int _defaultTimeSave = 180;
    public GameObject _dropdown;
    string videoName = "";
    string code_branch = "";
    public GameObject pupupSuccess;
    public GameObject SettingCanvas;
    public GameObject inputField;
    public static float timeSave = 0;
    public static int _COM = 3;
    public static float scaleUp = 0.00005f;
    public static float moveUp = 0.1f;
    string textDropDown;
    // Start is called before the first frame update
    void Start()
    {
        videoName = "video1";
        Cursor.visible = true;
        pupupSuccess.SetActive(false);
        timeSave = _defaultTimeSave;
        var dropdown = _dropdown.GetComponent<TMP_Dropdown>();
        dropdown.options.Clear();
        List<string> items = new List<string>();
        items.Add("select branch");
        items.Add("Korat");
        items.Add("Ngamwongwan");
        items.Add("ThaPhra");
        items.Add("Bangkapi");
        items.Add("BangKhae");
        foreach (var item in items)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }
        dropdown.onValueChanged.AddListener(delegate { DropdownItemsSelected(dropdown); });

        if (PlayerPrefs.HasKey("SaveScenes"))
        {
            videoName = PlayerPrefs.GetString("SaveScenes");
            _text.video.text = "Display : " + videoName.ToString();
        }
        if (PlayerPrefs.HasKey("Branch"))
        {
            code_branch = PlayerPrefs.GetString("Branch");        
            if (code_branch == "M10") textDropDown = "Korat";
            else if (code_branch == "M6") textDropDown = "Ngamwongwan";
            else if (code_branch == "M5") textDropDown = "ThaPhra";
            else if (code_branch == "M8") textDropDown = "Bangkapi";
            else if (code_branch == "M7") textDropDown = "BangKhae";

            _text.branch.text = "branch : " + code_branch;
            dropdown.value = dropdown.options.FindIndex(option => option.text == textDropDown);
        }
        if (PlayerPrefs.HasKey("TimeSave"))
        {
            timeSave = float.Parse(PlayerPrefs.GetString("TimeSave"));
            _text.time.text = "Time save : " + (timeSave).ToString() + " s";
        }
        if (PlayerPrefs.HasKey("COM"))
        {
            _COM = int.Parse(PlayerPrefs.GetString("COM"));
            _text.other.text = "COM"+_COM.ToString();
        }
        if (PlayerPrefs.HasKey("scaleUp"))
        {
            scaleUp = float.Parse(PlayerPrefs.GetString("scaleUp"));
            _text.scaleUp.text = "scaleUp"+scaleUp.ToString();
            inputField.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("scaleUp");
        }
        if (PlayerPrefs.HasKey("moveUp"))
        {
            moveUp = int.Parse(PlayerPrefs.GetString("moveUp"));
            _text.moveUp.text = "moveUp :"+moveUp.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("test del ");
            PlayerPrefs.DeleteAll();
        }
    }
    public void showSettingCanvas(int type)
    {
        if(type == 0)
        {
            SettingCanvas.SetActive(true);
        }
        else
        {
            SettingCanvas.SetActive(false);
        }
       
    }
    public void onClickSaveSetting()
    {
        string text = inputField.GetComponent<TMP_InputField>().text;
        PlayerPrefs.SetString("SaveScenes", videoName);
        PlayerPrefs.SetString("Branch", code_branch);
        PlayerPrefs.SetString("TimeSave", timeSave.ToString());
        PlayerPrefs.SetString("COM", _COM.ToString());
        PlayerPrefs.SetString("scaleUp", text);
        PlayerPrefs.SetString("moveUp", moveUp.ToString());
        Debug.Log("scale : "+text);
        Invoke("checkSave", 1f);
    }
    public void onClickBlackSetting()
    {
        SceneManager.LoadScene("0-SaveScenes");
    }
    public void checkSave()
    {
        if (PlayerPrefs.HasKey("SaveScenes") && PlayerPrefs.HasKey("Branch") && PlayerPrefs.HasKey("TimeSave") && PlayerPrefs.HasKey("COM"))
        {
            pupupSuccess.SetActive(true);
            Invoke("afterSaveSetting", 2f);
        }
    }
    void afterSaveSetting()
    {
        pupupSuccess.SetActive(false);
    }
    public void onClickTimeManager(int type)
    { 
        if(type == 0)
        {
            timeSave += 10;
        }
        else
        {
            timeSave -= 10;
        }
        if(timeSave < 10)
        {
            timeSave = 10;
        }
        _text.time.text = "Time save : "+(timeSave ).ToString()+" s";
    }
    public void onObj_Scale(int type)
    {
        if(type == 0 )
        {
            scaleUp += 0.0001f;
        }
        else if  (type == 1)
        {
            scaleUp -= 0.0001f;
        }
        if(scaleUp <= 0)
        {
            scaleUp = 0;
        }
     
        _text.scaleUp.text = "scaleUp : " + scaleUp.ToString();
    }
    public void onObj_Move(int type)
    {
        if (type == 0 )
        {
            moveUp += 0.1f;
        }
        else if (type == 1)
        {
            moveUp -= 0.1f;
        }
        _text.moveUp.text = "moveUp : " + moveUp.ToString();
       
    }
    public void onClickVideoManager(int type)
    {
         videoName = "video"+(type+1);
        _text.video.text = "Display : "+videoName.ToString();
    }
    public void onClickComManager(int type)
    {
        if (type == 0)
        {
            _COM += 1;
        }
        else
        {
            _COM -= 1;
        }
        if(_COM <1)
        {
            _COM = 1;
        }
        string com = "COM" + _COM;
        _text.other.text = com.ToString();
    }
    void DropdownItemsSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;
        var branch = dropdown.options[index].text;
        
        if (branch == "Korat")
        {
            code_branch = "M10";
        }
        else if (branch == "Ngamwongwan")
        {
            code_branch = "M6";
        }
        else if (branch == "ThaPhra")
        {
            code_branch = "M5";
        }
        else if (branch == "Bangkapi")
        {
            code_branch = "M8";
        }
        else if (branch == "BangKhae")
        {
            code_branch = "M7";
        }
        else
        {
            code_branch = "error";
        }

        _text.branch.text = "branch : " + code_branch;


    }
}
