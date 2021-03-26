using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKs : MonoBehaviour
{
    Animator anim;
    public Transform objMirar;
    public Transform baston;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if(objMirar != null)
        {
            anim.SetLookAtWeight(1f);//yo controlo en su totalidad la cabeza
            anim.SetLookAtPosition(objMirar.position);
        }
        else
        {
            anim.SetLookAtWeight(0f);
        }
        if (baston != null)
        {
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);//yo controlo en su totalidad la rotacion del brazo derecho
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);//yo controlo en su totalidad la rotacion del brazo derecho
            anim.SetIKPosition(AvatarIKGoal.RightHand, baston.position);
            anim.SetIKRotation(AvatarIKGoal.RightHand, baston.rotation);
        }
        else
        {
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
        }
    }
}
