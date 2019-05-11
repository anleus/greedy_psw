using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoseAnimator : MonoBehaviour
{
    private Animator jose;
    //private EnemyControll path;
    // Start is called before the first frame update

    void Start()
    {
        jose = GetComponent<Animator>();
        //path = GetComponent<EnemyControll>();
    }

    // Update is called once per frame
    void Update()
    {
        //dir = path.dir;
    }

    public void Facing(Vector2 dir)
    {
        //Debug.Log(dir);
        if (dir.x < 0 && dir.y == 0)
        {
            //Debug.Log("FacingLeft");
            jose.SetBool("FacingLeft", true);
            jose.SetBool("FacingRight", false);
            jose.SetBool("FacingUp", false);
            jose.SetBool("FacingDown", false);
        } else if (dir.x > 0 && dir.y == 0)
        {
           // Debug.Log("FacingRight");
            jose.SetBool("FacingLeft", false);
            jose.SetBool("FacingRight", true);
            jose.SetBool("FacingUp", false);
            jose.SetBool("FacingDown", false);
        }
        else if (dir.y > 0 && dir.x == 0)
        {
            //Debug.Log("FacingUp");
            jose.SetBool("FacingLeft", false);
            jose.SetBool("FacingRight", false);
            jose.SetBool("FacingUp", true);
            jose.SetBool("FacingDown", false);
        }
        else if (dir.y > 0 && dir.x == 0)
        {
            //Debug.Log("FacingDown");
            jose.SetBool("FacingLeft", false);
            jose.SetBool("FacingRight", false);
            jose.SetBool("FacingUp", false);
            jose.SetBool("FacingDown", true);
        }
    }
}
