using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    #region Public Variables

    public List<GameObject> weapons;
    public Transform weaponTransform;

    #endregion

    #region Private Variables

    private Animator _thisAnimator;
    private List<GameObject> _instantiatedWeapons;

    #endregion

    #region Events

    void Awake()
    {
        _thisAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        InstantiateWeapons();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWeapon();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(GameManager.ENEMY_TAG))
        {
            Enemy collisionedEnemy = collision.transform.GetComponent<Enemy>();
            Hurt(collisionedEnemy.damage);
            collisionedEnemy.Dead();
        }
    }

    #endregion

    #region Private Methods

    private void InstantiateWeapons()
    {
        _instantiatedWeapons = new List<GameObject>();

        for (int i = 0; i < weapons.Count; i++)
        {
            GameObject newWeapon = Instantiate(weapons[i], weaponTransform.position, transform.rotation);
            newWeapon.name = newWeapon.name.Replace("(Clone)", string.Empty);
            newWeapon.transform.parent = weaponTransform;
            if (i > 0)
            {
                newWeapon.SetActive(false);
            }
            else
            {
                UpdateHUDWeaponName(newWeapon);
            }

            _instantiatedWeapons.Add(newWeapon);
        }
    }

    private void ChangeWeapon()
    {
        if (_instantiatedWeapons.Count > 0)
        {
            for (int i = 0; i < _instantiatedWeapons.Count; i++)
            {
                if (_instantiatedWeapons[i].activeSelf)
                {
                    _instantiatedWeapons[i].SetActive(false);

                    if (i < _instantiatedWeapons.Count - 1)
                    {
                        _instantiatedWeapons[i + 1].SetActive(true);
                        UpdateHUDWeaponName(_instantiatedWeapons[i + 1]);
                    }
                    else
                    {
                        _instantiatedWeapons[0].SetActive(true);
                        UpdateHUDWeaponName(_instantiatedWeapons[0]);
                    }

                    break;
                }
            }
        }
    }

    private void UpdateHUDWeaponName(GameObject weapon)
    {
        GameManager.instance.selectedWeapon = weapon.name.ToUpper();
    }

    private void Hurt(int damage)
    {
        _thisAnimator.SetTrigger("Hurt");
        GameManager.instance.playerHealth -= damage;

        if (GameManager.instance.playerHealth <= 0)
        {
            GameManager.instance.playerHealth = 0;
            Dead();
        }
    }

    private void Dead()
    {
        SceneManager.LoadScene(GameManager.GAME_OVER_SCENE_ID);
    }

    #endregion
}
