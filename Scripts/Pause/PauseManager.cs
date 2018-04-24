using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    public GameObject pausePanel;
    public bool isPaused;

	// Use this for initialization
	void Start () {
        isPaused = false;
        GameObject thePlayer = GameObject.Find("Player");
        Player playerScript = thePlayer.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isPaused)
        {
            pausedGame(true);
        }
        else
        {
            pausedGame(false);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            switchPause();
        }
	}
    void pausedGame(bool state)
    {
        if (state)
        {            
            Time.timeScale = 0.0f;
            


        }
        else
        {
            Time.timeScale = 1.0f;         
        }
        pausePanel.SetActive(state);
    }
    public void switchPause()
    {
        if(isPaused){
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }
}
