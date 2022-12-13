using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Networking;
using Unity.VisualScripting;

public class GachaManager : MonoBehaviour
{
    [SerializeField] private GachaRate[] gacha,gachaSCBM;
    [SerializeField] private Transform parent,parent2, pos, pos2;
    [SerializeField] private GameObject CharacterCardGo;
    [SerializeField] private GameObject bgPos2;
    [SerializeField] private GameObject CharacterGacha, CharacterdownReword, CharacterdownReword2, CharacterGachaStep2;
    [SerializeField] private moveGacha _moveGacha;
    [SerializeField] private Image bgTypeuser;
    [SerializeField] private Image bgTypeuserBack;
    [SerializeField] private GameObject boxGasha;
    [SerializeField] private GameObject stepShowGasha1, stepShowReword;
    [SerializeField] private GameObject[] effballshow;
    [SerializeField] private api _api;
   
    public GameObject animNiche;
    public Sprite[] typeUser;
    public Sprite[] typeUserBG_back;
    //public GachaRate[] gacha;
    GameObject objCard;
    GameObject objGacha, objGachaStep2;
    Cards card;
    Gacha _Gacha, _GachaStep2, _GacharadownReword, _GacharadownReword2;
    cardInfo _cardInfo;
    public soundControl _soundControl;
    float timeGasha;
    public int[] log_Reward = new int[6];
    public bool checkApiImage = false;
    
    public void Start()
    {
      
        bgTypeuser.sprite = typeUser[staticVariable.typeUsers];
        bgTypeuserBack.sprite = typeUserBG_back[staticVariable.typeUsers];
        timeGasha = 3.7f;
   
        if(boxGasha != null)
        {
            boxGasha.SetActive(false);
        }
        objCard = CharacterCardGo;
        card = objCard.GetComponent<Cards>();    
        objGacha = CharacterGacha;
        _Gacha = CharacterGacha.GetComponent<Gacha>();
        _GachaStep2 = CharacterGachaStep2.GetComponent<Gacha>();
        _GacharadownReword = CharacterdownReword.GetComponent<Gacha>();
        _GacharadownReword2 = CharacterdownReword2.GetComponent<Gacha>();

    }
    public void BeforGacha()
    {

     
        if (staticVariable.cheackGachaOnPlay)
        {
          
            staticVariable.cheackStopMoveGacha = false;
            staticVariable.playgame();
            _moveGacha.setyukiInstan();
            _moveGacha.jumpBollOnclickGacha();

            
            
            Invoke("callInstantiateGacha", timeGasha);
            _soundControl.playSoundloop();
            staticVariable.speedAnim = 20; 
        }
        
    }
    void callInstantiateGacha()
    {
        SerialController._SerialController.SendSerialMessage("S");
        afterCallApirandown();
       /* if (staticVariable.checkApi == true)
                     
        else
            StartCoroutine(checkApiagain());*/
       
        
      
       
    }
    void afterCallApirandown()
    {
       
        staticVariable.cheackStopMoveGacha = true;
        soundControl.stopSound("eff10");
        soundControl.playSound("eff3");
        Invoke("callanimNiche", 1f);
        Invoke("delayBoxGasha", 3f);
    }
    public IEnumerator checkApiagain()
    {
        yield return new WaitForSeconds(1f);
        if (staticVariable.checkApi == true && staticVariable.countErrorApi <5)
        {
            afterCallApirandown();
        }
        else if (staticVariable.checkApi == true && staticVariable.countErrorApi > 5)
        {
          
            staticVariable.NetworkError = true;
            afterCallApirandown();
        }
        else
        {
            staticVariable.countErrorApi += 1;
            StartCoroutine(checkApiagain());
        }
       // _effect[9].Play();
    }
    void callanimNiche()
    {
        animNiche.SetActive(true);
    }
    void delayBoxGasha()
    {
        
        if (boxGasha != null)
        {
            boxGasha.SetActive(true);
        }
      
        Invoke("Gacha", 2f);
    }
    //public IEnumerator Gacha()
    public void Gacha()
    {
        // yield return new WaitForSeconds(2f);
     
        animNiche.SetActive(false);
        staticVariable.speedAnim = 1;
        if (objCard != null)
        {
          
            //objCard = CharacterCardGo; //Instantiate(CharacterCardGo, pos2.position, Quaternion.identity) as GameObject;
            //objCard.transform.SetParent(parent);
            // objCard.transform.localScale = new Vector3(1, 1, 1);
            // objCard.transform.position = new Vector3(CharacterCardGo.transform.position.x, CharacterCardGo.transform.position.y, 1);

            //objCard.SetActive(false);
            // bgPos2.SetActive(false);
            // objGacha = CharacterGacha;//Instantiate(CharacterGacha, pos.position, Quaternion.identity) as GameObject;
            // objGacha.transform.SetParent(parent);
            //objGacha.transform.localScale = new Vector3(1, 1, 1);


            int rnd = UnityEngine.Random.Range(1, 101);
            if(staticVariable.typeUsers == 1)
            {
                
                for (int i = 0; i < gachaSCBM.Length; i++)
                {
                    if (rnd <= gachaSCBM[i].rate)
                    {
                        _cardInfo = Reward(gachaSCBM[i].rarity);
                        card.card = _cardInfo;
    
                        _Gacha.cards = _cardInfo;
                        _GachaStep2.cards = _cardInfo;
                        _GacharadownReword.cards = _cardInfo;
                        _GacharadownReword2.cards = _cardInfo;

                       // effballshow[_cardInfo.number - 1].SetActive(true);
                        Invoke("showReward", 1f);
                        return;
                    }
                }
            }
            else
            {
               
                for (int i = 0; i < gacha.Length; i++)
                {
                    if (rnd <= gacha[i].rate)
                    {
                        _cardInfo = Reward(gacha[i].rarity);
                        card.card = _cardInfo;
                        _Gacha.cards = _cardInfo;
                        _GachaStep2.cards = _cardInfo;
                        _GacharadownReword.cards = _cardInfo;
                        _GacharadownReword2.cards = _cardInfo;
                        //effballshow[_cardInfo.number - 1].SetActive(true);
                        Invoke("showReward", 1f);
                        return;
                    }
                }
            }
            
           
        }
        else
        {
            
        }
    }
    public void InvokeEffOpenCard()
    {
      
        Invoke("showReward", 4f);
    }
    void showReward()
    {
        if (boxGasha != null)
        {
            boxGasha.SetActive(false);
        }
      
        stepShowGasha1.SetActive(true);
        objCard.SetActive(true);
        //Invoke("delayPlayGame", _delayPlayGame);
    }
   
