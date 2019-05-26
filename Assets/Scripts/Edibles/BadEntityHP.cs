using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEntityHP : BaseEntity
{
    public int damage = 35;

    protected override void OnCollision(Collision2D col)
    {
        //Hacer aparecer los efectos
        Debug.Log("Explosion!! le paso " + transform.position);
        GameManager.CreateEffect(AssetManager.instance.PurpleDeathExplosionEffect, transform.position + effectOffset, null);
        Destroy(gameObject); // Destruir la entidad

        GameManager.instance.PlaySound(SoundManager.instance.explosion);
        GameManager.instance.spriteRenderer.color = new Color(255, 0, 0); 
        GameManager.instance.getPlayerStats().IncreaseDamage(damage);
    }
}
