/*
 * This command allows player to jump up once in a height of 5 when user have
 * input "Fire2". The structure is similar to MoveCharacterLeft Command. 
 * First we set the jump height as 5, then we get the rigidbody of the Captin.
 * When the rigidbody exists, we change the number in its x axis to the jump height.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Captain.Command;

namespace Captain.Command
{
    public class CharacterJump : ScriptableObject, ICaptainCommand
    {
        private float jumpHeight = 5.0f;
    
        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            }
        }
    }
}


