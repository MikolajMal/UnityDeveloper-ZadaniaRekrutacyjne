using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int enemyAmount = 1000;
    public GameObject enmyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            Instantiate(enmyPrefab);
        }
    }
}
