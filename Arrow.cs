using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - target.position;
        Vector3 normalizedDirection = direction.normalized;
        Quaternion rotation = Quaternion.LookRotation(normalizedDirection);
        transform.rotation = rotation;
    }
}
