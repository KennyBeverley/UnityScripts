using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject firePoint;
    [SerializeField]private bool targetCursor;    
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (targetCursor)
            {
                var clone = Instantiate(projectile, firePoint.transform.position, gun.transform.rotation);
                Destroy(clone, 2);
            }
            else
            {

            }
            
        }
    }
}
