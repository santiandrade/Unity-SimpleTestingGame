using UnityEngine;

public class JumperEnemy : Enemy
{
    #region Public Variables

    public float jumpForce;
    public float timeBetweenJumps; 

    #endregion

    #region Private Variables

    private float _timeFromLastJump; 

    #endregion

    #region Private Methods

    protected override void Awake()
    {
        base.Awake();

        _timeFromLastJump = timeBetweenJumps;
    }

    protected override void Move()
    {
        base.Move();

        if (_timeFromLastJump >= timeBetweenJumps)
        {
            _thisRigidbody.velocity = new Vector3(0f, jumpForce, 0f);
            _timeFromLastJump = 0f;
        }

        if (_timeFromLastJump < timeBetweenJumps)
        {
            _timeFromLastJump += Time.deltaTime;
        }
    } 

    #endregion
}
