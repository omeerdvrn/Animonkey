using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animonkey.Animonkey
{
    [System.Serializable]
    public struct AnimonkeyAnimation
    {
        public AnimationClip AnimationClip;
        [HideInInspector]public readonly AnimationClipPlayable PlayableClip;
        
        public AnimonkeyAnimation(AnimationClip AnimationClip, PlayableGraph graph)
        {
            this.AnimationClip = AnimationClip;
            PlayableClip = AnimationClipPlayable.Create(graph, AnimationClip);
        }
    }
}
