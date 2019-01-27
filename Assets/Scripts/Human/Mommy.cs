using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mommy : MonoBehaviour
{
    public float DamageRadious;
    public float DamageTimeDistance;
    public float RotationSpeed;
    public Transform Target;
    public Transform ShootStartPosition;
    public GameObject Slipper;
    public Animator animator;

    private float LastDamageTime = 0;

    void Update()
    {
        if (!Target)
        {
            Collider[] colliders;
            colliders = Physics.OverlapSphere(transform.position, DamageRadious);
            if (colliders.Length > 0)
                Target = colliders[0].gameObject.transform;
            animator.SetBool("IsShooting", false);
        }
        else
        {
            if ((Target.position - transform.position).magnitude > DamageRadious)
            {
                Target = null;
                return;
            }
            animator.SetBool("IsShooting", true);
            Vector3 direction = Target.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(-direction, transform.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, RotationSpeed * Time.time);
            
            if (Time.time - LastDamageTime > DamageTimeDistance)
            {
                GameObject g = (GameObject) Instantiate(Slipper, ShootStartPosition.position, Quaternion.identity);
                g.GetComponent<Slipper>().target = Target;
                LastDamageTime = Time.time;
            }
        }
    }
}
