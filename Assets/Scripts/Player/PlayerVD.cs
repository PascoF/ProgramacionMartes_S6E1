using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerVD : MonoBehaviour
{
    public float PointVD;
    public float VDMax = 5;

    public Slider SliderVD;

    void Start()
    {
        PointVD = VDMax;
    }


    public void TakeHit(int damage)
    {
        PointVD -= damage;

    }

    void Update()
    {
        SliderVD.value = PointVD;

        if (this.PointVD <= 0f)
        {
            SceneManager.LoadScene(2);
        }

    }
}
