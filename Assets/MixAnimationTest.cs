using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class MixAnimationTest : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private List<AnimationClip> _clips = new List<AnimationClip>();
    public float weight;

    private PlayableGraph _playableGraph;

    private AnimationMixerPlayable _mixer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playableGraph = PlayableGraph.Create("Mixer Graph");

        var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "MixerAnim", _animator);
        
        _mixer = AnimationMixerPlayable.Create(_playableGraph, _clips.Count);
        
        playableOutput.SetSourcePlayable(_mixer);

        for (int i = 0; i < _clips.Count; i++)
        {
            var playableClip = AnimationClipPlayable.Create(_playableGraph, _clips[i]);
            _playableGraph.Connect(playableClip, 0, _mixer, i);
        }
        
        _playableGraph.Play();

    }
    void Update()
    {
        
        weight = Mathf.Clamp(weight, 0 ,_clips.Count);

        
        var index = (int) weight;
        var val = weight % 1; 
        _mixer.SetInputWeight(index, val);
        if (index < _clips.Count - 1)
        {
            var val1 = 1 - (weight % 1);
            _mixer.SetInputWeight(index + 1, val1);
        }

    }

    private void OnDisable()
    {
        _playableGraph.Destroy();
    }
}
