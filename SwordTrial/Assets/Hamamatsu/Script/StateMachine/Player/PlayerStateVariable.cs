/*�v���C���[�X�e�[�g�̕ϐ�*/

using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UI;

public partial class PlayerState
{
    /*�e���*/
    private static readonly PlayerStateIdle m_idle = new ();    // �ҋ@
    private static readonly PlayerStateRun m_run = new ();      // ����
    private static readonly PlayerStateDash m_dash = new ();    // �_�b�V��

    // ���݂�State
    private StateBase m_currentState = m_idle;

    /*�X�e�[�^�ϐ�*/
    [Header("�A�C�e���̌�")]
    [SerializeField] public int m_itemNum;
    [Header("���������̑��x")]
    [SerializeField] public int m_speed;
    [Header("�_�b�V����Ԃ̉����x")]
    [SerializeField] public int m_acel;
    [Header("�̗�")]
    [SerializeField] public int m_hp;


    /*�I�u�W�F�N�g�ϐ�*/
    [Header("�v���C���[�̍U������")]
    [SerializeField] private GameObject m_attack;
    [Header("�A�C�e���̌���\���e�L�X�g")]
    [SerializeField] public GameObject m_itemNumText;

    /*�t���[���ϐ�*/
    private int m_currentFrame;

    /*�ړ��ϐ�*/
    private float m_inputHorizontal;
    private float m_inputVertical;
    private Rigidbody m_rigidbody;

    /*UI*/
    [Header("HP�X���C�_�[")]
    //public SliderJoint2D m_slider;
    Text m_text;// �A�C�e���̌�

    /*�|�[�Y�p�ϐ�*/
    public bool m_isPause;

    /*�A�j���[�V����*/
    private Animator m_animator;

    private bool m_idleMotion = false;// �ҋ@
    private bool m_runMotion = false;// ����
    private bool m_attackMotion = false;// �U��
    private bool m_dashMotion = false;// �_�b�V��
    private bool m_recovery = false;// ��
    private bool m_guard = false;// �h��
}
