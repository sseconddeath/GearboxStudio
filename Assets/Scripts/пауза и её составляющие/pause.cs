using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public void ppause()
    { panel.SetActive(false); 
      Time.timeScale = 0;
    }
}
