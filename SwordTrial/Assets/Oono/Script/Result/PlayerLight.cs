using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private Light m_playerLight;//�v���C���[���Ƃ炷���C�g�̎擾
    private int m_lightAngelMax = 95;//���C�g�̍ő�l
    // Start is called before the first frame update
    void Start()
    {
        // ������
        m_playerLight.spotAngle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[���Ƃ炷���C�g�̏���
        SpotAngeleUpdate();
    }
    /// <summary>
    /// �v���C���[���Ƃ炷���C�g�̏���
    /// </summary>
    private void SpotAngeleUpdate()
    {
        //�w�肵�����l���傫���Ȃ����珈�������Ȃ�
        if(m_playerLight.spotAngle > m_lightAngelMax) { return; }
        m_playerLight.spotAngle++;
    }
}
