using System.Collections;
using System.Collections.Generic;
using SD = System.Diagnostics;
using UnityEngine;

public class shipControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private float shotSpeed;
    private SD.Stopwatch sw;
    EdgeCollider2D cam;
    void Start()
    {
        speed = 5f;
        shotSpeed = 0.25f;
        sw = new SD.Stopwatch();
        sw.Start();
        cam = Camera.main.gameObject.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // fire missile
        if (Input.GetKey ("space")) {
            if (sw.Elapsed.TotalSeconds > shotSpeed) {
                GameObject missile = Instantiate(transform.GetChild(0).gameObject) as GameObject;
                missile.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                missile.transform.localScale = missile.transform.localScale * 3;
                missile.SetActive(true);
                sw.Reset();
                sw.Start();
            }     
        }

        // toggle boost
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            speed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = 10f;
        }

        // Update Position
        Vector3 pos = new Vector3(0, 0, 0);
        if (Input.GetKey ("w") | Input.GetKey("up")) {
            pos.y += Time.deltaTime;
        }
        if (Input.GetKey ("s") | Input.GetKey("down")) {
            pos.y -= Time.deltaTime;
        }
        if (Input.GetKey ("d") | Input.GetKey("right")) {
            pos.x += Time.deltaTime;
        }
        if (Input.GetKey ("a") | Input.GetKey("left")) {
            pos.x -= Time.deltaTime;
        }

        pos.Normalize();
        pos *= Time.deltaTime * speed;

        // adjust position update for screen collision
        if (transform.position.x < cam.points[0].x) {
            pos.x += Time.deltaTime * speed;
        }
        if (transform.position.x > cam.points[2].x) {
            pos.x -= Time.deltaTime * speed;
        }
        if (transform.position.y < cam.points[0].y) {
            pos.y += Time.deltaTime * speed;
        }
        if (transform.position.y > cam.points[0].y + (cam.points[2].y - cam.points[0].y) / 3) {
            pos.y -= Time.deltaTime * speed;
        }

        transform.position = transform.position + pos;
    }

    // void OnCollionEnter(Collision collision) {
    //     if (collision.gameObject.name == "Main Camera")
    //     {
    //         //If the GameObject's name matches the one you suggest, output this message in the console
    //         Debug.Log("Do something here");
    //     }
    //     Debug.Log("Do something here");
    // }
}
