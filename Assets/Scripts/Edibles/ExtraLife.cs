using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : BaseEntity
{
    protected override void Start()
    {
        base.Start();
        GameManager.CreateEffect(AssetManager.instance.ResurrectionLightEffect, transform.position, null);
    }
    protected override void OnCollision(Collision2D col)
    {
        GameManager.instance.PlaySound(SoundManager.instance.lifeClink);

        Vector3 effectPosition = new Vector3(2f, -2f, 0f);

        //GameManager.CreateEffect(AssetManager.instance.HeartPickupEffect, transform.position, null);
        GameManager.CreateEffect(AssetManager.instance.HeartPickupEffect, effectPosition, col.gameObject.transform);
        Destroy(gameObject);

        GameManager.instance.getPlayerStats().IncreaseLifes(1);
    }
}
