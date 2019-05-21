using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float[] position;

    // Falta obtener el level
    public EnemyData(PlayerStats ps)
    {
        position = new float[3];
        position[0] = ps.transform.position.x;
        position[1] = ps.transform.position.y;
        //position[2] = ps.transform.position.z;
    }
}