    public void DestroyOldGacha()
    {
        SerialController._SerialController.SendSerialMessage("S");
        for (int i = 0; i< effballshow.Length; i++)
        {
            effballshow[i].SetActive(false);
        }
        soundControl.stopSound("eff9");
        objCard.SetActive(false);
        stepShowReword.SetActive(false);
        staticVariable.cheackGachaOnPlay = true;
        staticVariable.ResetVal();
    }
    void Auto_Gacha()
    {
        Gacha();
    }
    public int Rates(R rarity)
    {
        GachaRate gr = Array.Find(gacha, rt => rt._rarity == rarity);
        if(gr!=null)
        {
            return gr.rate;
        }else
        {
            return 0;
        }
    }
    cardInfo Reward(String rarity)
    {
        GachaRate gr;
        cardInfo[] reward;
        if (staticVariable.typeUsers == 1)
        {
             gr = Array.Find(gachaSCBM, rt => rt.rarity == rarity);
            reward = gr.reward;
        }
        else
        {
             gr = Array.Find(gacha, rt => rt.rarity == rarity);
            reward = gr.reward;
        }
       
        if(gr.rarity == "rating1")
            log_Reward[0]++;
        else if (gr.rarity == "rating2")
            log_Reward[1]++;
        else if (gr.rarity == "rating3")
            log_Reward[2]++;
        else if (gr.rarity == "rating4")
            log_Reward[3]++;
        else if (gr.rarity == "rating5")
            log_Reward[4]++;
        else if (gr.rarity == "rating6")
            log_Reward[5]++;
     
        int rnd = UnityEngine.Random.Range(0, reward.Length);    
        return reward[rnd];
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            bgTypeuser.sprite = typeUser[0];
            bgTypeuserBack.sprite = typeUserBG_back[0];
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            bgTypeuser.sprite = typeUser[1];
            bgTypeuserBack.sprite = typeUserBG_back[1];
        }
    }
}
/*[CustomEditor(typeof(GachaManager))]

public class GachaEditor: Editor
{
    [SerializeField]
    public int rating1, rating2, rating3, rating4, rating5, rating6;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        GachaManager gm = (GachaManager)target;
        rating6 = EditorGUILayout.IntField("rating6", (gm.Rates(R.rating6) - gm.Rates(R.rating5)));
        rating5 = EditorGUILayout.IntField("rating5", (gm.Rates(R.rating5) - gm.Rates(R.rating4)));
        rating4 = EditorGUILayout.IntField("rating4", (gm.Rates(R.rating4) - gm.Rates(R.rating3)));
        rating3 = EditorGUILayout.IntField("rating3", (gm.Rates(R.rating3) - gm.Rates(R.rating2)));
        rating2 = EditorGUILayout.IntField("rating2", (gm.Rates(R.rating2) - gm.Rates(R.rating1)));
        rating1 = EditorGUILayout.IntField("rating1", (gm.Rates(R.rating1)));
    }
}*/