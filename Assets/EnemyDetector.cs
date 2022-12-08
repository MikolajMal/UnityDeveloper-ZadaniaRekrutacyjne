using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    Collider2D[] enemies;
    public float playerDetectionRange = 1f;

    // Update is called once per frame
    void Update()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, playerDetectionRange);

        if(enemies.Length > 0)
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.CompareTag("Player") && !enemy.CompareTag("CapturedEnemy"))
                {
                    enemy.gameObject.GetComponent<EnemyMovement>().MoveEnemy(transform.position);
                }
                //enemy.gameObject.SetActive(false);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, playerDetectionRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CapturedEnemy");
        this.gameObject.tag = "CapturedEnemy";
    }
}
