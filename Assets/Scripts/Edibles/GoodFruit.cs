using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodFruit : BaseEntity
{
    public int bonusCalories = 50;

    protected override void OnCollision(Collision2D col)
    {
        //Hacer aparecer los efectos
        GameManager.CreateEffect(effect, transform.position);
        GameManager.CreateEffect(effect, col.gameObject.transform.position);
        Destroy(gameObject); // Destruir la entidad


        GameManager.instance.playerStats.IncreaseCalories(bonusCalories);
    }
}
