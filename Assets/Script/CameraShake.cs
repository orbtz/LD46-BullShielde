﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private void OnEnable()
    {
        //StartCoroutine(Shake(0.2f, 0.4f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {

        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;

        this.GetComponent<CameraShake>().enabled = false;
    }
}
