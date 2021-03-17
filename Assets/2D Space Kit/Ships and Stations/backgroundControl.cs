using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundControl : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Transform> childrenColliders;
    private float height;
    void Start()
    {
        childrenColliders = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            if (child != null)
                childrenColliders.Add(child);
        }
        height = childrenColliders[0].gameObject.GetComponent<BoxCollider2D>().bounds.size.y;
        for (int i = -1; i <= 1; i++)
        {
            childrenColliders[i + 1].gameObject.transform.position = new Vector3(0, height * i, 0);
            childrenColliders[i + 1].gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "background";
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < childrenColliders.Count; i++)
        {
            Vector3 pos = childrenColliders[i].gameObject.transform.position;
            childrenColliders[i].gameObject.transform.position = new Vector3(pos.x, pos.y - 3f * Time.deltaTime, pos.z);
        }
        for (int i = 0; i < childrenColliders.Count; i++)
        {
            if (childrenColliders[i].gameObject.transform.position.y < -height) {
                float top = childrenColliders[0].gameObject.transform.position.y;
                for (int j = 1; j < childrenColliders.Count; j++)
                {
                    if (childrenColliders[j].gameObject.transform.position.y > top) {
                        top = childrenColliders[j].gameObject.transform.position.y;
                    }
                }
                childrenColliders[i].gameObject.transform.position = new Vector3(0, height + top - 3f, 0);
                
            }
        }
    }
}
