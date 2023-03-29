using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletprefabs;
    private Rigidbody2D _rigid;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float updown = Input.GetAxis("Vertical");
        float leftright = Input.GetAxis("Horizontal");
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
        _rigid.AddForce(this.transform.up*updown  *1 );
        _rigid.AddTorque(-leftright * 0.1f);
    }
    void Shoot() 
    {
        GameObject bullet = Instantiate(this.bulletprefabs, this.transform.position+this.transform.up*0.5f, this.transform.rotation);
        bullet.GetComponent<Buleet>().fly(this.transform.up);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Astor"))
        {
            _rigid.velocity = Vector3.zero;
            _rigid.angularVelocity = 0;
            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().PlayerDie();
        }    
    }

}
