using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeleteCountDown : MonoBehaviour
{
    [SerializeField] float deleteHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= deleteHeight)
        {
            Destroy(this.gameObject);
        }
    }
}
