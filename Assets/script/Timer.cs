using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int tiempoInicial;
    float tiempoActual;

    public float escalaTiempo = -1;

    public TMPro.TextMeshProUGUI timer;

    public GameObject seTerminoElTiempo;

    void Start()
    {
        timer.text = tiempoInicial.ToString();
        tiempoActual = tiempoInicial;
        Time.timeScale = 1f;
    }

    void Update()
    {
        CuentaRegresiva();
    }

    void CuentaRegresiva()
    {
        if (tiempoActual > 0)
        {

            tiempoActual = tiempoActual - Time.deltaTime;
            timer.text = tiempoActual.ToString("f3");

        }
        else
        {
            timer.text = "00.000";
            SeAcaboElTiempo();
        }
        
    }

    void SeAcaboElTiempo()
    {
        seTerminoElTiempo.SetActive(true);
        Time.timeScale = (seTerminoElTiempo) ? 0 : 1f;
    }

    public float puntajeActual()
    {
        return tiempoInicial - tiempoActual;
    }

    public float GetMaxScrore()
    {
        return PlayerPrefs.GetFloat("Mejor Tiempo", 0);
    }

    public void SaveScore()
    {
        if (puntajeActual() < GetMaxScrore())
        {
            PlayerPrefs.SetFloat("Mejor Tiempo", puntajeActual());
        }
    }
}  
