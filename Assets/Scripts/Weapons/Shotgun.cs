using UnityEngine;

public class Shotgun : Weapon
{
    #region Public Variables

    public int bulletPerShot;
    public GameObject shotExplosionEffect;
    public Transform shotExplosionPosition;

    #endregion

    #region Private Methods

    protected override void Shot()
    {
        for (int i = 0; i < bulletPerShot; i++)
        {
            base.Shot();
        }

        // Show explosion effect
        GameObject explosion = (GameObject)Instantiate(shotExplosionEffect, shotExplosionPosition.position, shotExplosionEffect.transform.rotation);
        explosion.transform.forward = shotExplosionPosition.forward;
        Destroy(explosion, 2.0f);
    } 

    #endregion
}
