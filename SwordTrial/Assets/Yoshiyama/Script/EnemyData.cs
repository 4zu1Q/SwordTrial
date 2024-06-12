using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]  //–¼‘O


public class EnemyData : ScriptableObject
{
    public string NAME;     //–¼‘O
    public int    MAXHP;    //HP
    public int    ATK;      //UŒ‚—Í
    public int    DEF;      //–hŒä—Í
}
