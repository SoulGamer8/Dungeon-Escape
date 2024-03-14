using System.Collections;
using System.Collections.Generic;
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

    public void OpenShop(int gemCount){
        _playerGemCountText.text = gemCount.ToString() + "G";
    }

    public void SelecItem(){
        Debug.Log("Selected");
    } 
}
