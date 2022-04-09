using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScripts : MonoBehaviour
{

    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {

        //Allow mouse cursor visibility
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioData.Play();

    }

    // Start game
    public void StartGame()
    {
        
        StartCoroutine(pausemenu());
   
    }

    //Quit Application
    public void ExitGame()
    {
        audioData.Stop();
        Application.Quit();
    }
    //wait to play sound befor loading game scene
    IEnumerator pausemenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
