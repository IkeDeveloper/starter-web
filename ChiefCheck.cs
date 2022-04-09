using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChiefCheck : MonoBehaviour
{
    Animator anim02;
    public AudioSource chiefrage;
    void Start()
    {
      anim02 = gameObject.GetComponent<Animator>();
      
    }
    void Update()
    {

        //if berry aproaches Chief, activate Rgae animation
        if (SceneController.AlmostEqual(SceneController.ChiefTransform.position, SceneController.PlayerTransform.position, 5.0f))
        {
            if (!chiefrage.isPlaying)
            {
                chiefrage.Play();
            }
            anim02.SetBool("IsRage", true);
            anim02.SetBool("IsIdle", false);
        }

        if (!SceneController.AlmostEqual(SceneController.ChiefTransform.position, SceneController.PlayerTransform.position, 5.0f))
        {
            
            anim02.SetBool("IsRage", false);
            anim02.SetBool("IsIdle", true);
        }

        //if all ground cartons are eaten, destroy GuardMayan
        if (SceneController.groundcartonsCollected)
        {
            Destroy(this.gameObject);
        }
    }
}
