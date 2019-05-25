using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : BaseEntity
{
    protected override void Start()
    {
        base.Start();
        GameManager.CreateEffect(AssetManager.instance.ResurrectionLightEffect, transform.position);
    }
    protected override void OnCollision(Collision2D col)
    {
        GameManager.instance.PlaySound(SoundManager.instance.lifeClink);
        
        GameManager.CreateEffect(AssetManager.instance.HeartPickupEffect, transform.position);
        GameManager.CreateEffect(AssetManager.instance.HeartPickupEffect, col.gameObject.transform.position);
        Destroy(gameObject);

        GameManager.instance.getPlayerStats().IncreaseLifes(1);
    }
}
