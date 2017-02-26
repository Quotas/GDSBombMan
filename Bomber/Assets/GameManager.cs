using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public Button playButton;
    public Button quitButton;

    Button[] buttons;

    public static GameManager Instance;

	// Use this for initialization
	void Start () {

        if (Instance)
            DestroyImmediate(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        quitButton.GetComponent<Button>().onClick.AddListener(quitButtonCallBack);
        playButton.GetComponent<Button>().onClick.AddListener(playButtonCallBack);


    }
	
	// Update is called once per frame
	void Update () {

        if (quitButton == null) {

            buttons = FindObjectsOfType(typeof(Button)) as Button[];
            foreach (Button button in buttons) {

                if (button.tag == "QuitButton")
                {
                    quitButton = button;
                    quitButton.GetComponent<Button>().onClick.AddListener(quitButtonCallBack);
                }
                else if (button.tag == "PlayButton") {
                    playButton = button;
                    playButton.GetComponent<Button>().onClick.AddListener(playButtonCallBack);
                }

            }

        }

        if (SceneManager.GetActiveScene().name == "Main") {


            if (Input.GetKeyDown(KeyCode.Escape))
            {

                SceneManager.LoadScene("MainMenu");


            }
            //Add a key to spawn in a new player
            //If players want to join the game then this key input will add them - something like emilies single button input





        }

	}

    void playButtonCallBack() {

        SceneManager.LoadScene("Main");
        
    }

    void quitButtonCallBack() {
        
        Application.Quit();

    }


}
