using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    protected virtual void Start()
    {
                
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            OnCollision(col);
    }


    //  PARA MODIFICAR LAS COLISIONES EN CLASES HIJAS, SOBREESCRIBIR ESTE METODO EN ESTAS.
    protected virtual void OnCollision(Collision2D col)
    {
        Debug.Log("COLISION DE BASEENTITY. NO DEBERIA PASAR. ERROR.");
        //Hacer aparecer los efectos
       // GameManager.CreateEffect(effect, transform.position);
        //GameManager.CreateEffect(effect, col.gameObject.transform.position);
       // Destroy(gameObject); // Destruir la manzana
    }

}
