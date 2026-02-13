using UnityEngine;

public class End : MonoBehaviour
{
  public GameObject WinUI;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            WinUI.SetActive(true);
        }
    }
}
