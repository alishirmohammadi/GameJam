using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int[] waves;
    public GameObject enemy;
    private float LastWave = 0;
    private float LastSheepSpawn = 0;
    private int waveNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && Time.time - LastWave > 3f)
        {
            LastSheepSpawn = 0;
            for (int i = 0; i < waves[waveNum]; i++)
            {
                LastSheepSpawn += Random.Range(1f, 2f);
                Invoke("CreateSheep",LastSheepSpawn);
            }

            LastWave = Time.time;

            waveNum++;
        }
    }

    void CreateSheep()
    {
        GameObject sheep = (GameObject) Instantiate(enemy, Vector3.zero, Quaternion.identity);
    }
}