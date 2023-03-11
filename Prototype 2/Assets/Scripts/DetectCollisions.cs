using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // On collision with another object, destroy both
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject);
        }
        else if (!other.gameObject.name.Equals("DestroyPlane"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
