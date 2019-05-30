using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerup : MonoBehaviour
{
    private static int SHIELD = 0;
    private static int FLASH = 1;
    private static int STOP = 2;
    private int shieldDuration = 3;
    private int flashDuration = 5;
    private int stopDuration = 4;
    private float baseSpeed;
    private int multiplier = 2;
    private GameObject[] enemies;
    public GameObject deathEffect;
    public GameObject lifeEffect;
    public GameObject shieldEffect;

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
        if(number == STOP){
            StartCoroutine(ApplyStop());
        }

        // Quitar el objeto
        
    }

    IEnumerator ApplyShield(Collision2D player)
    {
        Debug.Log("player is:" + player.gameObject.name);
        player.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;

        // espera 3 segundos
        yield return new WaitForSeconds(shieldDuration);

        player.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        Destroy(gameObject);
    }

    IEnumerator ApplyFlash(PlayerController controller)
    {
        baseSpeed = controller.speed;
        controller.SetPlayerSpeed(baseSpeed * multiplier);

        // espera 5 segundos
        yield return new WaitForSeconds(flashDuration);


        controller.SetPlayerSpeed(baseSpeed);
        Destroy(gameObject);
    }

    IEnumerator ApplyStop()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // lo de usar para este efecto (no chocarte con cosas) una variable booleana
        // es una idea, pero vamos que haz como lo veas eh
        // asegurate de que si se le acaba el efecto y se queda encima de un collider no se quede buggeado
        //GameManager.instance.trespasserOn = true;
        foreach (GameObject enemy in enemies)
        {
            //Debug.Log("Enemy: " + enemy.name);
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null) {
                enemy.SetActive(false);
                Instantiate(deathEffect, enemy.transform.position, Quaternion.identity);
            }
        }

        // espera 3 segundos
        yield return new WaitForSeconds(stopDuration);
        //GameManager.instance.trespasserOn = false;
        foreach (GameObject enemy in enemies)
        {
            Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
            if (rb != null) {
                enemy.SetActive(true);
                Instantiate(lifeEffect, enemy.transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject);
    }

    // Para la espera de tiempo, hacer un metodo al que se le pase
    // el tiempo a esperar para cada paso y lo haga
}
