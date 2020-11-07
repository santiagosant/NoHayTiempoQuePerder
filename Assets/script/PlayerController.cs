using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;

    Rigidbody2D rb2d;

    bool isSuelo;

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
}
