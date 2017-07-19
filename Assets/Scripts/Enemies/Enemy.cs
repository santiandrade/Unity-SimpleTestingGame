using System.Collections;
using UnityEngine;

public enum EnemyType { Simple, Jumper, ZigZag, Big, Titan }

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    #region Public Variables

    public EnemyType type;
    public int health;
    public int damage;
    public float speed;
    public float ocurrenceProbability;
    public GameObject deadExplosion;

    #endregion

    #region Private Variables

    protected Rigidbody _thisRigidbody;
    private Renderer _thisRenderer;
    private Animator _thisAnimator;
    private GameObject _player;
    private int _orinigalHealth;
    private bool _stopMovement;

    #endregion

    #region Events

    protected virtual void Awake()
    {
        _thisRigidbody = GetComponent<Rigidbody>();
        _thisRenderer = GetComponentInChildren<Renderer>();
        _thisAnimator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag(GameManager.PLAYER_TAG);
        _orinigalHealth = health;
        _stopMovement = false;

        InvokeRepeating("LookAtPlayer", 0f, 3f);
    }

    void FixedUpdate()
    {
        if (_stopMovement)
        {
            StartCoroutine(StopEnemy());
        }
        else
        {
            Move();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameManager.ENEMY_TAG))
        {
            _stopMovement = true;
        }
    }

    #endregion

    #region Private Methods

    protected void LookAtPlayer()
    {
        var directionToPlayer = _player.transform.position - transform.position;
        directionToPlayer.y = 0;
        transform.forward = directionToPlayer;
    }

    protected virtual void Move()
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        _thisRigidbody.MovePosition(_thisRigidbody.position + movement);
    }

    private void ReduceColor()
    {
        _thisRenderer.material.color = Color.Lerp(
            _thisRenderer.material.color,
            Color.black,
            1f / _orinigalHealth);
    }

    private IEnumerator StopEnemy()
    {
        yield return new WaitForSeconds(3);
        _stopMovement = false;
    }

    #endregion

    #region Public Methods

    public void Hurt(int damage)
    {
        ReduceColor();
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Dead();
        }
    }

    public void Dead()
    {
        // Update enemies counters
        GameManager.instance.currentEnemies--;
        GameManager.instance.killedEnemiesFromLastTitan++;
        if (type == EnemyType.Titan)
        {
            GameManager.instance.currentTitans--;
            GameManager.instance.killedEnemiesFromLastTitan = 0;
        }

        Instantiate(deadExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    #endregion
}
