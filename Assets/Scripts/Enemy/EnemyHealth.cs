using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Damage = 20, Health = 5000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Slipper"))
        {
            float enemy_damage = c.gameObject.GetComponent<Slipper>().damage; 
            Health -= enemy_damage;
            Destroy(c.gameObject);
        }
    }

    private void OnMouseDown()
    {
        GameObject mommy = GameObject.Find("Mommy");
        float MaxDistance = mommy.GetComponent<Mommy>().DamageRadious;
        if ((mommy.transform.position - transform.position).magnitude <= MaxDistance)
            mommy.GetComponent<Mommy>().Target = transform;
    }
}
