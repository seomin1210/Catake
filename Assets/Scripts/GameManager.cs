using UnityEngine;

class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}