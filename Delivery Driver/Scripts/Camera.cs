using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject car;
    Vector3 offset = new Vector3 (0, 0, -10);

    void LateUpdate()
    {
        transform.position = car.transform.position + offset;
    }
}
