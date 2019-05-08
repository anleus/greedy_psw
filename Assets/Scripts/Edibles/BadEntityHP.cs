using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEntityHP : BaseEntity
{
    public int damage = 35;

    protected override void OnCollision(Collision2D col)
    {
        //Hacer aparecer los efectos
        GameManager.CreateEffect(effect, transform.position);
        GameManager.CreateEffect(effect, col.gameObject.transform.position);
        Destroy(gameObject); // Destruir la entidad


        GameManager.instance.playerStats.ReduceHealth(damage);
    }
}
