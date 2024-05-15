using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{



    void Update()
    {
                
    }

    private void EndGame()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            UnityEditor.EditorApplication.isPlaying = false; //ÉQÅ[ÉÄèIóπ
        }
    }


}
