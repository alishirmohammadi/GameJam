using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public GameObject[] Routes;
    public float Speed, MaxSpeed, RotationSpeed;
    public float TargetChangeDistance;


    private int TargetIndex;
    private Transform[] RoutePoints;
    
    void Start()
    {
        GameObject Route = Routes[Random.Range(0, Routes.Length)];
        RoutePoints = Route.GetComponentsInChildren<Transform>();
        transform.position = RoutePoints[1].position;
        TargetIndex = 2;
        Speed = MaxSpeed;
    }

    void Update() {
        Vector3 direction = RoutePoints[TargetIndex].position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, RotationSpeed * Time.time);
//        transform.LookAt(RoutePoints[TargetIndex]);
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        float distance = (RoutePoints[TargetIndex].position - transform.position).magnitude;
        if (distance < TargetChangeDistance)
        {
            if(TargetIndex < RoutePoints.Length - 1)
                TargetIndex++;
            else
                Destroy(gameObject);
        }

        if (Speed < MaxSpeed)
            Speed *= 1.004f;
    }
}
