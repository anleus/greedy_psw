﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        GameManager.CreateEffect(AssetManager.instance.PoofEffect, transform.position + effectOffset, null);
        GameManager.CreateEffect(AssetManager.instance.PoofEffect, player.transform.position + effectOffset, null);
        Destroy(gameObject); // Destruir la entidad

        GameManager.instance.getPlayerStats().IncreaseCalories(getCaloriesAmount());


        GameManager.instance.PlaySound(SoundManager.instance.fruitEat);
    }
}

