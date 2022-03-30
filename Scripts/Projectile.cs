using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private LayerMask impactLayers;
    public float speed;
    private Vector3 dir;
    private Vector3 velocity;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collison with " + collision.gameObject.layer + " compared to " + impactLayers + " or " + impactLayers.value);        
        if ((impactLayers.value &(1 << collision.gameObject.layer)) > 0)
        {
            Destroy(gameObject);
        }
    }
}
