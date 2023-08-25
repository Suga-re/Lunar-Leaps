using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject ground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ground.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }
}
