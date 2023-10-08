using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGEnemProjectil : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerVD>().TakeHit(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2f);
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
