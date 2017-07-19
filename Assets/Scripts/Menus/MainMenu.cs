using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Events

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.instance.InitializeParams();
            SceneManager.LoadScene(GameManager.LEVEL_1_SCENE_ID);
        }
    } 

    #endregion
}
