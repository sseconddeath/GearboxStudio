using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject panel;
    public void nextgame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    // Update is called once per frame
    
}
