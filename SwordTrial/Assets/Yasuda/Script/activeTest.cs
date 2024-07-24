using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeTest : MonoBehaviour
{
    public GameObject a;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            a.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            a.SetActive(true); 
        }
    }
}
