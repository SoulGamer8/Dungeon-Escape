using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}

    private void Awake() {
        if (Instance != null && Instance != this) { 
            Destroy(this); 
            Debug.LogError("GameManager is more than one!");
        } 
        else 
            Instance = this; 
    }


    public bool isHasKeyFromCastle = false;  

}
