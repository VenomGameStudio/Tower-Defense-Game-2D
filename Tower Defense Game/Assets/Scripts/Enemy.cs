using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform exitPoint;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float navUpdate;

    private int target = 0;
    private Transform enemy;
    private float navTime = 0f;

    private void Awake()
    {
        Assert.IsNotNull(exitPoint);
        Assert.IsNotNull(wayPoints);
    }

    private void Start()
    {
        enemy = GetComponent<Transform>();
    }

    private void Update()
    {
        if (wayPoints != null)
        {
            navTime += Time.deltaTime;
            if (navTime > navUpdate)
            {
                if (target < wayPoints.Length)
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, navTime);
                }
                else
                {
                    enemy.position = Vector2.MoveTowards(enemy.position, exitPoint.position, navTime);
                }
                navTime = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
            target += 1;
        else if (collision.CompareTag("Finish"))
        {
            GameManager.Instance.RemoveEnemyFromScreen();
            Destroy(gameObject);
        }
    }
}