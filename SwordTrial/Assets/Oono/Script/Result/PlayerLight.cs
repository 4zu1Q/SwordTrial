using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Light m_playerLight;//プレイヤーを照らすライトの取得
    private int m_lightAngelMax = 95;//ライトの最大値
    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        m_playerLight.spotAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーを照らすライトの処理
        SpotAngeleUpdate();
    }
    /// <summary>
    /// プレイヤーを照らすライトの処理
    /// </summary>
    private void SpotAngeleUpdate()
    {
        //指定した数値より大きくなったら処理をしない
        if(m_playerLight.spotAngle > m_lightAngelMax) { return; }
        m_playerLight.spotAngle++;
    }
}
