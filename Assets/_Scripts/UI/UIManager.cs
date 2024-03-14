using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get; private set;}

    private void Awake() {
        if (Instance != null && Instance != this) { 
            Destroy(this); 
            Debug.LogError("UIManager is more than one!");
        } 
        else 
            Instance = this; 
    }

    [SerializeField] private TMP_Text _playerGemCountText;
    [SerializeField] private Image _selectionImage; 

    [SerializeField] private TMP_Text _gemCountText;


    public void OpenShop(int gemCount){
        _playerGemCountText.text = gemCount.ToString() + "G";
    }

    public void UpdateShopSelection(int yPos){
        _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x,yPos);
    }

    public void UpdateGemCount(int gems){
        _gemCountText.text = gems.ToString() + "G";
    }

}
