using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceForMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Title");
        }
    }
}
