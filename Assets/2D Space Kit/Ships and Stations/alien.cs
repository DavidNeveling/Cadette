using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    // Start is called before the first frame update
    protected float speed;
    protected bool aggressive;
    protected GameObject player;

    void Start()
    {
        speed = 0.25f;
        aggressive = false;
        player = GameObject.Find("Fighter 4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
