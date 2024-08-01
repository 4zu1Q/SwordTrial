using UnityEngine;
using UnityEngine.UI;
public class EnemyHPUI : MonoBehaviour
{
    [SerializeField] private EnemyC _enemy;
    // 現在のHP
    [SerializeField] private Slider _nowHP;
    // 減少するHP
    [SerializeField] private Slider _decreaseHP;
    // 今のHPのデータ
    private float _nowHpData = 0;
    // 1フレーム前のHPのデータ
    private float _prevHpData = 0;
    // 減少するHPのデータ
    private float _decreaseHpData = 0;
    // アニメーション(HPをゆっくり減らす)フラグ
    private bool _isDecreaseAnim = false;
    // 減少を開始する前に止める時間
    private int _stopTime = 0;
    // 減少を開始する前に止める時間の最大値
    private int _startTimeMax = 60;

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
        _nowHpData = _enemy.m_currentHP;
        _nowHpData = _nowHP.value;
        _decreaseHpData = _decreaseHP.value;
    }
    /// <summary>
    /// 更新処理
    /// </summary>

    private void UIUpdate()
    {
        // 現在のHPの取得
        _nowHpData = _enemy.m_currentHP;
        if (_nowHpData != _decreaseHpData)
        {
            // 減少処理
            HPDecrease();
        }
        _prevHpData = _nowHpData;

    }
    /// <summary>
    /// HPの減少処理
    /// </summary>
    private void HPDecrease()
    {
        // 現在のHPとHPが違ったらゆっくりHPを減少させる
        if (_nowHpData < _prevHpData)
        {
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

    /// <summary>
    /// HP減少させる前に止まる
    /// </summary>
    /// <returns>指定した時間待ったかどうか</returns>
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
