using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;

    public float fireRate;
    private float currentAttackTimer;
    bool isAtaque;

    public float speed;
    Rigidbody2D rb2D;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent <Rigidbody2D>();
        currentAttackTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Disparar();
        Movimiento();
    }

    void Movimiento()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(dirX * speed, rb2D.velocity.y);

        float dirY = Input.GetAxisRaw("Vertical");
        rb2D.velocity = new Vector2(rb2D.velocity.x, dirY * speed);
    }

    void Disparar()
    {
        fireRate += Time.deltaTime;
        if(fireRate > currentAttackTimer)
        {
            isAtaque = true;
        }

         if (Input.GetKeyDown(KeyCode.Space) && isAtaque == true)
        {
            isAtaque = false;
            fireRate = 0f;
            Instantiate(Bullet,firePoint.position, Quaternion.identity);
            AudioManager.instance.PlaySFX(2);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("obstaculo"))
        {
            AudioManager.instance.PlaySFX(8);
            gameManager.GameOver();
        }
        
    }
}
