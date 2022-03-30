using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    Vector3 dir;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(gameObject.transform.position);
        velocity = Vector3.Normalize(dir - transform.position) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;
        //transform.position += dir * speed * Time.deltaTime;
    }
}
