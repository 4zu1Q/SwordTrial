//敵の通常攻撃

using UnityEngine;

public class EnemyNormalAttack : MonoBehaviour
{
    //攻撃判定の大きさ
    private Vector3 m_collisionSize = new Vector3(3.0f,3.0f,3.0f);

    //経過時間
    private int m_currentFlame = 0;
    //通常攻撃の最大時間
    public readonly int m_maxFlame = 300;


    /// <summary>
    /// 通常攻撃の更新処理
    /// </summary>
    /// <param name="AttackCollision">攻撃判定のオブジェクト</param>
    public void UpdateNormalAttack(GameObject AttackCollision, GameObject AttackCollisionPrefab, Vector3 Position)
    {
        FlameAdd();
        AttackColInstantiate(ref AttackCollision, AttackCollisionPrefab, Position);
        AttackColSize(AttackCollision);
        DestroyInstantiate(AttackCollision);

    }

    /// <summary>
    /// インスタンス生成する
    /// </summary>
    /// <param name="Position">生成する座標</param>
    private void AttackColInstantiate(ref GameObject AttackCollision, GameObject AttackCollisionPrefab, Vector3 Position)
    {
        if(m_currentFlame == 100)
        {
            AttackCollision = Instantiate(AttackCollisionPrefab,
                Position,
                Quaternion.identity);
        }
    }

    /// <summary>
    /// インスタンス生成したものを削除
    /// </summary>
    /// <param name="AttackCollision"></param>
    /// <param name=""></param>
    private void DestroyInstantiate(GameObject AttackCollision)
    {
        if(m_currentFlame == 200)
        {
            Destroy(AttackCollision);
        }
    }

    /// <summary>
    /// 攻撃の当たり判定の大きさ
    /// </summary>
    /// <param name="AttackCollision">攻撃判定のオブジェクト</param>
    private void AttackColSize(GameObject AttackCollision)
    {
        AttackCollision.transform.localScale = m_collisionSize;
    }

    /// <summary>
    /// 攻撃中の経過時間計測
    /// </summary>
    private void FlameAdd()
    {
        m_currentFlame++;
    }



}