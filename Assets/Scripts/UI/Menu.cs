using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
