using UnityEngine;

public class ZigZagEnemy : Enemy
{
    #region Public Variables

    public float timeToChangeDirection; 

    #endregion

    #region Private Variables

    private float _timeTurnLastJump;
    private bool _turnLeft;
    private int _numOfTurns; 

    #endregion

    #region Private Methods

    protected override void Awake()
    {
        base.Awake();

        _timeTurnLastJump = timeToChangeDirection;
        _turnLeft = true;
        _numOfTurns = 0;
    }

    protected override void Move()
    {
        base.Move();

        if (_numOfTurns > 2)
        {
            LookAtPlayer();
            _numOfTurns = 0;
        }

        if (_timeTurnLastJump >= timeToChangeDirection)
        {
            transform.Rotate(transform.up * (_turnLeft ? -90f : 90f));
            _turnLeft = !_turnLeft;
            _timeTurnLastJump = 0f;
            _numOfTurns++;
        }

        if (_timeTurnLastJump < timeToChangeDirection)
        {
            _timeTurnLastJump += Time.deltaTime;
        }
    } 

    #endregion
}
