using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCol : MonoBehaviour
{
    private Renderer m_rend;
    private Color m_colorHit = Color.cyan;
    private GameObject m_target;
    public Vector3 m_direction;                 // 方向ベクトル
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
        //計算用の変数
        float s, t;

        //ターゲットと自分の相対ベクトルの作成
        Vector3 deltaPosV3 = m_refTarget.transform.position - transform.position;

        //
        Vector4 deltaPosV4 = new Vector4(deltaPosV3.x, deltaPosV3.y, deltaPosV3.z, 0.0f);

        Vector3 normalV3 = Vector3.Cross(m_refTarget.m_direction, deltaPosV3);

        bool isParallel = false;

        /*計算1*/
        //法線ベクトルの大きさがある一定小さいと、平行状態
        if (normalV3.sqrMagnitude < 0.001f) isParallel = true;
        //平行か、そうでないかの計算
        if (!isParallel) //平行じゃない
        {
            //1.両方の直線に垂直、かつ両方の直線と交わる直線を求める

            /*計算用の行列の作成*/
            //4*4の単位行列の作成
            Matrix4x4 matSolve = Matrix4x4.identity;
            //列単位で数値を入れている
            //1列目に方向ベクトル
            matSolve.SetColumn(0, new Vector4(deltaPosV3.x, deltaPosV3.y, deltaPosV3.z, 0.0f));
            //2列目にターゲットの方向ベクトルを反転させたもの
            matSolve.SetColumn(1, new Vector4(-m_refTarget.m_direction.x, -m_refTarget.m_direction.y, -m_refTarget.m_direction.z, 0.0f));
            //3列目に互いの法線ベクトル(つまり外積）
            matSolve.SetColumn(2, new Vector4(normalV3.x, normalV3.y, normalV3.z, 0.0f));
            //最後に逆行列にする
            matSolve = matSolve.inverse;

            /*行列の計算*/
            //教科書参考(p128)
            //パラーメータsを出す
            s = Vector4.Dot(matSolve.GetRow(0), deltaPosV4);
            //パラーメータtを出す
            t = Vector4.Dot(matSolve.GetRow(1), deltaPosV4);
        }
        else //平行
        {
            s = Vector3.Dot(m_direction, deltaPosV3) / Vector3.SqrMagnitude(m_direction);
            t = Vector3.Dot(m_refTarget.m_direction, -deltaPosV3) / Vector3.SqrMagnitude(m_refTarget.m_direction);
        }

        /*排他条件処理*/
        if (s < -1.0f) s = -1.0f;                    // sの下限
        if (s > 1.0f) s = 1.0f;                    // sの上限
        if (t < -1.0f) t = -1.0f;                    // tの下限
        if (t > 1.0f) t = 1.0f;                    // tの上限

        /*数値の作成*/
        //サイズ調整された自分の方向ベクトルと自分の座標の相対ベクトル(加算)を出す。
        Vector3 v3MinPos1 = m_direction * s + transform.position;
        //サイズ調整されたターゲットの方向ベクトルと自分の座標の相対ベクトル(加算)を出す。
        Vector3 v3MinPos2 = m_refTarget.m_direction * t + m_refTarget.transform.position;
        //上記の相対ベクトルのマグニチュード
        float fDistSqr = Vector3.SqrMagnitude(v3MinPos1 - v3MinPos2);
        //自分とターゲットの半径の合計
        float ar = m_refTarget.m_radius + m_radius;

        /*計算*/
        //相対ベクトルと半径の合計の比較(マグニチュードのまま計算するためにar^2)
        if (fDistSqr < ar * ar) //半径の合計より小さい時
        {
            if (!isParallel)
            {
                m_rend.material.color = m_colorHit;
            }
            else
            {
            }
        }
        else //半径の合計より大きい時
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
