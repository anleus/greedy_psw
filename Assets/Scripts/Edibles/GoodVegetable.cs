using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodVegetable : BaseEdible
{
    
    protected override void Start()
    {
        base.Start();

        m_data.baseCalorieAmount = 10;
    }

    public void onEat(GameObject player)
    {
        //Hacer aparecer los efectos
        GameManager.CreateEffect(AssetManager.instance.PoofEffect, transform.position);
        GameManager.CreateEffect(AssetManager.instance.PoofEffect, player.transform.position);
        Destroy(gameObject); // Destruir la entidad

        GameManager.instance.getPlayerStats().IncreaseCalories(getCaloriesAmount());


        GameManager.instance.PlaySound(SoundManager.instance.fruitEat);
    }
}
