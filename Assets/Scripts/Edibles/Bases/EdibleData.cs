using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EdibleData
{

    public BaseEdible.Size size;
    public Vector3Ser originalLocalScale;
    public Vector3Ser currentPosition;
    public int baseCalorieAmount = 0;

    public int prefabIndex;
}
