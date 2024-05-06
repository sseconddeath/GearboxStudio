using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuu : MonoBehaviour
{
    // Start is called before the first frame update
   public void menu()
    {
        SceneManager.LoadScene("_Menu");
        Time.timeScale = 1f;
    }

}
