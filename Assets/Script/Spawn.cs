using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] GameObject[] Prefabs;
    [SerializeField] Transform player;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(player.position.x, player.position.y, player.position.z + 10);
        GameObject Obstacle = Prefabs[Random.Range(0, Prefabs.Length)];
        Instantiate(Obstacle,pos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
