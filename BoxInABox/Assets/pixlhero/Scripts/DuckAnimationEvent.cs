using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAnimationEvent : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;

    public void StepLeft(){
        TriggerParticleSystem(true);
    }

    public void StepRight(){
        TriggerParticleSystem(false);
    }

    private void TriggerParticleSystem(bool left){
        particles.transform.parent.localScale = new Vector3(left ? -1 : 1, 1, 1);
        particles.Play();
    }
}
