using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float startTime;
    [SerializeField]
    private float subTime;


    void Start()
    {
        
    }

    private IEnumerator SetTimer(){
        float time = startTime;
        WaitForSeconds seconds = new WaitForSeconds(0.1f);
        while(time > 0){
            time-=0.1f;
            yield return seconds;
        }
        
        yield break;
    }
}
