using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    ParticleSystem particles;
    public GameObject effect;

    public int damage = 35;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player") {

            //Hacer aparecer los efectos
            createEffect(transform.position);
            createEffect(col.gameObject.transform.position);
            Destroy(gameObject); // Destruir la manzana


            ReduceLife();
        }
    }

    private GameObject createEffect(Vector3 position)
    {
        GameObject particleEffect = Instantiate(effect, position, Quaternion.identity);

        return particleEffect;
    }

    private void ReduceLife() 
    {
        GameManager.instance.playerStats.ReduceHealth(damage);
    }
}
