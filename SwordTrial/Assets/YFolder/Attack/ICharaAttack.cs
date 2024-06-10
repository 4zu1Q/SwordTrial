using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface ICharaAttack
{
    public int m_hitCount();
    public int m_hitCountDown();
    public int m_attackTimeKanshi();
}
