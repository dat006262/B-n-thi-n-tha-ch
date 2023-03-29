using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public GameObject Asteroidprefabs;
    public int count_asteroid=1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn),5,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn() 
    {
        for(int i=0; i<= 1;i++)
        {
            Vector3 huongtam_random = Random.insideUnitCircle.normalized *15;
            Vector3 noi_sinh_san = this.transform.position + huongtam_random;

            float var = Random.Range(-15.0f, 15.0f);
            Quaternion rotation = Quaternion.AngleAxis(var, Vector3.forward);

            GameObject asteroid = Instantiate(Asteroidprefabs, noi_sinh_san, rotation);
            asteroid.GetComponent<Asteroid>().sizenum = Random.Range(0.5f, 1.5f);

            asteroid.GetComponent<Asteroid>().Move(rotation * -huongtam_random);
        }    
    }
}
