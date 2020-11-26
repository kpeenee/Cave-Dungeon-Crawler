using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] float yOffset = 1.75f;
    Transform parent;

    private void Start()
    {
        parent = transform.parent;
    }

    void Update()
    {
        transform.position = new Vector3(parent.position.x, parent.position.y + yOffset, parent.position.z);
    }
}
