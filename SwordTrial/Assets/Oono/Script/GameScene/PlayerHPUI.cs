using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField]private Player _palyer;
    // ���݂�HP
    [SerializeField] private Slider _nowHP;
    // ��������HP
    [SerializeField] private Slider _decreaseHP;
    // HP�̃O���[�v�擾
    [SerializeField] private GameObject _objHP;
    [SerializeField] private Vector3 _objMovePos;
    [SerializeField] private Vector3 _objDefaultHPPos;
    // ����HP�̃f�[�^
    private float _nowHpData = 0;
    // 1�t���[���O��HP�̃f�[�^
    private float _prevHpData = 0;
    // ��������HP�̃f�[�^
    private float _decreaseHpData = 0;
    // �A�j���[�V����(HP��������茸�炷)�t���O
    private bool _isDecreaseAnim = false;
    private bool _isRecoveryAnim = false;
    // �������J�n����O�Ɏ~�߂鎞��
    private int _stopTime = 0;
    // �������J�n����O�Ɏ~�߂鎞�Ԃ̍ő�l
    private int _startTimeMax = 60;
    // �h�炷����
    private int _swayTimer = 0;
    private int _swayTimerMax = 25;
    private bool _isSway = false;
    // Start is called before the first frame update
    void Start()
    {
        // ������
        UIInit();
    }

    // Update is called once per frame
    void Update()
    {
        // �X�V����
        UIUpdate();
    }
    /// <summary>
    /// ������
    /// </summary>
    private void UIInit()
    {
        _nowHpData = _palyer.m_hp;
        _nowHpData = _nowHP.value;
        _decreaseHpData = _decreaseHP.value;
        _objMovePos = _objHP.transform.position;
        _objDefaultHPPos = _objMovePos;
        _swayTimer = _swayTimerMax;
    }
    /// <summary>
    /// �X�V����
    /// </summary>

    private void UIUpdate()
    {
        // ���݂�HP�̎擾
        if (_nowHpData < _palyer.m_hp)
        {
            _isRecoveryAnim = true;
        }
        _nowHpData = _palyer.m_hp;
        if (_nowHpData != _decreaseHpData)
        {
            // �񕜏���
            HPRecovery();
            // ��������
            HPDecrease();
        }
        SwayHP();
        _prevHpData = _nowHpData;

    }
    /// <summary>
    /// HP�̌�������
    /// </summary>
    private void HPDecrease()
    {
        // ���݂�HP��HP���������������HP������������
        if(_nowHpData < _prevHpData)
        {
            _nowHpData = _nowHP.value;
            _isSway = true;
            _isDecreaseAnim = true;
        }
        // �t���O�������Ă��Ȃ������珈�������Ȃ�
        if (!_isDecreaseAnim) { return; }
        // �A�j���[�V����������܂��Ɏ~�܂邩�ǂ���
        if (!IsAnimStopTime()) { return; }
        // HP�����炷
        _decreaseHpData--;
        _decreaseHP.value = _decreaseHpData;
        // HP�����ɂȂ�����A�j���[�V��������߂�
        if (_nowHpData == _decreaseHpData)
        {
            _stopTime = 0;
            _isDecreaseAnim = false;
        }
    }
    // ���݂�HP��HP���������񕜂�����
    private void HPRecovery()
    {
        // �t���O�������Ă��Ȃ������珈�������Ȃ�
        if (!_isRecoveryAnim) { return; }
        _nowHP.value++;
        if (_nowHP.value == _nowHpData)
        {
            _nowHP.value = _nowHpData;
            _decreaseHP.value = _nowHpData;
            _decreaseHpData = _nowHpData;
            _isRecoveryAnim = false;
        }

    }
    /// <summary>
    /// HP����������O�Ɏ~�܂�
    /// </summary>
    /// <returns>�w�肵�����ԑ҂������ǂ���</returns>
    private bool IsAnimStopTime()
    {
        _stopTime++;
        if(_stopTime >= _startTimeMax)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// HP�o�[��h�炷����
    /// </summary>
    private void SwayHP()
    {
        if (!_isSway) { return; }
        _swayTimer--;
        if (0 < _swayTimer)
        {
            var posX = _objDefaultHPPos.x + Random.Range(-_swayTimer, _swayTimer);
            var posY = _objDefaultHPPos.y + Random.Range(-_swayTimer, _swayTimer);
            _objMovePos = new Vector3(posX, posY, _objDefaultHPPos.y);
            _objHP.transform.position = _objMovePos;
        }
        else
        {
            _swayTimer = _swayTimerMax;
            _isSway = false;
            _objHP.transform.position = _objDefaultHPPos;
        }
    }
}
