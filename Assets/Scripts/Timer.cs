using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float time;
    public bool isCountdown;
    public TextMeshProUGUI timerText;
    public UnityAction finishCountDown;

    private void OnDestroy()
    {
        instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCountdown && time>=0)
        {
            time -= Time.deltaTime;
            if(time<0)
            {
                finishCountDown();
            }
        }
        else
        {
            time += Time.deltaTime;
        }

       // Debug.Log($"{time:00.00}");
    }
}
