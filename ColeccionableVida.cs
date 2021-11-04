using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionableVida : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ProtaController controller = other.GetComponent<ProtaController>();
        //darle a el protagonista lo que ofrece este script (vida)
        if (controller != null) 
        {
            if (controller.health < controller.maxHealth)
            //si la vitalidad del protagonista es inferior a la maxima salud entonces se toma el objeto
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
                //el objeto da 1 de vida y se destruye
            }
        }
    }
}
