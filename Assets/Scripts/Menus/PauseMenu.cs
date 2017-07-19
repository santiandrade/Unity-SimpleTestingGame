using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class PauseMenu : MonoBehaviour
{
    #region Private Variables

    private Canvas _thisCanvas; 

    #endregion

    #region Events

    void Awake()
    {
        _thisCanvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(GameManager.MAIN_MENU_SCENE_ID);
            }
            else
            {
                Time.timeScale = 0f;
                _thisCanvas.enabled = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Time.timeScale == 0f)
            {
                _thisCanvas.enabled = false;
                Time.timeScale = 1f;
            }
        }
    } 

    #endregion
}
