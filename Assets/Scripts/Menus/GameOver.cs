using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    #region Events

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(GameManager.MAIN_MENU_SCENE_ID);
        }
    } 

    #endregion
}
