﻿using UnityEngine;

public class Shaker : MonoBehaviour
{
    public Camera mainCam;

    float shakeAmount = 0;

    void Awake()
    {
        if (mainCam == null)
            mainCam = Camera.main;
    }

    public void Shake(float amount, float length)
    {
        shakeAmount = amount;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}