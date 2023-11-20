using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{

    private Transform unit;
    private Transform worldSpaceCanvas;
    public Vector3 offset;
    private void Start()
    {
        worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas").transform;
        unit = transform.parent;
        transform.SetParent(worldSpaceCanvas);
        transform.position = unit.position + offset;
    }
    private void Update()
    {
        transform.position = unit.position + offset;
    }
}
