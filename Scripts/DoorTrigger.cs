using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoorTrigger : MonoBehaviour
{    
    private Animation _animation;

    private void Start() 
    {
        _animation = GetComponentInChildren<Animation>();         
    }

     private void OnTriggerEnter(Collider collision) 
     {         
         if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))         
             Animate("DoorOpen");
     }

    private void OnTriggerExit(Collider collision) 
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))        
            Animate("DoorClose"); 
    }

    private void Animate(string name) 
    {
        if (_animation.isPlaying == false)       
            _animation.Play(name);        
    }
}
