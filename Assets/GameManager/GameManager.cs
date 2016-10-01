using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Input Escape detected, atempting to load main menu");
            SceneManager.LoadScene(0);
            //Debug.Log(Input.anyKeyDown);
        }
        else if ((SceneManager.GetActiveScene().name + "XXXXXXXXX").Substring(0, 9) == "levelText" && Input.anyKeyDown)
        {
            Debug.Log("SKiped text");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else if (Input.GetKeyDown(KeyCode.Space) && (SceneManager.GetActiveScene().name + "XXXXXXXXX").Substring(0, 9) != "levelText")
        {
            ResetScene();
        }

    }


    // Doubles as reset function by
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("The Scene was changed to " + sceneName);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("The Scene was reset to: " + SceneManager.GetActiveScene().name);
    }
}
