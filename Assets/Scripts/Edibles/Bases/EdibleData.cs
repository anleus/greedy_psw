using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EdibleData
{
    [SerializeField]
    public BaseEdible.Size size;

    public int baseCalorieAmount = 0;
    public int prefabIndex;

    public Vector3Ser originalLocalScale;
    public Vector3Ser currentPosition;
}
