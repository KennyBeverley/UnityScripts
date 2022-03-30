using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private int hp;
    private ImpactQueue impactQueue;
    // Start is called before the first frame update
    void Start()
    {
        impactQueue = GetComponent<ImpactQueue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (impactQueue.hasInpacts)
        {
            RecieveImpact((int)impactQueue.DequeImpact());
        }
    }

    private void RecieveImpact(int damage)
    {
        Debug.Log(damage);
    }
}
