using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerup : MonoBehaviour
{
    private static int SHIELD = 0;
    private static int FLASH = 1;
    private static int TRESPASS = 2;

    protected void PickUp(GameObject powerEffect, Collider player, int number) 
    {
        // Animacion
        Instantiate(powerEffect, transform.position, transform.rotation);
        
        // Aplicar efecto al jugador 
        ApplyPowerUp(number);

        // Quitar el objeto
        Destroy(gameObject);
    }

    protected void ApplyPowerUp(int effect)
    {
        PlayerController controller = GameManager.instance.getPlayerController();

        if(effect == SHIELD){
            // cuando choque con un objeto, 
            // comprueba primero que no tenga el escudo puesto para aplicarle el daño
            GameManager.instance.shielOn = true;
            // espera 3 segundos
            GameManager.instance.shielOn = false;
        }
        if(effect == FLASH){
            controller.SetPlayerSpeed(800f);
            // espera 5 segundos
            controller.SetPlayerSpeed(500f);
        }
        if(effect == TRESPASS){
            // lo de usar para este efecto (no chocarte con cosas) una variable booleana
            // es una idea, pero vamos que haz como lo veas eh
            // asegurate de que si se le acaba el efecto y se queda encima de un collider no se quede buggeado
            GameManager.instance.trespasserOn = true;
            // espera 3 segundos
            GameManager.instance.trespasserOn = false;
        }
    }

    // Para la espera de tiempo, hacer un metodo al que se le pase
    // el tiempo a esperar para cada paso y lo haga
}
