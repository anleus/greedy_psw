using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float[] position;

    // Falta obtener el level
    public EnemyData(Enemy enemy)
    {
        position = new float[3];
        position[0] = enemy.transform.position.x;
        position[1] = enemy.transform.position.y;
        //position[2] = enemy.transform.position.z;
    }
}
