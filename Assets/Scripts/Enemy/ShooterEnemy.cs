using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour, IObserver
{
    [SerializeField]
    private float ImpuseProjectil;
    public Transform player;
    public float ProjectilRange = 100f;
    private bool OnRange = false;
    public Rigidbody projectile;

    void Start()
    {
        GameManager.Instance.Attach(this);

        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    void Shoot()
    {
        if (OnRange)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * ImpuseProjectil, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
        }
    }

    public void Execute(ISubject subject)
    {
        if (subject is GameManager)
        {
            ImpuseProjectil = ((GameManager)subject).Progression;
        }
    }

    void Update()
    {
        OnRange = Vector3.Distance(transform.position, player.position) < ProjectilRange;
        if (OnRange)
            transform.LookAt(player);
    }
}
