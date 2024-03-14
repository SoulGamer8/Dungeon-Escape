using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private Button _buyButton;

    [SerializeField] private GameObject _player;
    private int _selectidPrice;
    private int _selectidItem;

    private void Awake() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SelecItem(int index){
        switch(index){
            case 0:
                UIManager.Instance.UpdateShopSelection(-152);
                _selectidPrice = 200;
                CheackGem(200);
                _selectidItem= index;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-202);
                _selectidPrice = 200;
                CheackGem(200);
                _selectidItem= index;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-252);
                _selectidPrice = 200;
                CheackGem(200);
                _selectidItem = index;
                break;
        }
    } 

    private void CheackGem(int price){
        if(_player.GetComponent<Score>().GetScore() < price)
            _buyButton.interactable = false;
        else
            _buyButton.interactable = true;
    }

    public void BuyItem(){
        _player.GetComponent<Score>().AddScore(-_selectidPrice);
        if(_selectidItem == 2)
            GameManager.Instance.isHasKeyFromCastle = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            shopPanel.SetActive(true);
        Score score = other.GetComponent<Score>();
        if(score != null)
            UIManager.Instance.OpenShop(score.GetScore());
    }

    private void UpdateUI(){

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            shopPanel.SetActive(false);
    }
}
