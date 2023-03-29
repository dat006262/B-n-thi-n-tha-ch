using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buleet : MonoBehaviour
{
    Rigidbody2D _rigid;
    float maxlife = 5.0f;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fly(Vector2 direction)
    {
        _rigid.AddForce(direction*500);
        Destroy(this.gameObject, this.maxlife);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
