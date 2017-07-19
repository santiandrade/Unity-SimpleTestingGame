using UnityEngine;

public class Loader : MonoBehaviour
{
    #region Public Variables

    public GameObject gameManager;

    #endregion

    #region Events

    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }
    } 

    #endregion
}
