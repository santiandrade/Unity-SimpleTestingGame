using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    #region Constants

    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string SNIPER_WEAPON_TAG = "SniperWeapon";

    public const int ENEMIES_LAYER = 8;

    public const int MAIN_MENU_SCENE_ID = 0;
    public const int LEVEL_1_SCENE_ID = 1;
    public const int YOU_WIN_SCENE_ID = 2;
    public const int GAME_OVER_SCENE_ID = 3;

    #endregion

    #region Public Variables

    public int playerHealth;
    public float levelTime;
    public int maxNumEnemies;
    public int killedEnemiesForTitan;

    [HideInInspector]
    public string selectedWeapon;
    [HideInInspector]
    public int currentEnemies;
    [HideInInspector]
    public int currentTitans;
    [HideInInspector]
    public int killedEnemiesFromLastTitan;

    #endregion

    #region Private Variables

    private int _originalPLayerHealth;
    private float _originalLevelTime; 

    #endregion

    #region Events

    void Awake()
    {
        _originalPLayerHealth = playerHealth;
        _originalLevelTime = levelTime;

        InitializeParams();

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name.ToLower().Contains("level"))
        {
            levelTime -= Time.deltaTime;

            if (levelTime <= 0f)
            {
                SceneManager.LoadScene(GameManager.YOU_WIN_SCENE_ID);
            }
        }
    }

    #endregion

    #region Public Methods

    public void InitializeParams()
    {
        playerHealth = _originalPLayerHealth;
        levelTime = _originalLevelTime;
        currentEnemies = 0;
        currentTitans = 0;
        killedEnemiesFromLastTitan = 0;
    }

    #endregion
}
