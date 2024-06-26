//�G�̒ʏ�U��

using UnityEngine;

public class EnemyNormalAttack : MonoBehaviour
{
    //�U������̑傫��
    private Vector3 m_collisionSize = new Vector3(3.0f,3.0f,3.0f);

    //�o�ߎ���
    private int m_currentFlame = 0;
    //�ʏ�U���̍ő厞��
    public readonly int m_maxFlame = 300;


    /// <summary>
    /// �ʏ�U���̍X�V����
    /// </summary>
    /// <param name="AttackCollision">�U������̃I�u�W�F�N�g</param>
    public void UpdateNormalAttack(GameObject AttackCollision, GameObject AttackCollisionPrefab, Vector3 Position)
    {
        FlameAdd();
        AttackColInstantiate(ref AttackCollision, AttackCollisionPrefab, Position);
        AttackColSize(AttackCollision);
        DestroyInstantiate(AttackCollision);

    }

    /// <summary>
    /// �C���X�^���X��������
    /// </summary>
    /// <param name="Position">����������W</param>
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
    /// �C���X�^���X�����������̂��폜
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
    /// �U���̓����蔻��̑傫��
    /// </summary>
    /// <param name="AttackCollision">�U������̃I�u�W�F�N�g</param>
    private void AttackColSize(GameObject AttackCollision)
    {
        AttackCollision.transform.localScale = m_collisionSize;
    }

    /// <summary>
    /// �U�����̌o�ߎ��Ԍv��
    /// </summary>
    private void FlameAdd()
    {
        m_currentFlame++;
    }



}