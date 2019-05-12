using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : BaseEntity
{
    protected override void OnCollision(Collision2D col)
    {
        GameManager.CreateEffect(effect, transform.position);
        GameManager.CreateEffect(effect, col.gameObject.transform.position);
        Destroy(gameObject);

        //Hacer que aumente en 1 la vida
        //GameManager.instance.playerStats.IncreaseCalories(bonusCalories);
    }
}
