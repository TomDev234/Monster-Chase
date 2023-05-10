using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject[] monsters;
    [SerializeField] Transform leftSpawnTransform, rightSpawnTransform;
    GameObject spawnedMonster;
    int randomIndex;
    int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            randomIndex = Random.Range(0, monsters.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsters[randomIndex]);
            if (randomSide == 0)
            {
                spawnedMonster.transform.position = leftSpawnTransform.position;
                spawnedMonster.GetComponent<MonsterBehaviourScript>().speed = Random.Range(4, 8);
            }
            else
            {
                spawnedMonster.transform.position = rightSpawnTransform.position;
                spawnedMonster.GetComponent<MonsterBehaviourScript>().speed = -Random.Range(4, 8);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
