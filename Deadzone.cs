using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    //respawn point gameobject
    [SerializeField]
    private GameObject respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.LoseLives();
            }

            CharacterController cc = other.GetComponent<CharacterController>();

            if( cc != null)
            {
                cc.enabled = false;
            }
             
            //resetting player position after collision with respawn collison
            other.transform.position = respawnPoint.transform.position;

            StartCoroutine(CCEnableRoutine(cc));
            
        }
    }

    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);

        controller.enabled = true;
    }
}
