using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChandlerTesting : MonoBehaviour
{
    [SerializeField] private GameObject player;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.gameObject.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if (angle != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -angle);
        }
    }
}
