using UnityEngine;
using UnityEngine.UI;

public class GUIWeapon : MonoBehaviour
{
    #region Private Variables

    private Text weaponText;

    #endregion

    #region Events

    void Awake()
    {
        weaponText = GetComponent<Text>();
    }

    void Update()
    {
        weaponText.text = GameManager.instance.selectedWeapon;
    }

    #endregion
}
