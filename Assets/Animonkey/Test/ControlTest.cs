using System;
using UnityEngine;

namespace Animonkey.Animonkey.Test
{
    public class ControlTest : AnimonkeyController
    {
        public AnimationClip clip;
        private void Awake()
        {
            Initialize();
            animonkey.Play(clip);
        }
    }
}
