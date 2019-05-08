using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    public GameObject effect;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
            OnCollision(col);
    }


    //  PARA MODIFICAR LAS COLISIONES EN CLASES HIJAS, SOBREESCRIBIR ESTE METODO EN ESTAS.
    protected virtual void OnCollision(Collision2D col)
    {
        Debug.Log("OnCollision Padre");
        //Hacer aparecer los efectos
        createEffect(transform.position);
        createEffect(col.gameObject.transform.position);
        Destroy(gameObject); // Destruir la manzana
    }

    protected GameObject createEffect(Vector3 position)
    {
        GameObject particleEffect = Instantiate(effect, position, Quaternion.identity);
        particleEffect.layer = 8; // Particles

        return particleEffect;
    }
}
