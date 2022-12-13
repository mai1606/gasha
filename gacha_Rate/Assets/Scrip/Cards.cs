using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cards : MonoBehaviour
{
    public cardInfo card;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private GameObject logoReward;
    [SerializeField] private GameObject IamgeCard;
    [SerializeField] private GameObject bgReword;
    [SerializeField] private GameObject eff1,eff2;
    [SerializeField] private GameObject effBg;
    [SerializeField] private float _delayPlayGame;
    [SerializeField] private Sprite imageBus;
    [SerializeField] private int number_image;
    [SerializeField] private chooseGameCasha _chooseGameCasha;
    [SerializeField] private GameObject error_api;
    public GameObject[] _effballshow;
    // Start is called before the first frame update
    private void OnEnable()
    {
        bgReword.SetActive(false);
        effBg.SetActive(false);
     


        Invoke("delayPlayGame", _delayPlayGame);
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void delayPlayGame()
    {
        Debug.Log("playAgain");
        staticVariable.cheackDelayGachaOnPlay = true;
        if(_chooseGameCasha.priority == "1")
           staticVariable.changePage = false;
        else
           staticVariable.changePage = true;
    }   
    public void replaceReword(bool apiSucsse)
    {
        if (card != null)
        {
            var aspectObj = logoReward.GetComponent<AspectRatioFitter>();
            float aspect_float = (float)staticVariable.IamgeReword.width / (float)staticVariable.IamgeReword.height;
            aspectObj.aspectRatio = aspect_float;
           

            if (_chooseGameCasha.countitem == 2 )
            {
                _effballshow[8].SetActive(true);
                IamgeCard.GetComponent<SpriteRenderer>().sprite = imageBus;
            }
            else
            {
                _effballshow[card.number - 1].SetActive(true);
                IamgeCard.GetComponent<SpriteRenderer>().sprite = card.IamgeCard;
            }

        }
        if(apiSucsse)
        {
            logoReward.GetComponent<RawImage>().texture = staticVariable.IamgeReword;
        }
        else
        {
            logoReward.GetComponent<RawImage>().texture = staticVariable.IamgeReword;
        }
        if (staticVariable.reword != "")
        {
            name.text = staticVariable.reword;
        }
        else
        {
           
            name.text = staticVariable.oldreword;
        }
        if (staticVariable.statusApi == 0 )
        {
            Debug.Log("staticVariable.statusApi " + staticVariable.statusApi);
            error_api.SetActive(true);
        }
        else
        {
            error_api.SetActive(false);
        }
        
    }
    public void showBgReword()
    {
        bgReword.SetActive(true);
        eff1.SetActive(true);
        eff2.SetActive(true);
        Invoke("showeffBg", 1f);
    }
    public void showeffBg()
    {
      
        effBg.SetActive(true);
    }
}
