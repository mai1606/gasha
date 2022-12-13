using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingCavas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    public GameObject showStatus;
    public GameObject pupupShowSave;
    float _localScale = 0.9f;
    float posx = 0;
    float posy = 0;
    public static bool changeModeSettingcanvas = false;
    private void OnEnable()
    {
       
    }
    void Start()
    {
        if (SaveSystem.HasKey("canvasPosition") && SaveSystem.HasKey("canvasScale"))
        {
            canvas.GetComponent<RectTransform>().anchoredPosition = SaveSystem.GetVector3("canvasPosition");
            canvas.transform.localScale = SaveSystem.GetVector3("canvasScale");
           
            //Debug.Log("hasKey");
        }
        changeModeSettingcanvas = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1))
        {
            changeModeSettingcanvas = true;
            showStatus.SetActive(true);
        }
        if (changeModeSettingcanvas)
        {
            if (Input.GetKey(KeyCode.U))
            {
                _localScale = canvas.transform.localScale.x+settingManager.scaleUp;
                canvas.transform.localScale = new Vector3(_localScale, _localScale, _localScale);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _localScale = canvas.transform.localScale.x - settingManager.scaleUp;
                canvas.transform.localScale = new Vector3(_localScale, _localScale, _localScale);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                posx = canvas.GetComponent<RectTransform>().anchoredPosition.x;
                posy = canvas.GetComponent<RectTransform>().anchoredPosition.y + settingManager.moveUp;
                canvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
              //  posy -= settingManager.moveUp;
                posx = canvas.GetComponent<RectTransform>().anchoredPosition.x ;
                posy = canvas.GetComponent<RectTransform>().anchoredPosition.y - settingManager.moveUp;
                canvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                posx = canvas.GetComponent<RectTransform>().anchoredPosition.x + settingManager.moveUp;
                posy = canvas.GetComponent<RectTransform>().anchoredPosition.y;
                canvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                posx = canvas.GetComponent<RectTransform>().anchoredPosition.x-settingManager.moveUp;
                posy = canvas.GetComponent<RectTransform>().anchoredPosition.y;
                canvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posy);
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                SaveCanvas();
            }
        }
    }
    public void SaveCanvas()
    {
        SaveSystem.SetVector3("canvasPosition", canvas.GetComponent<RectTransform>().anchoredPosition);
        //Debug.Log("aaa" + canvas.GetComponent<RectTransform>().anchoredPosition);
        SaveSystem.SetVector3("canvasScale", canvas.transform.localScale);
        changeModeSettingcanvas = false;
        showStatus.SetActive(false);
        Invoke("checkSave", 1f);
    }
    public void checkSave()
    {
        if(SaveSystem.HasKey("canvasPosition")&& SaveSystem.HasKey("canvasScale"))
        {
            pupupShowSave.SetActive(true);
            Invoke("afterSaveSetting", 1f);
        }
    }
    void afterSaveSetting()
    {
        pupupShowSave.SetActive(false);
    }


}
