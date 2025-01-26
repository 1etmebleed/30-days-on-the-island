using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("soundtrackMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        AudioManager.instance.Stop("soundtrackMenu");
        SceneManager.LoadScene("TestingScene");
    }
    public void ExitButton()
    {
        AudioManager.instance.Stop("soundtrackMenu");
        Application.Quit();
    }
}
