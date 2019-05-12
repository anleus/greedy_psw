using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : BaseEntity
{
    //public PlayerStats player;

    protected override void OnCollision(Collision2D col)
    {
        GameManager.CreateEffect(effect, transform.position);
        GameManager.CreateEffect(effect, col.gameObject.transform.position);
        Destroy(gameObject);

        GameManager.instance.playerStats.IncreaseLifes(1);

        //Hacer que aumente en 1 la vida
        //GameManager.instance.playerStats.IncreaseCalories(bonusCalories);
    }
}
