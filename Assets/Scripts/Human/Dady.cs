using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dady : MonoBehaviour
{
    public bool isRotating = false;
    public float MaxWindDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        if (isRotating)
        {
            ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHit = Physics.RaycastAll(ray);
            foreach (RaycastHit hit_info in raycastHit)
            {
                if (hit_info.transform.gameObject.CompareTag("Background"))
                {
                    Quaternion newRotation = Quaternion.LookRotation((hit_info.point - transform.position == Vector3.zero ? Vector3.left : (hit_info.point - transform.position )), Vector3.back);
                    transform.rotation = newRotation;
                }
            }
            
        }
        
        ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hitInfo = Physics.RaycastAll(ray, MaxWindDistance);
        foreach (RaycastHit enemy in hitInfo)
        {
            if(!enemy.transform.gameObject.CompareTag("Enemy"))
                continue;
            
            float maxSpeed = enemy.transform.gameObject.GetComponent<EnemyMovement>().MaxSpeed;
            float speed = enemy.transform.gameObject.GetComponent<EnemyMovement>().Speed;
            if(maxSpeed * 0.6f < speed)
                enemy.transform.gameObject.GetComponent<EnemyMovement>().Speed *= 0.91f;
        }
    }
}
