using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrange : MonoBehaviour
{
    // Start is called before the first frame update

    EdgeCollider2D cam;
    float speed;
    void Start()
    {
        speed = 0.25f;
        cam = Camera.main.gameObject.GetComponent<EdgeCollider2D>();

        //temporary
        //
        GameObject alien = null;
        for (int i = 0; i < transform.childCount; i++) {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.gameObject.name.Equals("Alien 4"))
                alien = child;
        }
        float screenLength = cam.points[2].x - cam.points[0].x;
        float numAliens = 10f;
        // this with go in its own method maybe even become procedural at some point
        for (int i = 0; i < numAliens; i++) {
            GameObject alienToAdd = Instantiate(alien, transform) as GameObject;
            alienToAdd.SetActive(true);
            alienToAdd.transform.position = new Vector3(cam.points[0].x + screenLength / 10 + (i / numAliens) * (9 * screenLength / 10), cam.points[2].y - 2f, 0);
            // alienToAdd.transform.localScale = missile.transform.localScale * 3;

        }
        //
    }

    // Update is called once per frame
    void Update()
    {
        // foreach (GameObject a in aliens) {
        //     if (a != null) {
        //         a.transform.position = new Vector3(a.transform.position.x, a.transform.position.y - Time.deltaTime * speed, a.transform.position.z);
        //     }
        //     // if (a.transform.position.y < cam.points[0].y) {
        //     //     Destroy(gameObject);
        //     // }
        // }
        
    }
}
