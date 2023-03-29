using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int lives=3;
    public ParticleSystem exploding;
    public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   public void AsteroidEXploding(GameObject asterioid)
    {
        exploding.transform.position = asterioid.transform.position;
        exploding.Play();
        if (asterioid.GetComponent<Asteroid>().sizenum > 1)
        {
            this.score += 5;
        }
        else this.score += 2;
    }
    public void PlayerDie() 
    {
        //new = Instantiate(exploding, player.transform.position, exploding.transform.rotation);
        exploding.Play();
        lives--;
        if(this.lives<=0)
        {
            GameOver();
        }    
        else
        Invoke(nameof(Respawn), 1);

    }
    void Respawn() 
    {
        this.player.transform.position = Vector2.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Cannot Die");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(CanDie), 3);
    }
    void CanDie() {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    void GameOver() 
    {
        this.lives = 3;
        this.score = 0;
        Invoke(nameof(Respawn), 1);
    }
}
