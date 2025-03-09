using UnityEngine;

public class SimpleAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool animationInProgress = false;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetInteger("AnimationID", 1);
            animationInProgress = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetInteger("AnimationID", 2);
            animationInProgress = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetInteger("AnimationID", 3);
            animationInProgress = true;
        }

        // Check if animation should return to idle
        if (animationInProgress)
        {
            SetIDToZero();
        }
    }

    public void SetIDToZero()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        int currentID = animator.GetInteger("AnimationID");

        // Only check for completion if we're not already in idle state (ID != 0)
        if (currentID != 0 && stateInfo.normalizedTime >= 0.95f)
        {
            animator.SetInteger("AnimationID", 0);
            animationInProgress = false;
            Debug.Log("Animation completed - returning to idle");
        }
    }
}
