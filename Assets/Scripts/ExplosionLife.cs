using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLife : MonoBehaviour
{
    private float _timeToChange = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeToChange -= Time.deltaTime;

        if (_timeToChange < 0)
        {
            Destroy(gameObject);
        }
    }
}
