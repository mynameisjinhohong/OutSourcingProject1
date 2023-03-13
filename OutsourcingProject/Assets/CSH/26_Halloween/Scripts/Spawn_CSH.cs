using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_CSH : MonoBehaviour
{

    public GameObject rangeObject;
    BoxCollider rangeCollider;
    public GameObject enemyFactory1;
    public int spawnNum;
    float spawnTime=0;
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
        // �ݶ��̴��� ����� �������� bound.size ���
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
        
        for (int i = 0; i < 1000; i++)
        {
            spawnTime++;
            if (spawnTime < balanceTime)
            {
                yield return new WaitForSeconds(protoSpawnTime);
            }
            else
            {
                //�ð� ��ʷ� �ֱⰡ ���������Ѵ�.
                yield return new WaitForSeconds(balanceTime / spawnTime);
            }
            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            GameObject enemy1 = Instantiate(enemyFactory1, Return_RandomPosition(), Quaternion.identity);
            //���� ���� ���
            if (GameObject.Find("HalloweenCanvas") == true)
            {
                GameObject.Find("HalloweenCanvas").GetComponent<HalloweenManager_CSH>().remains++;
            }
            else if(GameObject.Find("AlienCanvas") == true)
            {

            }
        }
    }
}
