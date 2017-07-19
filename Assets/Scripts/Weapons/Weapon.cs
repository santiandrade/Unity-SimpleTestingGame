using UnityEngine;

public enum CadenceType { High, Medium, Low }

[RequireComponent(typeof(AudioSource))]
public class Weapon : MonoBehaviour
{
    #region Public Variables

    public GameObject bullet;
    public Animator weaponAnimator;
    public CadenceType cadence;
    public int bulletsDamage;
    public float dispersionFactor;

    #endregion

    #region Private Variables

    protected AudioSource _thisAudioSource;
    private float _cadenceTime;
    protected float _timeFromLastShot;

    #endregion

    #region Events

    void Awake()
    {
        _thisAudioSource = GetComponent<AudioSource>();

        switch (cadence)
        {
            case CadenceType.High:
                _cadenceTime = 0.1f;
                break;
            case CadenceType.Medium:
                _cadenceTime = 1.0f;
                break;
            case CadenceType.Low:
                _cadenceTime = 2.0f;
                break;
        }

        _timeFromLastShot = _cadenceTime;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButton(0) &&
                _timeFromLastShot >= _cadenceTime)
            {
                Shot();
            }

            if (_timeFromLastShot < _cadenceTime)
            {
                _timeFromLastShot += Time.deltaTime;
            }
        }
    }

    #endregion

    #region Private Methods

    protected virtual void Shot()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
        newBullet.GetComponent<Bullet>().SetBulletDamage(bulletsDamage);

        ApplyBulletDispersion(newBullet);

        weaponAnimator.SetTrigger("Shot");
        _thisAudioSource.Play();

        _timeFromLastShot = 0f;
    }

    private void ApplyBulletDispersion(GameObject bulletObjetc)
    {
        var randomValueX = Random.Range(-dispersionFactor, dispersionFactor);
        var randomValueY = Random.Range(-dispersionFactor, dispersionFactor);
        var randomValueZ = Random.Range(-dispersionFactor, dispersionFactor);

        bulletObjetc.transform.Rotate(randomValueX, randomValueY, randomValueZ);
    }

    #endregion
}
