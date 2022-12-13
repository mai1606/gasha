using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum typeGacha { rating1, rating2, rating3, rating4, rating5, rating6 }
[System.Serializable]
public class createGachaRate
{
    public typeGacha _rarity;
    public Sprite _image;
    public int amount;
    public int amount__layer;
}
public class moveGacha : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _GachaBoll, _GachaBoll2, _GachaBoll3;
    public createGachaRate[] _Gacha, _GachaSCBM;
    public Sprite _Gacha_image;
    public GameObject yuki;
    //Gacha _GachaInstant;
    public Transform posYuki, posYuki2, posYuki3;
    public GameObject[] yukiInstan = new GameObject[30];
    public GameObject[,] _Gacha2darray = new GameObject[10,50];
    public GameObject Particle;
    public float jump;
    public int amount;
    public int amount__layer;
    controlForceUp _controlForceUp;
    void Start()
    {
        if (staticVariable.typeUsers == 1)
        {
            for (int i = 0; i < _GachaSCBM.Length; i++)
            {
                for (int j = 0; j < amount; j++)
                {
                    int posx = UnityEngine.Random.Range(-700, 700);
                    int posY = UnityEngine.Random.Range(450, 900);

                    _Gacha2darray[i, j] = Instantiate(_GachaBoll, posYuki.position, Quaternion.identity);
                    _Gacha2darray[i, j].transform.SetParent(posYuki);
                    _Gacha2darray[i, j].transform.localScale = new Vector3(80, 80, 80);
                    _Gacha2darray[i, j].GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posY);
                    _Gacha2darray[i, j].GetComponent<SpriteRenderer>().sprite = _GachaSCBM[i]._image;         
                }
            }
            for (int i = 0; i < _GachaSCBM.Length; i++)
            {
                for (int j = 0; j < amount__layer; j++)
                {
                    int posx = UnityEngine.Random.Range(-700, 700);
                    int posY = UnityEngine.Random.Range(450, 900);

                    _Gacha2darray[i, j] = Instantiate(_GachaBoll2, posYuki2.position, Quaternion.identity);
                    _Gacha2darray[i, j].transform.SetParent(posYuki2);
                    _Gacha2darray[i, j].transform.localScale = new Vector3(75, 75, 75);
                    _Gacha2darray[i, j].GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posY);
                    _Gacha2darray[i, j].GetComponent<SpriteRenderer>().sprite = _GachaSCBM[i]._image;
                }
            }
            for (int i = 0; i < _GachaSCBM.Length; i++)
            {
                for (int j = 0; j < amount__layer; j++)
                {
                    int posx = UnityEngine.Random.Range(-700, 700);
                    int posY = UnityEngine.Random.Range(450, 900);

                    _Gacha2darray[i, j] = Instantiate(_GachaBoll3, posYuki3.position, Quaternion.identity);
                    _Gacha2darray[i, j].transform.SetParent(posYuki3);
                    _Gacha2darray[i, j].transform.localScale = new Vector3(67, 67, 67);
                    _Gacha2darray[i, j].GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posY);
                    _Gacha2darray[i, j].GetComponent<SpriteRenderer>().sprite = _GachaSCBM[i]._image;
                }
            }
        }
        else
        {
            for (int i = 0; i < _Gacha.Length; i++)
            {
                for (int j = 0; j < amount; j++)
                {
                    int posx = UnityEngine.Random.Range(-700, 700);
                    int posY = UnityEngine.Random.Range(450, 900);

                    _Gacha2darray[i, j] = Instantiate(_GachaBoll, posYuki.position, Quaternion.identity);
                    _Gacha2darray[i, j].transform.SetParent(posYuki);
                    _Gacha2darray[i, j].transform.localScale = new Vector3(80, 80, 80);
                    _Gacha2darray[i, j].GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posY);
                    _Gacha2darray[i, j].GetComponent<SpriteRenderer>().sprite = _Gacha[i]._image;
                }
            }
            for (int i = 0; i < _Gacha.Length; i++)
            {
                for (int j = 0; j < amount__layer; j++)
                {
                    int posx = UnityEngine.Random.Range(-700, 700);
                    int posY = UnityEngine.Random.Range(450, 900);

                    _Gacha2darray[i, j] = Instantiate(_GachaBoll2, posYuki2.position, Quaternion.identity);
                    _Gacha2darray[i, j].transform.SetParent(posYuki2);
                    _Gacha2darray[i, j].transform.localScale = new Vector3(75, 75, 75);
                    _Gacha2darray[i, j].GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posY);
                    _Gacha2darray[i, j].GetComponent<SpriteRenderer>().sprite = _Gacha[i]._image;
                }
            }

            for (int i = 0; i < _Gacha.Length; i++)
            {
                for (int j = 0; j < amount__layer; j++)
                {
                    int posx = UnityEngine.Random.Range(-700, 700);
                    int posY = UnityEngine.Random.Range(450, 900);

                    _Gacha2darray[i, j] = Instantiate(_GachaBoll3, posYuki3.position, Quaternion.identity);
                    _Gacha2darray[i, j].transform.SetParent(posYuki3);
                    _Gacha2darray[i, j].transform.localScale = new Vector3(70, 70, 70);
                    _Gacha2darray[i, j].GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posY);
                    _Gacha2darray[i, j].GetComponent<SpriteRenderer>().sprite = _Gacha[i]._image;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setyukiInstan()
    {
        for (int yukiI = 0; yukiI < yukiInstan.Length; yukiI++)
        {
            int posx = UnityEngine.Random.Range(-700, 700);
           // Debug.Log("Posx" + yukiInstan.Length);
            yukiInstan[yukiI] = Instantiate(yuki, posYuki.position, Quaternion.identity);
            yukiInstan[yukiI].transform.SetParent(posYuki);
            yukiInstan[yukiI].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            yukiInstan[yukiI].GetComponent<RectTransform>().anchoredPosition = new Vector2(posx, posYuki.position.y);
        }
        Invoke("DetyukiInstan", 5f);
    }
    public void DetyukiInstan()
    {
        for (int yukiI = 0; yukiI < yukiInstan.Length; yukiI++)
        {
            GameObject a = Instantiate(Particle, yukiInstan[yukiI].transform.position, Quaternion.identity);
            a.transform.SetParent(posYuki);
            a.transform.localScale = new Vector3(1, 1, 1);
            Destroy(yukiInstan[yukiI]);
        }
     }
    public void jumpBollOnclickGacha()
    {
        if (staticVariable.typeUsers == 1)
        {
            for (int i = 0; i < _GachaSCBM.Length; i++)
            {
                for (int j = 0; j < amount__layer; j++)
                {

                    Rigidbody2D m_Rigidbody = _Gacha2darray[i, j].GetComponent<Rigidbody2D>();
                    m_Rigidbody.AddForce(transform.up);
                }
            }
        }
        else
        {
            for (int i = 0; i < _Gacha.Length; i++)
            {
                for (int j = 0; j < amount__layer; j++)
                {

                    Rigidbody2D m_Rigidbody = _Gacha2darray[i, j].GetComponent<Rigidbody2D>();
                    m_Rigidbody.AddForce(transform.up);
                }
            }
        }
      
    }
}
