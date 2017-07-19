using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GUIHealth : MonoBehaviour
{
    #region Private Variables

    private Text healthText; 

    #endregion

    #region Events

    void Awake()
    {
        healthText = GetComponent<Text>();
    }

    void Update()
    {
        healthText.text = GameManager.instance.playerHealth.ToString();
    } 

    #endregion
}
