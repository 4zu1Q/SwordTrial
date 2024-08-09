using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public Material _skybox;
    private float _rotationRepeatValue = 0.0f ;
    public float _addRotation = 0.2f ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rotationRepeatValue += _addRotation;
        if(_rotationRepeatValue > 360.0f)
        {
            _rotationRepeatValue = 0.0f;
        }
        _skybox.SetFloat("_Rotation", _rotationRepeatValue);

    }
}
