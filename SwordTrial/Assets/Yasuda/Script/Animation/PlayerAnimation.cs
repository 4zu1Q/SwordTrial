using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    /*変数*/
    //private string m_walk = "isWalk";
    //private string m_attackCol = "isAttack";
    //private string m_dash = "isDash";
    //private string m_gard = "isGard";
    //private string m_item = "isItem";
    //private string m_damage = "isDamage";
    //private string m_win = "isWin";
    //private string m_lose = "isLose";

    public bool m_isPause;

    //アニメーションのトリガー
    private string m_idle = "Idle";         //待機
    private string m_run = "Run";           //走る
    private string m_dash = "Dash";         //ダッシュ
    private string m_attack = "Attack";     //攻撃
    private string m_recovery = "Recovery"; //回復
    private string m_guard = "Guard";       //防御

    Animator m_anim;

    //現在のフレーム数
    private int m_currentFlameNum = 0;
    //待機状態に遷移するタイミング
    private int m_changeFlameNum = 0;

    private string m_currentAnim;

    //ゲームパッド入力値-----------------------------------

    //右スティックの入力値
    private float m_leftStickHorizontal = 0;
    private float m_leftStickVertical = 0;

    private bool m_walkStick = false;           // 移動スティック

    private bool m_dashAButton = false;         // ダッシュボタン
    private bool m_recoveryBButton = false;     // 回復ボタン
    private bool m_attackXButton = false;       // 攻撃ボタン
    private bool m_guardYButton = false;        // 防御ボタン

    //-----------------------------------------------------

    Player m_pPlayer;


    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_isPause = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isPause) return;

        GamePadInputUpdate();
        AnimTransitionUpdate();
    }

    private void FixedUpdate()
    {
        if (!m_isPause) return;

        m_currentFlameNum++;

        AnimEnd(m_currentAnim);
    }

    /// <summary>
    /// アニメーション終了時の処理
    /// </summary>
    private void AnimEnd(string anim)
    {
        if (!m_isPause) return;

        if (m_currentFlameNum == m_changeFlameNum)
        {
            m_anim.SetBool(anim, false);
        }
    }

    /// <summary>
    /// アニメーション遷移
    /// </summary>
    private void AnimTransitionUpdate()
    {
        //回復
        //if(m_pPlayer.m_itemNum > 0)
        //{
        //    if (m_recoveryBButton)
        //    {
        //        NextAnim(m_recovery, 0, 30);
        //        m_recoveryBButton = false;
        //    }
        //}

        //if (m_attackXButton)
        //{
        //    NextAnim(m_attackCol, 0, 20);
        //    m_attackXButton = false;
        //}

        if (m_recoveryBButton)
        {
            m_anim.SetBool(m_attack, false);

            NextAnim(m_recovery, 0, 30);
            m_recoveryBButton = false;
        }
        //攻撃
        else if (m_attackXButton)
        {
            m_anim.SetBool(m_recovery, false);

            NextAnim(m_attack, 0, 20);
            m_attackXButton = false;
        }

        //移動
        if (m_walkStick)
        {
            m_anim.SetBool(m_run, true);
            if (!m_dashAButton)
            {
                m_anim.SetBool(m_dash, false);
            }
            else if (m_dashAButton)
            {
                m_anim.SetBool(m_dash, true);
            }
        }
        else if (!m_walkStick)
        {
            m_anim.SetBool(m_run, false);
            m_anim.SetBool(m_dash, false);
        }
        //防御
        //if (m_guardYButton)
        //{
        //    m_anim.SetBool(m_guard, true);
        //}
        //else if (!m_guardYButton)
        //{
        //    m_anim.SetBool(m_guard, false);
        //}
    }

    /// <summary>
    /// 次に遷移するアニメーションの情報
    /// </summary>
    /// <param name="m_nextAnim">次のアニメーション</param>
    /// <param name="currentFlameNum">現在のフレーム</param>
    /// <param name="changeFlameNum">待機状態に遷移するタイミング</param>
    private void NextAnim(string m_nextAnim, int currentFlameNum, int changeFlameNum)
    {
        m_anim.SetBool(m_nextAnim, true);
        m_currentFlameNum = currentFlameNum;
        m_changeFlameNum = changeFlameNum;
        m_currentAnim = m_nextAnim;
    }

    /// <summary>
    /// コントローラーの入力情報更新
    /// </summary>
    private void GamePadInputUpdate()
    {
        //左スティックの入力情報
        m_leftStickHorizontal = Input.GetAxis("Horizontal");
        m_leftStickVertical = Input.GetAxis("Vertical");

        if(m_leftStickHorizontal != 0 || m_leftStickVertical != 0)
        {
            m_walkStick = true;
        }
        else if(m_leftStickHorizontal == 0 && m_leftStickVertical == 0)
        {
            m_walkStick = false;
        }

        // ボタンを押した瞬間
        if (Input.GetButtonDown("Abutton"))
        {
            m_dashAButton = true;
        }
        else if(Input.GetButtonDown("Bbutton"))
        {
            m_recoveryBButton = true;
        }
        else if (Input.GetButtonDown("Ybutton"))
        {
            m_guardYButton = true;
        }
        else if (Input.GetButtonDown("Xbutton"))
        {
            m_attackXButton = true;
        }

        if (Input.GetButtonUp("Abutton"))
        {
            m_dashAButton = false;
        }
        else if(Input.GetButtonUp("Ybutton"))
        {
            m_guardYButton = false;
        }
    }
}
