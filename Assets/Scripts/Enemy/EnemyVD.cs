using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVD : MonoBehaviour
{
    public float VDPoint;
    public float VDMax = 5;

    void Start()
    {
        VDPoint = VDMax;
    }

    public void TakeHit(float damage)
    {
        VDPoint -= damage;

        if (VDPoint <= 0)
        {
            Destroy(gameObject);
        }
    }
}
