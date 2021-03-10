using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject menuObject;
    public string keyname;
    public bool isPaused = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetButtonDown(keyname))
        {
            menuObject.SetActive(!menuObject.activeInHierarchy);
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0f;
            }
            if (!isPaused)
            {
                Time.timeScale = 1f;
            }
        }
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        if (!isPaused)
        {
            Time.timeScale = 1f;
        }

    }
    public void Unpause()
    {
        menuObject.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        menuObject.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }
}
