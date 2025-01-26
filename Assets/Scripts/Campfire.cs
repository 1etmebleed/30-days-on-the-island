using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public bool isReady = false;

    public GameManager gameManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isReady)
        {
            gameManager.panelCook.SetActive(false);
            
        }
        GoCook();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isReady = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isReady = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void GoCook()
    {
        if (isReady && Input.GetKeyDown(KeyCode.F))
        {
            Cursor.lockState = CursorLockMode.Confined;
            AudioManager.instance.Play("openBackpack");
            gameManager.panelCook.SetActive(true);
        }
    }

}
