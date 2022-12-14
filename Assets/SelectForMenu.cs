using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectForMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Title");
        }
    }
}
