using UnityEngine;
using System.Collections;

public class RemoveColliderCollision : MonoBehaviour {

    CharacterController controller;

    // Prevent the character controller of this asset to collide with other colliders/character controllers
    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = false;
    }
}
