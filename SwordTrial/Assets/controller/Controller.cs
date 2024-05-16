using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    //���̃X�N���v�g�Ŏg���ϐ��ꗗ
    private CharacterController m_charaCon;         //�L�����N�^�[�R���|�[�l���g�p�̕ϐ�
    private Animator            m_animeCon;         //�A�j���[�V�������邽�߂̕ϐ�
    public  float               m_moveSpeed;        //�ړ����x(public = �C���X�y�N�^�Œ����͉\)
    public  float               m_rotationSpeed;    //�v���C���[�̉�]���x(public = �C���X�y�N�^�ł͒����͉\)

    private Vector3 m_movePower = Vector3.zero;     //�L�����N�^�[�̈ړ���
    private float   m_jumpPower = 10.0f;            //�L�����N�^�[�̒�����(�g�p����Ȃ�)
    private const float m_gravityPower = 9.8f;      //�L�����N�^�[�d��(�W�����v�g�p����Ȃ�)

    public void Hit()                               //�q�b�g���̃A�j���[�V����(����͉��������ĂȂ��x�[�^�H�œ����\��ł͂���)
    { 
    }

    // Start is called before the first frame update
    //���ŏ��Ɉ�񂾂����s����sy��
    void Start()
    {
        m_charaCon = GetComponent<CharacterController>();    //�L�����N�^�[�̃R���g���[���[�̃R���|�[�l���g���Q�Ƃ���
        m_animeCon = GetComponent<Animator>();               //�A�j���[�^�[�̃R���|�[�l���g���Q�Ƃ���
        
    }

    // Update is called once per frame
    //�����t���[����Ɏ��s���鏈��
    void Update()
    {
        //�������ړ�����������
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) //�e���L�[��3D�X�e�B�b�N�̓���(GetAxis)���[���̎��̓���  �{�^����������Ă��Ȃ��Ƃ�
        {
            m_animeCon.SetBool("Run", false);                                   //Run���[�V�������s��Ȃ�
        }
        else                                                                    //�e���L�[��3D�X�e�B�b�N�̓���(GetAxis)���[���ł͂Ȃ��Ƃ��̏����@�{�^����������Ă���Ƃ�
        {
            var m_CameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;                             //�J�������Ǐ]���邽�߂̑���
            Vector3 m_direction = m_CameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizotal");    //�e���L�[��3D�X�e�B�b�N�̓���(GetAxis)�������direction�ɒl��Ԃ�
            m_animeCon.SetBool("Run", true);                                                                                                 //Run���[�V����������

            ChangeDrirection(m_direction);                                                                                                   //������Ԃ铮��̏��������s����
            Move(m_direction);                                                                                                               //�ړ����铮��̏��������s����

            //�������A�N�V��������������
            m_animeCon.SetBool("Action", Input.GetKey("x") || Input.GetButtonDown("Action1"));                                                //�L�[or�{�^������������A�N�V���������s
            m_animeCon.SetBool("Action2", Input.GetKey("z") || Input.GetButtonDown("Action2"));                                               //�L�[or�{�^������������A�N�V����2�����s
            m_animeCon.SetBool("Action3", Input.GetKey("c") || Input.GetButtonDown("Action3"));                                               //�L�[or�{�^������������A�N�V����3�����s
            m_animeCon.SetBool("Action4", Input.GetKey("space") || Input.GetButtonDown("Action4"));                                           //�L�[or�{�^������������A�N�V���������s(������)
        }
    }

    //��������ς��铮��̏���
    void ChangeDrirection(Vector3 direction)
    {
        Quaternion q = Quaternion.LookRotation(direction);                                                          //�����������s��Quaternion�^�ɒ���
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, m_rotationSpeed * Time.deltaTime);     //������q�Ɍ����ď������ω�������
    }

    //���ړ����铮��̏���
    void Move(Vector3 moveDistance)
    {
        m_charaCon.Move(moveDistance * Time.deltaTime * m_moveSpeed);   //�v���C���[�̈ړ������͎��ԁ~�ړ��X�s�[�h�̒l
    }
}
