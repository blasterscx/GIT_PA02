using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] SpawnObject;
    private int random;
    float PositionX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {



    }

    void SpawnObjects()
    {
        PositionX = Random.Range(4, -4f);
        this.transform.position = new Vector3(PositionX, transform.position.y, transform.position.z);
        random = Random.Range(0, 4 );
        Instantiate(SpawnObject[random], transform.position, transform.rotation);
    }
}
