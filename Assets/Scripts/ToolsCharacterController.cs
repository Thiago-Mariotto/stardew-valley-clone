using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rigidbody;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

   void Awake ()
   {
        character = GetComponent<CharacterController2D>();
        rigidbody = GetComponent<Rigidbody2D>();
   }

   private void Update ()
   {
        if(Input.GetMouseButtonDown(0))
        {
            UseTool(); 
        }
   }

   private void UseTool()
   {
        Vector2 position = rigidbody.position + character.lastMotionVector * offsetDistance;
        
		Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
		Debug.Log(colliders);
        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
        }
   }
}
