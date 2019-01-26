using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mommy : MonoBehaviour
{
    public float DamageRadious;
    public float DamageTimeDistance;
    public Transform Target;

    private float LastDamageTime = 0;

    void Update()
    {
        if (!Target)
        {
            Collider[] colliders;
            colliders = Physics.OverlapSphere(transform.position, DamageRadious);
            if (colliders.Length > 0)
                Target = colliders[0].gameObject.transform;
        }
        else
        {
//          
        }
    }
}
