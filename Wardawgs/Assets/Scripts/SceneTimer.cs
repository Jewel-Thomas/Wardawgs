using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTimer : MonoBehaviour
{
    public string levelToLoad;
    private float timer;
    private Text timerseconds;

    // Start is called before the first frame update
    void Start()
    {
        timerseconds = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerseconds.text = timer.ToString("f2");
        if (timer < 0)
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}
