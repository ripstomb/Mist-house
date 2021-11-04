using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBreve : MonoBehaviour
{
    public float speed;
    public bool horizontal;
    public float changeTime = 3.0f;
    //para que se mueva a un lado y que despues de cierto tiempo cambie de dirección
    new Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    //se tiene en cuenta el rigidbody, ademas el timer mantiene el valor actual del temporizador mientras que dirección es eso mismo
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
            //si el timer es menor a 0 entonces la dirección cambia a la opuesta y el temporizador se reinicia
        {
            direction = -direction;
            timer = changeTime;
        }

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        if (horizontal)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction; ;
        }

        rigidbody2D.MovePosition(position);
        //para que se mueva el objeto en una dirección
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        ProtaController player = other.gameObject.GetComponent<ProtaController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
        //al chocar con el Protagonista le quitará 1 de vida
    }
}
