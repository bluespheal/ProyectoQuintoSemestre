using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWarp : MonoBehaviour
{
    public SceneChanger sceneChanger;
    public string levelToWarpTo;

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerController>().Fade();
        sceneChanger.ChangeLevel(levelToWarpTo);
    }
}
