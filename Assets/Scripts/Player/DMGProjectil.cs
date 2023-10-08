using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGProjectil : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyVD>().TakeHit(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 4f);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
}
