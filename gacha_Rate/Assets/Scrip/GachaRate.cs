using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum R { rating1, rating2, rating3, rating4, rating5, rating6 }
[System.Serializable]
public class GachaRate 
{
    public string rarity;
    public R _rarity;
    [Range(1,100)]
    public int rate;
    public cardInfo[] reward;
}
