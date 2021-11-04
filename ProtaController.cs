using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtaController : MonoBehaviour
{
    public float speed;
    public float Salto;
    public bool toco_piso;

    public int maxHealth = 5;
    public float timeInvincible = 3.0f;
    private Rigidbody2D rb;
    //vida maxima del Protagonista y tiempo invencible publicos

    public int score { get { return currentScore; } }
    int currentScore;
    public int health { get { return currentHealth; } }
    int currentHealth;
    bool isInvincible;
    float invincibleTimer;
    //puntuación, salud actual y temporizador de invencibilidad del protagonista
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        //al iniciar el juego obtiene la vida
    }

    void onCollisionEnter2D(Collision2D c)
    {
        toco_piso = c.gameObject.tag.Equals("piso");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            rb.transform.localScale = new Vector2(1,1);
            // Movimiento hacia la derecha
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            rb.transform.localScale = new Vector2(-1, 1);
            // Movimiento hacia la izquierda
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, Salto);
          
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, speed);
            rb.transform.localScale = new Vector3(1, 1);
            // Movimiento hacia arriba
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, -speed);
            rb.transform.localScale = new Vector3(1, 1);
            // Movimiento hacia abajo
        }



        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
            //invencibilidad
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            //si la catidad de vida es menor a 0 se torna invencible
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
        //cambia la vida de acuerdo a lo que le pase al protagonista
    }
    
    public void ChangeScore(int amount)
    {
        currentScore = currentScore + amount;
        Debug.Log(currentScore);
        //puntuacion 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = collision.transform;
        }



    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = null;
        }
    }
              




}
