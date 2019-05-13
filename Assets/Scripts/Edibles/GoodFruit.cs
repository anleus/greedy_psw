using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodFruit : BaseEntity
{
    public int bonusCalories = 50;

    public void onEat(GameObject player)
    {
        //Hacer aparecer los efectos
        GameManager.CreateEffect(AssetManager.instance.PoofEffect, transform.position);
        GameManager.CreateEffect(AssetManager.instance.PoofEffect, player.transform.position);
        Destroy(gameObject); // Destruir la entidad

        GameManager.instance.getPlayerStats().IncreaseCalories(bonusCalories);


        GameManager.instance.PlaySound(SoundManager.instance.fruitEat);
    }
}
