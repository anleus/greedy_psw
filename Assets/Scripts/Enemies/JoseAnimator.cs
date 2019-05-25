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
        jose.SetBool("FacingLeft", dir.x < 0 /*&& dir.y == 0*/);
        jose.SetBool("FacingRight", dir.x > 0 /*&& dir.y == 0*/);
        jose.SetBool("FacingUp", dir.y > 0 /*&& dir.x == 0*/);
        jose.SetBool("FacingDown", dir.y < 0 /*&& dir.x == 0*/);
    }
}
