using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mommy : MonoBehaviour
{
    public float DamageRadious;
    public float DamageTimeDistance;
    public Transform Target;
    public GameObject Slipper;

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
            if (Time.time - LastDamageTime > DamageTimeDistance)
            {
                GameObject g = (GameObject) Instantiate(Slipper, transform.position, Quaternion.identity);
                g.GetComponent<Slipper>().target = Target;
                LastDamageTime = Time.time;
            }
        }
    }
}
