using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float distance;
    public float height;

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - distance);
    }
}