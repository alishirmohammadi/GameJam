using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHealth : MonoBehaviour
{
    public float houseHealth = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (houseHealth <= 0)
        {
            GameObject.Find("Text").GetComponent<Animator>().enabled=true;
            
            Invoke("LoadMenu", 0.666666f);
        }
            
    }

    void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}

