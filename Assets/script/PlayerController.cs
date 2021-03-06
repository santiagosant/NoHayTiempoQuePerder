﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;

    Rigidbody2D rb2d;

    bool isSuelo;

    public GameObject nivelTerminado;
    public Timer timer;

    public TMPro.TextMeshProUGUI PuntajeActual;
    public TMPro.TextMeshProUGUI PuntajeMax;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Salto
        if (Input.GetKeyDown(KeyCode.W) && isSuelo) {

            rb2d.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);

        }
        //Reiniciar nivel
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void FixedUpdate()
    {
        //Movimiento
        float movX = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(velocidad * movX, rb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "suelo") {

            isSuelo = true;

        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "suelo") {

            isSuelo = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {

            nivelTerminado.SetActive(true);
            Time.timeScale = 0f;
            timer.SaveScore();
            PuntajeMax.text = timer.GetMaxScrore().ToString();
            PuntajeActual.text = timer.puntajeActual().ToString();
        }
    }
}
