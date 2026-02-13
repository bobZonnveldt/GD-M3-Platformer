using UnityEngine;

public class Restartgame : MonoBehaviour
{
    public void loadcurrentscene()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}

