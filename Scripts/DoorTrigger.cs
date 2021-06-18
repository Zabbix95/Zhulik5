using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoorTrigger : MonoBehaviour
{    
    private Animation _animation;
    private const string _animDoorOpen = "DoorOpen";
    private const string _animDoorClose = "DoorClose";

    private void Start() 
    {
        _animation = GetComponentInChildren<Animation>();         
    }

     private void OnTriggerEnter(Collider collision) 
     {         
         if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))         
             Animate(_animDoorOpen);
     }

    private void OnTriggerExit(Collider collision) 
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))        
            Animate(_animDoorClose); 
    }

    private void Animate(string name) 
    {
        if (_animation.isPlaying == false)       
            _animation.Play(name);        
    }
}
