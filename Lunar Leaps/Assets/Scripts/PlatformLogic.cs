using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLogic : MonoBehaviour
{
    public float movementSpeed = 0;
    public float deadZone = -30;
    public bool isLit = false;
    public LogicManager logic;
    private PlayerMovement player;
    private GameObject ground;
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (movementSpeed == 0){
            movementSpeed = 1;
        }
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        ground = GameObject.FindGameObjectWithTag("ground");

        
        spriteRenderer = GetComponent<SpriteRenderer>();
        int newSpriteLoc = Random.Range(0,sprites.Count-1);
        spriteRenderer.sprite = sprites[newSpriteLoc];



    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        if (transform.position.y < deadZone)
        {
            tag = "destroyed";
            Debug.Log("Platform Deleted");

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "destroyed")
        {
            if (collision.gameObject.layer == 3 && isLit == false)
            {
                Debug.Log("add score");
                isLit = true;
                spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
                logic.addScore(1, player.checkIfAlive());
                if(ground!= null)
                {
                    ground.SetActive(false);
                }
                
            }
        }

    }
}
