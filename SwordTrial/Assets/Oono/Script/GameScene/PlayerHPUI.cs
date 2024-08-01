using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    [SerializeField]private Player _palyer;
    // 現在のHP
    [SerializeField] private Slider _nowHP;
    // 減少するHP
    [SerializeField] private Slider _decreaseHP;
    // HPのグループ取得
    [SerializeField] private GameObject _objHP;
    [SerializeField] private Vector3 _objMovePos;
    [SerializeField] private Vector3 _objDefaultHPPos;
    // 今のHPのデータ
    private float _nowHpData = 0;
    // 1フレーム前のHPのデータ
    private float _prevHpData = 0;
    // 減少するHPのデータ
    private float _decreaseHpData = 0;
    // アニメーション(HPをゆっくり減らす)フラグ
    private bool _isDecreaseAnim = false;
    private bool _isRecoveryAnim = false;
    // 減少を開始する前に止める時間
    private int _stopTime = 0;
    // 減少を開始する前に止める時間の最大値
    private int _startTimeMax = 60;
    // 揺らす時間
    private int _swayTimer = 0;
    private int _swayTimerMax = 25;
    private bool _isSway = false;
    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        UIInit();
    }

    // Update is called once per frame
    void Update()
    {
        // 更新処理
        UIUpdate();
    }
    /// <summary>
    /// 初期化
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
    /// 更新処理
    /// </summary>

    private void UIUpdate()
    {
        // 現在のHPの取得
        if (_nowHpData < _palyer.m_hp)
        {
            _isRecoveryAnim = true;
        }
        _nowHpData = _palyer.m_hp;
        if (_nowHpData != _decreaseHpData)
        {
            // 回復処理
            HPRecovery();
            // 減少処理
            HPDecrease();
        }
        SwayHP();
        _prevHpData = _nowHpData;

    }
    /// <summary>
    /// HPの減少処理
    /// </summary>
    private void HPDecrease()
    {
        // 現在のHPとHPが違ったらゆっくりHPを減少させる
        if(_nowHpData < _prevHpData)
        {
            _nowHpData = _nowHP.value;
            _isSway = true;
            _isDecreaseAnim = true;
        }
        // フラグがたっていなかったら処理をしない
        if (!_isDecreaseAnim) { return; }
        // アニメーションをするまえに止まるかどうか
        if (!IsAnimStopTime()) { return; }
        // HPを減らす
        _decreaseHpData--;
        _decreaseHP.value = _decreaseHpData;
        // HP同じになったらアニメーションをやめる
        if (_nowHpData == _decreaseHpData)
        {
            _stopTime = 0;
            _isDecreaseAnim = false;
        }
    }
    // 現在のHPとHPが違ったら回復させる
    private void HPRecovery()
    {
        // フラグがたっていなかったら処理をしない
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
    /// HP減少させる前に止まる
    /// </summary>
    /// <returns>指定した時間待ったかどうか</returns>
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
    /// HPバーを揺らす処理
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
