using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class Manager : MonoBehaviour
{
    public enum GameButton {
        None=0, Daddy=1, Mommy=2, Boy=3, Girl=4
    }

    public GameButton selectedButton = GameButton.None;
    public Button daddyButton, mommyButton, boyButton, girlButton;
    public Camera camera;
    public GameObject motherPrefab, fatherPrefab, boyPrefab, girlPrefab;


    private GameObject father;
    public void ButtonSelect(int btnInt)
    {
        GameButton btn = (GameButton) btnInt;
        if (selectedButton == btn)
            selectedButton = GameButton.None;
        else
            selectedButton = btn;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (father.GetComponent<Dady>())
                father.GetComponent<Dady>().isRotating = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(Input.mousePosition);
            RaycastHit[] raycastHit = Physics.RaycastAll(ray);
            foreach (RaycastHit hitInfo in raycastHit)
            {
                if (hitInfo.transform.gameObject.CompareTag("Background"))
                {
                    if (selectedButton == GameButton.Mommy && motherPrefab)
                    {
                        GameObject mother = (GameObject) Instantiate(motherPrefab, hitInfo.point, Quaternion.LookRotation(Vector3.up, Vector3.back));
                        motherPrefab = null;
                    }

                    if (selectedButton == GameButton.Daddy && fatherPrefab)
                    {
                        father = (GameObject) Instantiate(fatherPrefab, hitInfo.point, Quaternion.LookRotation(Vector3.left, Vector3.back));
                        father.GetComponent<Dady>().isRotating = true;
                        fatherPrefab = null;
                    }
                }
            }
        }
    }
}
