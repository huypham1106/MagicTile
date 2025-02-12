using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMoveToObject : MonoBehaviour
{
   [SerializeField] public Transform objectA;
   [SerializeField] public float offsetY;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        float length = objectA.localScale.y;

        Vector3 newPosition = initialPosition + new Vector3(0f, length + offsetY, 0f);

        transform.position = newPosition;
    }
}
