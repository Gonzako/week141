using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Collectible : MonoBehaviour
{
    [SerializeField] private Sprite _collectableSprite;
    [SerializeField] private string _name;

      
    [SerializeField] private GameEvent _onCollectedEvent = default(GameEvent);
    [SerializeField] private IntReference _collectablesAmount = default(IntReference);
    
    private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player"){
           _onCollectedEvent.Raise();
           _collectablesAmount.Value += 1;
       }
    } 
}
