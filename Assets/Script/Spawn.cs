using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{

    [SerializeField] GameObject[] Prefabs;
    [SerializeField] Transform player;
    Vector3 pos;
    List<GameObject> AddedPrefabs;
    GameObject curPrefab;
    float temp=0;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(player.position.x, player.position.y-0.5f, player.position.z+6 );
        AddedPrefabs = new List<GameObject>();
        for (int i = 0; i < 25; i++)
        {
            SetPrefabActive();
        }
    }

    // Update is called once per frame
    void Update()
    {
        temp = player.position.z - AddedPrefabs[0].transform.position.z;
        if (temp > 12)
        {
            SetPrefabUnactive(AddedPrefabs[0]);
        }

        temp =(int) (AddedPrefabs.Count / 4);

        if (player.position.z > AddedPrefabs[(int)temp].transform.position.z)
        {
            SetPrefabActive();
        }


    }
        

    void SetPrefabActive()
    {

            curPrefab = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], pos, Quaternion.identity);
            curPrefab.SetActive(true);
            AddedPrefabs.Add(curPrefab);
            pos.z = pos.z + 2;
        
       
    }

    void SetPrefabUnactive(GameObject prefab)
    {
        Destroy(prefab);
        AddedPrefabs.RemoveAt(0);
    }





}
