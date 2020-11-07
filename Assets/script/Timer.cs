using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int tiempoInicial;
    float tiempoActual;

    public float escalaTiempo = -1;

    public TMPro.TextMeshProUGUI timer;

    void Start()
    {
        timer.text = tiempoInicial.ToString();
        tiempoActual = tiempoInicial;
    }

    void Update()
    {
        tiempoActual = tiempoActual - Time.deltaTime;
        timer.text = tiempoActual.ToString("f3");
    }
}
