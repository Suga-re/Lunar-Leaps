using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementSpeed = 0;
    public float deadZone = -30;
    public bool isLit = false;
    public LogicManager logic;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        if (movementSpeed == 0){
            movementSpeed = 1;
        }
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<LogicManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        if (transform.position.y < deadZone)
        {
            Debug.Log("Platform Deleted");

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3 && isLit == false)
        {
            Debug.Log("add score");
            isLit = true;
            logic.addScore(1, player.checkIfAlive());
        }
    }
}
