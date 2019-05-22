using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GoodFruit : BaseEdible
{
    
    protected override void Start()
    {
        base.Start();

        this.m_data.baseCalorieAmount = 5;
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






