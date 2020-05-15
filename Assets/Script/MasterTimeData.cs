using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterTimeData : MonoBehaviour
{

    float FIXED_UPDATE_TIMESTEP;
    float TIME_SCALE;

    public float SLOWTIME_DURATION;
    public float SLOWTIME_SCALE;

    public bool willSlowTime;

    IEnumerator SlowTime()
    {
        TIME_SCALE = SLOWTIME_SCALE;

        Time.timeScale = TIME_SCALE;
        Time.fixedDeltaTime = TIME_SCALE * FIXED_UPDATE_TIMESTEP;

        yield return new WaitForSecondsRealtime(SLOWTIME_DURATION);

        TIME_SCALE = 1;

        Time.timeScale = TIME_SCALE;
        Time.fixedDeltaTime = TIME_SCALE * FIXED_UPDATE_TIMESTEP;

        willSlowTime = false;

    }

    private void Awake()
    {
        FIXED_UPDATE_TIMESTEP = Time.fixedDeltaTime;
        TIME_SCALE = Time.timeScale;

        willSlowTime = false;
    }

    private void Update()
    {

        if (willSlowTime)
        {
            StartCoroutine("SlowTime");
        }
    }
}
