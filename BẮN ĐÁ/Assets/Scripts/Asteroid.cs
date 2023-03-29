using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public List<Sprite> _listsprite;
    private Rigidbody2D _rigid;
    private SpriteRenderer _sprite;

    public float sizenum = 2;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _sprite.sprite = _listsprite[Random.Range(0, _listsprite.Count)];
        this.transform.eulerAngles = new Vector3(0, 0, Random.value * 360);

        this.transform.localScale = Vector3.one*sizenum ;
       _rigid.mass *= sizenum;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Move(Vector2 direction)
    {
        _rigid.AddForce(direction*0.25f,ForceMode2D.Impulse);
        Destroy(this.gameObject, 30.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            if (this.sizenum > 1)
            {
                CreateSplit();
                CreateSplit();
            }
        }    
        Destroy(gameObject);
        FindObjectOfType<GameManager>().AsteroidEXploding(this.gameObject);
    }
    private void CreateSplit() 
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Asteroid half = Instantiate(this, position,this.transform.rotation);
        half.sizenum = this.sizenum / 2;
        half.Move(Random.insideUnitCircle.normalized*Random.Range(2,4));

    }
}
