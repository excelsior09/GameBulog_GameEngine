using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                kembaliKeMenu();
            }
        }
    }

    public void MulaiPermainan()
    {
        SceneManager.LoadScene("Main");
    }

    public void kembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void howToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
