using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Animonkey.Animonkey
{
    public class Animonkey 
    {
        //Play animation
        //switch between animations
        //layers

        private PlayableGraph _playableGraph;
        private PlayableOutput _playableOutput;
        private AnimationClip _currentClip;
        private GameObject gameObject;
        private Animator animator;
        

        public Animonkey(GameObject gameObject, Animator animator)
        {
            this.gameObject = gameObject;
            this.animator = animator;
            Initialize(gameObject, animator);
        }
        private void Initialize(GameObject gameObject, Animator animator)
        {
            _playableGraph = PlayableGraph.Create(gameObject.name + " Graph");
            _playableOutput = AnimationPlayableOutput.Create(_playableGraph, gameObject.name + " Output", animator);
        }

        public void Play(AnimationClip clip)
        {
            var playableClip = new AnimonkeyAnimation(clip, _playableGraph);
            _currentClip = clip;
            _playableOutput.SetSourcePlayable(playableClip.PlayableClip, 0);
            _playableGraph.Play();
        }

        public void Disable()
        {
            _playableGraph.Destroy();
        }
    }
}
