using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timer = 0;
    public TextMeshProUGUI texTime;

    void Start()
    {

    }

    void Update()
    {
        timer -= Time.deltaTime;
        texTime.text = "" + timer.ToString("f1");

        if (timer < 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
