using UnityEngine;
using UnityEngine.UI;
public class EnemyHPUI : MonoBehaviour
{
    [SerializeField] private EnemyC _enemy;
    // ���݂�HP
    [SerializeField] private Slider _nowHP;
    // ��������HP
    [SerializeField] private Slider _decreaseHP;
    // ����HP�̃f�[�^
    private float _nowHpData = 0;
    // 1�t���[���O��HP�̃f�[�^
    private float _prevHpData = 0;
    // ��������HP�̃f�[�^
    private float _decreaseHpData = 0;
    // �A�j���[�V����(HP��������茸�炷)�t���O
    private bool _isDecreaseAnim = false;
    // �������J�n����O�Ɏ~�߂鎞��
    private int _stopTime = 0;
    // �������J�n����O�Ɏ~�߂鎞�Ԃ̍ő�l
    private int _startTimeMax = 60;

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
        _nowHpData = _enemy.m_currentHP;
        _nowHpData = _nowHP.value;
        _decreaseHpData = _decreaseHP.value;
    }
    /// <summary>
    /// �X�V����
    /// </summary>

    private void UIUpdate()
    {
        // ���݂�HP�̎擾
        _nowHpData = _enemy.m_currentHP;
        if (_nowHpData != _decreaseHpData)
        {
            // ��������
            HPDecrease();
        }
        _prevHpData = _nowHpData;

    }
    /// <summary>
    /// HP�̌�������
    /// </summary>
    private void HPDecrease()
    {
        // ���݂�HP��HP���������������HP������������
        if (_nowHpData < _prevHpData)
        {
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

    /// <summary>
    /// HP����������O�Ɏ~�܂�
    /// </summary>
    /// <returns>�w�肵�����ԑ҂������ǂ���</returns>
    private bool IsAnimStopTime()
    {
        _stopTime++;
        if (_stopTime >= _startTimeMax)
        {
            return true;
        }
        return false;
    }

}
