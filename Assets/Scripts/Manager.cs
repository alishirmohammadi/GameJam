using System.Collections;
using System.Collections.Generic;
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
        if (Input.touchCount == 1 && selectedButton != GameButton.None)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log(t.position);
            }
        }
    }
}
