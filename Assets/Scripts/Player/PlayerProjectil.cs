using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectil : MonoBehaviour
{
    [SerializeField]
    public float SpeedProjectil;
    private float TimeToFire = 0f;
    public Transform ProjectilPosition;
    public float Distance;
    public GameObject ProjectilPlayer;
    public float Rate;

    void Start()
    {
        GameManager.Instance.Attach(this);
    }
    public void Execute(ISubject subject)
    {
        if (subject is GameManager)
        {
            SpeedProjectil = ((GameManager)subject).Progression * 2;
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 targetPoint;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Rate))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Player")
                {
                    return;
                }
                else
                {
                    targetPoint = hit.point;
                }

            }
            else
            {
                targetPoint = ray.GetPoint(Distance);
            }

            GameObject bullet = Instantiate(ProjectilPlayer, ProjectilPosition.position, ProjectilPosition.rotation) as GameObject;
            Rigidbody bulletrb = bullet.GetComponent<Rigidbody>();
            Destroy(bullet, 0.5f);

            if (bulletrb != null)
            {
                Vector3 direction = (targetPoint - ProjectilPosition.position).normalized;
                bulletrb.velocity = direction * SpeedProjectil;
            }

            TimeToFire = Time.time + Rate;

        }

    }
}
