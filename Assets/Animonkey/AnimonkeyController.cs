using System;
using UnityEngine;

namespace Animonkey.Animonkey
{
    [RequireComponent(typeof(Animator))]
    public abstract class AnimonkeyController : MonoBehaviour, IAnimonkeyController
    {
        public Animonkey animonkey;
        private Animator animator;
        
        public virtual void Initialize()
        {
            animator = GetComponent<Animator>();
            animonkey = new Animonkey(gameObject, animator);
        }
        
        public void Disable()
        {
            animonkey.Disable();
        }

        private void OnDisable()
        {
            Disable();
        }
    }
}
