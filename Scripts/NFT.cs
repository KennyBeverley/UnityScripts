using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NFTState { seek, launch}
public class NFT : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float launchSpeed;
    [SerializeField] private int hp;
    private Transform playerTransform;
    private Vector3 velocity;
    private ImpactQueue impactQueue;
    private NFTState state;
    

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        impactQueue = GetComponent<ImpactQueue>();
        velocity = GameTools.SetVelocity(playerTransform.position, transform.position, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case NFTState.seek:
                velocity = GameTools.SetVelocity(playerTransform.position, transform.position, speed);
                GameTools.FaceTarget(transform, playerTransform);
                if (Vector2.Distance(transform.position, playerTransform.position) < 5)
                {
                    velocity = GameTools.SetVelocity(playerTransform.position, transform.position, launchSpeed);
                    state = NFTState.launch;
                }
                break;
            case NFTState.launch:
                if (Vector2.Distance(transform.position, playerTransform.position) > 10)
                {
                    state = NFTState.seek;
                }
                break;
        }
        if (impactQueue.hasInpacts)
            TakeDamage((int)impactQueue.DequeImpact());
        
    }

    private void FixedUpdate()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<ImpactQueue>() != null)
            {
                collision.gameObject.GetComponent<ImpactQueue>().QueueImpact(5);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        if(hp - damage <= 0)
        {
            Die();
        }
        else
        {
            hp -= damage;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
