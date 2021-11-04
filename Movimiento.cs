using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    //se inician las variables

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        Destroy(gameObject, 1);
    }
    //se dispara el objeto con fuerza y direccion y al tocar un Box collider se destruye
    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    //si el proyectil sobrepasa 1000.0f de distancia se destruye
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }
    //destruye un objeto
}
