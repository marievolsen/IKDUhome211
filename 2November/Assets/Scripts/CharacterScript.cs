using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    //Code from LEARN UNITY - The Most BASIC TUTORIAL I'll ever make, Imphenzia, Youtube
    /// I named my character Gurli
    
    [SerializeField] private Transform groundCheckTransfrom;
    public string FirstName = "Gurli";
    private int GurliLevel = 1;
    private bool Hop;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    

    void Start()
    {
        /// Gurli's initial level is one, the name Gurli and level is called when game is started
        Debug.Log(Calling(FirstName, GurliLevel));
        rigidbodyComponent = GetComponent<Rigidbody>();

    }

    private int Calling(string name, int lvl)
    {
        Debug.Log(name);
        Debug.Log(lvl);
        return lvl;
    }

    void Update()
    {
        /// To see if jump/space is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
            /// When Hop is true, the character jumps
            Hop = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(groundCheckTransfrom.position, 0.1f).Length == 0)
        {
            return;
        }

        if (Hop)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            
            /// Hop = false, stops the character from jumping into the universe, stopping the action when key is no longer pressed
            Hop = false;
        }

        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            /// Destroys the coin when collided with
            Destroy(other.gameObject);

            Debug.Log(FirstName + - (GurliLevel + 1));
        }
    }

}
