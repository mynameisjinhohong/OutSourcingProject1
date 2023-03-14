using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn_CSH : MonoBehaviour
{
    public GameObject rangeObject;
    BoxCollider rangeCollider;
    public GameObject enemyFactory1;
    float spawnTime = 0;
    public float balanceTime = 30;
    public float protoSpawnTime;
    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = rangeCollider.bounds.size.x;
        float range_Y = rangeCollider.bounds.size.y;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Y = Random.Range((range_Y / 2) * -1, range_Y / 2);
        Vector3 RandomPostion = new Vector3(range_X, range_Y, -0.5f);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    IEnumerator RandomRespawn_Coroutine()
    {

        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(1.5f);
            Summon();
        }
    }

    public void Summon()
    {
        GameObject enemy1 = Instantiate(enemyFactory1, Return_RandomPosition(), Quaternion.identity);
    }
}
