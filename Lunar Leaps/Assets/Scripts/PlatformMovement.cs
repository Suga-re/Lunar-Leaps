using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementSpeed = 0;
    public float deadZone = -30;
    // Start is called before the first frame update
    void Start()
    {
        if (movementSpeed == 0){
            movementSpeed = 1;
        }
        
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
}
