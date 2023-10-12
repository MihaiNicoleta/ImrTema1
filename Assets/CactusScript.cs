using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    public GameObject cactusImageTarget; // The cactus image target
    private Animator cactusAnimator; // The animator for the cactus
    private float distance = 0f;

    void Start()
    {
        cactusAnimator = GetComponent<Animator>();
    }

    bool IsAnimatorPlaying()
    {
        AnimatorStateInfo stateInfo = cactusAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Attack") && stateInfo.normalizedTime < 1.0f)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if (IsAnimatorPlaying())
        {
            return;
        }
        distance = Vector3.Distance(cactusImageTarget.transform.position, transform.position);
        if (distance < 0.1f)
        {
            if (cactusAnimator != null)
            {
                cactusAnimator.Play("Base Layer.Attack", 0, 0f);
                Debug.Log("Attack " + distance);
            }
        }
        else
        {
            if (cactusAnimator != null)
            {
                cactusAnimator.Play("Base Layer.Idle", 0, 0);
                Debug.Log("Away " + distance);
            }
        }
    }
}
