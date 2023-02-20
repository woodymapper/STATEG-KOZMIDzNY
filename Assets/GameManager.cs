using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {   //nie usuwa gej menad¿êra
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {

        SceneManager.LoadScene("Level");

    }
    public void Quit() { 
    
    
    Application.Quit();
    
    }


}
