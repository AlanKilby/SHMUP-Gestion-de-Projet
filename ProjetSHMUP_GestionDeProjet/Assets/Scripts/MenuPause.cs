using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public bool EnPause = false;
    public bool EnPause2 = false;
    // Start is called before the first frame update
    void Start()
    {
        EnPause2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape)) {

            EnPause = !EnPause;

            if(EnPause)
            
                Time.timeScale = 0f;

                else
                    Time.timeScale = 1f;
            

        }
    }

    private void OnGUI()
    {
        if(EnPause)
        {

            if(GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2-20,80,40),"Continuer"))
            {
                EnPause = false;
                Time.timeScale = 1f;
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Play Again"))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Level1");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 100, 80, 40), "Quitter"))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (EnPause2)
        {
            Time.timeScale = 0f;
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Play Again"))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Level1");

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 100, 80, 40), "Quitter"))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("MainMenu");

            }
        }
    }
}
