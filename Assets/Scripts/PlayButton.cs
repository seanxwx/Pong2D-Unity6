using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   public void PlayGame()
    {
        Debug.Log("Playgame was pressed");
        SceneManager.LoadScene("Game");
    }
}
