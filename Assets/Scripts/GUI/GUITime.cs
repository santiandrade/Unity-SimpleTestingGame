using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GUITime : MonoBehaviour
{
    #region Private Variables

    private Text timeText; 

    #endregion

    #region Events

    void Awake()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        timeText.text = GameManager.instance.levelTime.ToString("N0");
    } 

    #endregion
}
