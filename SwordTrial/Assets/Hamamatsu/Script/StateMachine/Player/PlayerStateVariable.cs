/*プレイヤーステートの変数*/

using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.UI;

public partial class PlayerState
{
    /*各状態*/
    private static readonly PlayerStateIdle m_idle = new ();    // 待機
    private static readonly PlayerStateRun m_run = new ();      // 走る
    private static readonly PlayerStateDash m_dash = new ();    // ダッシュ

    // 現在のState
    private StateBase m_currentState = m_idle;

    /*ステータ変数*/
    [Header("アイテムの個数")]
    [SerializeField] public int m_itemNum;
    [Header("歩いた時の速度")]
    [SerializeField] public int m_speed;
    [Header("ダッシュ状態の加速度")]
    [SerializeField] public int m_acel;
    [Header("体力")]
    [SerializeField] public int m_hp;


    /*オブジェクト変数*/
    [Header("プレイヤーの攻撃判定")]
    [SerializeField] private GameObject m_attack;
    [Header("アイテムの個数を表すテキスト")]
    [SerializeField] public GameObject m_itemNumText;

    /*フレーム変数*/
    private int m_currentFrame;

    /*移動変数*/
    private float m_inputHorizontal;
    private float m_inputVertical;
    private Rigidbody m_rigidbody;

    /*UI*/
    [Header("HPスライダー")]
    //public SliderJoint2D m_slider;
    Text m_text;// アイテムの個数

    /*ポーズ用変数*/
    public bool m_isPause;

    /*アニメーション*/
    private Animator m_animator;

    private bool m_idleMotion = false;// 待機
    private bool m_runMotion = false;// 走る
    private bool m_attackMotion = false;// 攻撃
    private bool m_dashMotion = false;// ダッシュ
    private bool m_recovery = false;// 回復
    private bool m_guard = false;// 防御
}
