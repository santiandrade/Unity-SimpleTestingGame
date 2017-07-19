using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Public Variables

    public float speed = 200.0f;
    public float timeOfLive = 3.0f;
    public float impactForce = 10.0f;
    public int damage = 1;
    public GameObject impactEffect;

    #endregion

    #region Private Variables

    private Vector3 _previousPosition;
    private int _layerMaskForRaycasting;

    #endregion

    #region Public Methods

    public void SetBulletDamage(int newDamage)
    {
        damage = newDamage;
    }

    #endregion

    #region Events

    void Awake()
    {
        _previousPosition = transform.position;
        _layerMaskForRaycasting = 1 << GameManager.ENEMIES_LAYER;

        Destroy(gameObject, timeOfLive);
    }

    void Update()
    {
        CheckCollisionsWithEnemies();
        MoveBullet();
    }

    #endregion

    #region Private Methods

    // For the bullets we are using raycasts in order to obtain a more accurate impacts detection
    private void CheckCollisionsWithEnemies()
    {
        RaycastHit hitInfo;
        bool isImpact = Physics.Raycast(_previousPosition, transform.forward, out hitInfo, 30f, _layerMaskForRaycasting);
        if (isImpact)
        {
            Rigidbody impactedRigidbody = hitInfo.transform.GetComponent<Rigidbody>();
            if (impactedRigidbody != null)
            {
                // Show the impact effect
                GameObject newImpactEffect = (GameObject)Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
                Destroy(newImpactEffect, 1.0f);

                // Apply impact force to enemy
                impactedRigidbody.AddForceAtPosition(transform.forward * impactForce, hitInfo.point, ForceMode.Impulse);

                impactedRigidbody.transform.GetComponent<Enemy>().Hurt(damage);

                Destroy(gameObject);
            }
        }
    }

    private void MoveBullet()
    {
        Vector3 newPosition = _previousPosition + (transform.forward * speed * Time.deltaTime);
        transform.position = newPosition;
        _previousPosition = newPosition;
    }

    #endregion
}
