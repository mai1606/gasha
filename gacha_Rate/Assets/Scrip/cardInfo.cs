using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new card",menuName = "Character")]
public class cardInfo : ScriptableObject
{
    public string name;
    public Sprite oldimage;
    public Sprite logoReward;
    public Sprite IamgeCard;
    public int number;
}
