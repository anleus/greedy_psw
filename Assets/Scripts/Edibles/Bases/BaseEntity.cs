using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEntity : MonoBehaviour
{
    public SpawnPointLogic currentSpawnPoint;
    public Vector3 effectOffset = new Vector3(-1.5f, -1f, 0);

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual void Awake()
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


    protected virtual void OnDestroy()
    {
        if (currentSpawnPoint != null)
            currentSpawnPoint.FreeSpawnPoint();
    }


}
