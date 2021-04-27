using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWarp : MonoBehaviour
{
    public SceneChanger sceneChanger; //Scene change manager
    public string levelToWarpTo; // Scene to warp to

    void OnCollisionEnter(Collision collision) //If player enters the collision, it warps to the designated scene.
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Fade();
            sceneChanger.ChangeLevel(levelToWarpTo);
        }
    }
}
