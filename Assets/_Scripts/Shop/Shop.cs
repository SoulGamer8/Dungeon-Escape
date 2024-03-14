using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            shopPanel.SetActive(true);
        Score score = other.GetComponent<Score>();
        if(score != null)
            UIManager.Instance.OpenShop(score.GetScore());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            shopPanel.SetActive(false);
    }
}
