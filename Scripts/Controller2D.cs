using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GameType { SideScroller, Topdown}
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Controller2D : MonoBehaviour
{
    
    [SerializeField] private GameType type;
    [SerializeField]private bool hasGravity;
    [SerializeField]private float gravityValue;
    [SerializeField] private bool canJump;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float horizontalSpeed;



    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case GameType.SideScroller:
                break;
            case GameType.Topdown:
                hasGravity = false;
                canJump = false;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            Debug.Log(horizontal);
            transform.position += new Vector3(horizontal * horizontalSpeed * Time.deltaTime, vertical * verticalSpeed * Time.deltaTime,0);
        }
    }
}
