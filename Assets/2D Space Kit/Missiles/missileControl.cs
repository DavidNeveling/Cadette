using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    EdgeCollider2D cam;
    void Start()
    {
        speed = 10f;
        cam = Camera.main.gameObject.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) {
            // position update unless off screen
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * speed, transform.position.z);
            if (transform.position.y > cam.points[2].y) {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        try {
            // if hitting an alien, kill the alien and get rid of the missle
            if (collision.gameObject.transform.parent.gameObject.name.Equals("Aliens")) {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        catch (System.Exception e){}
    }
}
