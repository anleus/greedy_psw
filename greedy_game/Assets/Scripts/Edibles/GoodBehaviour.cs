using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBehaviour : MonoBehaviour
{
    ParticleSystem particles;
    public GameObject effect;

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
        Instantiate(effect, transform.position, Quaternion.identity);
        //Instantiate(effect, col.gameObject.transform.position, Quaternion.identity);
        //Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
