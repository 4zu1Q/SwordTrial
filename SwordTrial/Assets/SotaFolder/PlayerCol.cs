using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCol : MonoBehaviour
{
    private Renderer m_rend;
    private Color m_colorHit = Color.cyan;
    private GameObject m_target;
    public Vector3 m_direction;                 // �����x�N�g��
    public float m_radius = 0.5f;
    ColBase m_refTarget;

    // Start is called before the first frame update
    void Start()
    {
        m_rend = GetComponent<Renderer>();
        m_target = GameObject.Find("Boss");

    }

    // Update is called once per frame
    void Update()
    {
        //�v�Z�p�̕ϐ�
        float s, t;

        //�^�[�Q�b�g�Ǝ����̑��΃x�N�g���̍쐬
        Vector3 deltaPosV3 = m_refTarget.transform.position - transform.position;

        //
        Vector4 deltaPosV4 = new Vector4(deltaPosV3.x, deltaPosV3.y, deltaPosV3.z, 0.0f);

        Vector3 normalV3 = Vector3.Cross(m_refTarget.m_direction, deltaPosV3);

        bool isParallel = false;

        /*�v�Z1*/
        //�@���x�N�g���̑傫���������菬�����ƁA���s���
        if (normalV3.sqrMagnitude < 0.001f) isParallel = true;
        //���s���A�����łȂ����̌v�Z
        if (!isParallel) //���s����Ȃ�
        {
            //1.�����̒����ɐ����A�������̒����ƌ���钼�������߂�

            /*�v�Z�p�̍s��̍쐬*/
            //4*4�̒P�ʍs��̍쐬
            Matrix4x4 matSolve = Matrix4x4.identity;
            //��P�ʂŐ��l�����Ă���
            //1��ڂɕ����x�N�g��
            matSolve.SetColumn(0, new Vector4(deltaPosV3.x, deltaPosV3.y, deltaPosV3.z, 0.0f));
            //2��ڂɃ^�[�Q�b�g�̕����x�N�g���𔽓]����������
            matSolve.SetColumn(1, new Vector4(-m_refTarget.m_direction.x, -m_refTarget.m_direction.y, -m_refTarget.m_direction.z, 0.0f));
            //3��ڂɌ݂��̖@���x�N�g��(�܂�O�ρj
            matSolve.SetColumn(2, new Vector4(normalV3.x, normalV3.y, normalV3.z, 0.0f));
            //�Ō�ɋt�s��ɂ���
            matSolve = matSolve.inverse;

            /*�s��̌v�Z*/
            //���ȏ��Q�l(p128)
            //�p���[���[�^s���o��
            s = Vector4.Dot(matSolve.GetRow(0), deltaPosV4);
            //�p���[���[�^t���o��
            t = Vector4.Dot(matSolve.GetRow(1), deltaPosV4);
        }
        else //���s
        {
            s = Vector3.Dot(m_direction, deltaPosV3) / Vector3.SqrMagnitude(m_direction);
            t = Vector3.Dot(m_refTarget.m_direction, -deltaPosV3) / Vector3.SqrMagnitude(m_refTarget.m_direction);
        }

        /*�r����������*/
        if (s < -1.0f) s = -1.0f;                    // s�̉���
        if (s > 1.0f) s = 1.0f;                    // s�̏��
        if (t < -1.0f) t = -1.0f;                    // t�̉���
        if (t > 1.0f) t = 1.0f;                    // t�̏��

        /*���l�̍쐬*/
        //�T�C�Y�������ꂽ�����̕����x�N�g���Ǝ����̍��W�̑��΃x�N�g��(���Z)���o���B
        Vector3 v3MinPos1 = m_direction * s + transform.position;
        //�T�C�Y�������ꂽ�^�[�Q�b�g�̕����x�N�g���Ǝ����̍��W�̑��΃x�N�g��(���Z)���o���B
        Vector3 v3MinPos2 = m_refTarget.m_direction * t + m_refTarget.transform.position;
        //��L�̑��΃x�N�g���̃}�O�j�`���[�h
        float fDistSqr = Vector3.SqrMagnitude(v3MinPos1 - v3MinPos2);
        //�����ƃ^�[�Q�b�g�̔��a�̍��v
        float ar = m_refTarget.m_radius + m_radius;

        /*�v�Z*/
        //���΃x�N�g���Ɣ��a�̍��v�̔�r(�}�O�j�`���[�h�̂܂܌v�Z���邽�߂�ar^2)
        if (fDistSqr < ar * ar) //���a�̍��v��菬������
        {
            if (!isParallel)
            {
                m_rend.material.color = m_colorHit;
            }
            else
            {
            }
        }
        else //���a�̍��v���傫����
        {
            if (!isParallel)
            {
            }
            else
            {
            }
        }

    }
}
