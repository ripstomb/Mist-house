using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyRojo: MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ProtaController controller = other.GetComponent<ProtaController>();

        if (controller != null)
        {
            controller.ChangeScore(10);
            Destroy(gameObject);          
        }

    }
    //al tocar el objeto se obtienen 10 puntos y se destruye
}
