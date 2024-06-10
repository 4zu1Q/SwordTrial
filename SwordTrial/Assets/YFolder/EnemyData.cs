using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]  //���O


public class EnemyData : ScriptableObject
{
    public string NAME;     //���O
    public int    MAXHP;    //HP
    public int    ATK;      //�U����
    public int    DEF;      //�h���
}
