using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class CamerawithTashiro : MonoBehaviour
{

    /* �萔 */

    private const float kDistance = 5.2f;   // �^�[�Q�b�g�ƃJ�����Ƃ̋���

    private const float kShiftPosY = 1.2f;   // �^�[�Q�b�g���S�����ɂ��炷��

    private const float kAxisMinThershold = 0.2f; // ���͏��̍ŏ��̂������l:�������銄��

    private const float kAxisMaxThershold = 0.8f; // ���͏��̍ő�̂������l:1.0�Ƃ݂Ȃ�����

    private const float kRotLimitUpdownSwing = 30.0f * Mathf.Deg2Rad;   // �㉺�̉�]����

    private const float kRotSpeedLeftright = 0.4f * Mathf.Deg2Rad;  // ���E�̉�]�X�s�[�h(���W�A��)

    private const float kRotSpeedUpdown = 0.25f * Mathf.Deg2Rad;  // �㉺�̉�]�X�s�[�h(���W�A��)

    // FIXME: ���O���������ɕύX

    private float kRangeCursorDot = Mathf.Cos(10 * Mathf.Deg2Rad);   // �J�[�\�����Ƃ�����ς͈̔�

    private const float kCursorLimitDistance = 30.0f;

    private const float kCursorLimitSqrDistance = kCursorLimitDistance * kCursorLimitDistance;

    /* �ϐ� */

    private GameObject _target;         // �^�[�Q�b�g�̃I�u�W�F�N�g���

    private Transform _targetTrs;       // �^�[�Q�b�g��Transform���

    private Vector3 _centerPos;         // ���S���W

    private float _rotLeftrightSwing;   // ���E�̃J�����̉�]��

    private float _rotUpdownSwing;      // �㉺�̃J�����̉�]��

    private bool _isUpdownSwing;        // �㉺�ɃJ������h�炵�Ă��邩

    private bool _isLeftrightSwing;     // ���E�ɓ��͂�����

    private bool _isUpdownInput;        // �㉺�ɓ��͂�����

    private bool _isReset;              // ���Z�b�g������

    // FIXME: �Ȃ񂩂��������̕ϐ����ɕύX

    private List<GameObject> _cursorObjs;    // �J�[�\���Ƃ����I�u�W�F�N�g�̏�񂽂�

    private GameObject _hpBarObj;            // HP�o�[�̑ΏۂƂȂ�I�u�W�F�N�g

    private GameObject _hpBar;               // HP�o�[���̂̃I�u�W�F�N�g

    private void Start()

    {

        // �^�[�Q�b�g(�v���C���[)������擾

        _target = GameObject.Find("Player");

        _targetTrs = _target.transform;

        /* �����ݒ� */

        // ���S���W

        _centerPos = _targetTrs.position;

        // ��]�ʖ�����

        _rotLeftrightSwing = 0.0f;

        _rotUpdownSwing = 0.0f;

        // ��]���Ă��Ȃ���

        _isUpdownSwing = false;

        _isLeftrightSwing = false;

        // ���͂��Ă��Ȃ���

        _isUpdownInput = false;

        // ���Z�b�g���Ă��Ȃ���

        _isReset = false;

    }

    private void Update()

    {

        RotLeftright();

        RotUpdown();

        ResetDirection();

    }

    private void FixedUpdate()

    {

        ReturnRotUpdown();

        Move();

        //Cursor();

    }

    /// <summary>

    /// �J�����̐��ʕ������擾(Y���͖���)

    /// </summary>

    /// <returns>���ʕ���</returns>

    public Vector3 GetForward()

    {

        return transform.forward;

    }

    /// <summary>

    /// ���E�̉�]

    /// </summary>

    private void RotLeftright()

    {

        // ���͒l�̎擾 

        float inputRate = Input.GetAxis("Horizontal2");

        // ���͂���Ă��Ȃ��Ȃ�I��

        if (-kAxisMinThershold < inputRate && inputRate < kAxisMinThershold)

        {

            _isLeftrightSwing = false;

            return;

        }

        inputRate = LimitValue(inputRate, kAxisMinThershold, kAxisMaxThershold);

        // ���

        _rotLeftrightSwing += inputRate * kRotSpeedLeftright;

        // ���͂��Ă��邱�Ƃ�

        _isLeftrightSwing = true;

    }

    /// <summary>

    /// �㉺�̉�]

    /// </summary>

    private void RotUpdown()

    {

        // ���͒l�̎擾

        float inputRate = Input.GetAxis("Vertical2");

        // ���͂���Ă��Ȃ��Ȃ�I��

        if (-kAxisMinThershold < inputRate && inputRate < kAxisMinThershold)

        {

            _isUpdownInput = false;

            return;

        }

        inputRate = LimitValue(inputRate, kAxisMinThershold, kAxisMaxThershold);

        // �㉺�̉�]�n�ɑ��

        _rotUpdownSwing += inputRate * kRotSpeedUpdown;

        // ��]�̐���

        _rotUpdownSwing = Mathf.Max(Mathf.Min(_rotUpdownSwing, kRotLimitUpdownSwing), -kRotLimitUpdownSwing);

        // �������Ă��邱�Ƃ�

        _isUpdownSwing = true;

        // ���͂������Ƃ�

        _isUpdownInput = true;

    }

    /// <summary>

    /// �����Ă���������v���C���[�̌����Ă�������ɖ߂�

    /// </summary>

    private void ResetDirection()

    {

        // MEMO:�{�^���ԈႦ�Ă���\������

        // Y�{�^���������ƕ������Z�b�g

        if (Input.GetButtonDown("Ybutton"))

        {

            // TODO:����Leftright�̉�]��0�ɂ��Ă��邾���Ȃ̂Ńv���C���[�̌����Ă�������������悤��

            _rotLeftrightSwing = 0.0f;

            _rotUpdownSwing = 0.0f;

            _isLeftrightSwing = false;

            _isUpdownSwing = false;

            _isReset = true;

        }

    }

    /// <summary>

    /// �㉺�����̉�]�ʂ����ɖ߂�

    /// </summary>

    private void ReturnRotUpdown()

    {

        // �㉺�����̓��͂����Ă���Ζ߂��Ȃ�

        if (_isUpdownInput) return;

        // 0�ɋ߂Â���

        _rotUpdownSwing = Mathf.Lerp(_rotUpdownSwing, 0.0f, 0.05f);

        // ����Ȃ�0�ɋ߂Â�����߂������Ƃɂ���

        if (-0.001f < _rotUpdownSwing && _rotUpdownSwing < 0.001f)

        {

            _rotUpdownSwing = 0.0f;

            _isUpdownSwing = false;

        }

    }

    /// <summary>

    /// �ʒu�̍X�V

    /// </summary>

    private void Move()

    {

        // ���S���X�V���邩

        bool isUpdateCenter = (_centerPos != _targetTrs.position);

        // ���Z�b�g���ĂȂ����ǂ����X�V���Ȃ���ΕύX�����Ȃ�

        if (!_isReset && !_isLeftrightSwing && !_isUpdownSwing && !isUpdateCenter) return;

        // ���S�ʒu�̍X�V

        if (isUpdateCenter)

        {

            _centerPos = Vector3.Lerp(_centerPos, _targetTrs.position, 0.5f);

            // ����Ȃ�0�ɋ߂Â���������d�Ȃ��Ă��邱�Ƃ�

            if ((_centerPos - _targetTrs.position).sqrMagnitude < 0.001f)

            {

                _centerPos = _targetTrs.position;

            }

        }

        Vector3 pos = _centerPos;

        // ���E�̉�]��

        float sinLeftright = Mathf.Sin(_rotLeftrightSwing);

        float cosLeftright = Mathf.Cos(_rotLeftrightSwing);

        // �㉺��]�̂�or���E+�㉺��]

        if (_isUpdownSwing)

        {

            // �㉺�̉�]��

            float sinUpdown = Mathf.Sin(_rotUpdownSwing);

            float cosUpdown = Mathf.Cos(_rotUpdownSwing);

            // ��]�����ʒu�̓K�p

            pos.x += sinLeftright * (kDistance * cosUpdown);

            pos.y += kShiftPosY + kDistance * sinUpdown * -1.0f;

            pos.z += cosLeftright * (kDistance * cosUpdown) * -1.0f;

        }

        // ���E��]�̂�

        else

        {

            // ��]�����ʒu�̓K�p

            pos.x += sinLeftright * kDistance;

            pos.y += kShiftPosY;

            pos.z += cosLeftright * kDistance * -1.0f;

        }

        // �ʒu�̑�� 

        transform.position = pos;

        // ���Z�b�g�܂��͉�]���Ă���Ε����̍X�V

        if (_isReset || _isLeftrightSwing || _isUpdownSwing)

        {

            // �I�u�W�F�N�g�̌����ύX

            Vector3 lookPos = _centerPos;

            lookPos.y += kShiftPosY;

            transform.LookAt(lookPos);

        }

        // ���Z�b�g���Ă��Ȃ���

        _isReset = false;

    }


    // FIXME: ���������̕ϐ�����

    /// <summary>

    /// ��ԋ߂��ɂ��鐳�ʂɂ���I�u�W�F�N�g��HP����\������

    /// </summary>

    //private void Cursor()

    //{

    //    float nowSqrDist = 0.0f;

    //    foreach (var item in _cursorObjs)

    //    {

    //        // ���̃I�u�W�F�N�g���j��or���S���Ă���Ύ���

    //        // TODO: �֐��쐬

    //        if (!IsExist(item)) continue;

    //        // ���g����I�u�W�F�N�g�܂ł̃x�N�g���𐶐�

    //        Vector3 cameraToitemVec = item.transform.position - transform.position;

    //        // �������������ꂷ���Ă����玟��

    //        float sqrDist = cameraToitemVec.sqrMagnitude;

    //        if (sqrDist > kCursorLimitSqrDistance) continue;

    //        // ���K��

    //        cameraToitemVec.Normalize();

    //        // ����

    //        float dot = Vector3.Dot(cameraToitemVec, transform.forward);

    //        // �ݒ�͈͓����̔���

    //        if (dot > kRangeCursorDot)

    //        {

    //            // 1��ڂ̃q�b�g

    //            if (!drawingObj)

    //            {

    //                // ���̂܂ܑ��

    //                drawingObj = item;

    //                nowSqrDist = sqrDist;

    //            }

    //            // 2��ڈȍ~�̃q�b�g

    //            else

    //            {

    //                // ���݂̋�����菬�����Ȃ���

    //                if (sqrDist < nowSqrDist)

    //                {

    //                    drawingObj = item;

    //                    nowSqrDist = sqrDist;

    //                }

    //            }

    //        }

    //    }

    //    // �N�ɂ��q�b�g���Ȃ�������I��

    //    if (!drawingObj)

    //    {

    //        // ����HP�o�[��`�悵�Ă���Ώ���

    //        if (_hpBar)

    //        {

    //            Destroy(_hpBar);

    //            // ���������Ă��Ȃ��Ƃ���

    //            _hpBarObj = null;

    //            _hpBar = null;

    //        }

    //        return;

    //    }

 

    //}

    //private bool IsExist(GameObject item)

    //{

    //    bool isExist = true;

    //    return isExist;

    //}

   

    /// <summary>

    /// �l�𐧌�����֐�

    /// </summary>

    /// <param name="val">�����������l</param>

    /// <param name="min">�ŏ��l</param>

    /// <param name="max">�ő�l</param>

    /// <returns>���������l</returns>

    private float LimitValue(float val, float min, float max)

    {

        if (val > 0.0f)

        {

            // ���̏ꍇ

            val = (val - min) / (max - min);

            val = Mathf.Min(1.0f, Mathf.Max(0.0f, val));

        }

        else

        {

            // ���̏ꍇ

            val = (val + min) / (max - min);

            val = Mathf.Min(0.0f, Mathf.Max(-1.0f, val));

        }

        return val;

    }

}

