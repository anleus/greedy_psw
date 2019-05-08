using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEntity : BaseEntity
{
    public int damage = 35;

    protected override void OnCollision(Collision2D col)
    {
        //Hacer aparecer los efectos
        createEffect(transform.position);
        createEffect(col.gameObject.transform.position);
        Destroy(gameObject); // Destruir la entidad


        GameManager.instance.playerStats.ReduceHealth(damage);
    }
}
