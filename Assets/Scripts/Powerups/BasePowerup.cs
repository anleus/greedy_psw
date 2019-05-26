using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerup : MonoBehaviour
{
    private static int SHIELD = 0;
    private static int FLASH = 1;
    private static int TRESPASS = 2;
    private int shieldDuration = 3;
    private int flashDuration = 5;
    private int trespassDuration = 4;
    private float baseSpeed;
    private int multiplier = 2;

    protected void PickUp(GameObject powerEffect, Collision2D player, int number) 
    {
        PlayerController controller = GameManager.instance.getPlayerController();
        // Animacion
        Instantiate(powerEffect, transform.position, transform.rotation);
        
        // Aplicar efecto al jugador 
        if(number == SHIELD){
            StartCoroutine(ApplyShield(player));
        }
        if(number == FLASH){
            StartCoroutine(ApplyFlash(controller));
        }
        if(number == TRESPASS){
            StartCoroutine(ApplyTrespass());
        }

        // Quitar el objeto
        
    }

    IEnumerator ApplyShield(Collision2D player)
    {
        // cuando choque con un objeto, 
        // comprueba primero que no tenga el escudo puesto para aplicarle el daño
        //GameManager.instance.shielOn = true;

        player.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;

        // espera 3 segundos
        yield return new WaitForSeconds(shieldDuration);
        //GameManager.instance.shielOn = false;
        player.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        Destroy(gameObject);
    }

    IEnumerator ApplyFlash(PlayerController controller)
    {
        Debug.Log("GOTTA GO FAST");
        baseSpeed = controller.speed;
        controller.SetPlayerSpeed(baseSpeed * multiplier);

        // espera 5 segundos
        yield return new WaitForSeconds(flashDuration);


        controller.SetPlayerSpeed(baseSpeed);
        Debug.Log("No more fast");
        Destroy(gameObject);
    }

    IEnumerator ApplyTrespass()
    {
        // lo de usar para este efecto (no chocarte con cosas) una variable booleana
        // es una idea, pero vamos que haz como lo veas eh
        // asegurate de que si se le acaba el efecto y se queda encima de un collider no se quede buggeado
        GameManager.instance.trespasserOn = true;
        // espera 3 segundos
        yield return new WaitForSeconds(trespassDuration);
        GameManager.instance.trespasserOn = false;
        Destroy(gameObject);
    }

    // Para la espera de tiempo, hacer un metodo al que se le pase
    // el tiempo a esperar para cada paso y lo haga
}
