using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public Vector3 offset = new Vector3(0f, -1f);


    GameObject shadow;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = offset;
        transform.localRotation = Quaternion.identity;

        SpriteRenderer parentRenderer = GetComponentInParent<SpriteRenderer>();
        SpriteRenderer shadowRenderer = GetComponent<SpriteRenderer>();

        shadowRenderer.sortingLayerName = parentRenderer.sortingLayerName;
        shadowRenderer.sortingOrder = parentRenderer.sortingOrder - 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.localPosition = offset;
    }
}
