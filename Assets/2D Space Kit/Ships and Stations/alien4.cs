using System.Collections;
using System.Collections.Generic;
using SD = System.Diagnostics;
using UnityEngine;

public class alien4 : alien
{
    SD.Stopwatch sw;
    float modifier;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Fighter 4");
        speed = 0.25f;
        modifier = 0.03f;
        sw = new SD.Stopwatch();
        sw.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (aggressive) {
            Vector3 newPos = player.transform.position - transform.position;
            newPos.Normalize();
            transform.rotation = Quaternion.LookRotation(Vector3.forward, newPos);
            newPos *= Time.deltaTime * speed;
            transform.position += newPos;
        }
        else {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * speed, transform.position.z);
            if (sw.Elapsed.TotalSeconds > 0.25f) {
                float rand = Random.Range(0f, 1f);
                if (rand < modifier) {
                    aggressive = true;
                    speed = 3f;
                }
                sw.Reset();
                sw.Start();
            }
        }
    }
}
