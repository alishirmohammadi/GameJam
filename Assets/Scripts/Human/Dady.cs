using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dady : MonoBehaviour
{
    public float MaxWindDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hitInfo = Physics.RaycastAll(ray, MaxWindDistance);
        foreach (RaycastHit enemy in hitInfo)
        {
            float maxSpeed = enemy.transform.gameObject.GetComponent<EnemyMovement>().MaxSpeed;
            float speed = enemy.transform.gameObject.GetComponent<EnemyMovement>().Speed;
            if(maxSpeed * 0.3f < speed)
                enemy.transform.gameObject.GetComponent<EnemyMovement>().Speed *= 0.91f;
        }
    }
}
