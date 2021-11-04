using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NieblaToxica : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ProtaController controller = other.GetComponent<ProtaController >();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
        //al entrar en contacto con el protagonista se quitara 1 de vida
    }

}
