using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

[RequireComponent(typeof(Animator))]
public class PlayableTest : MonoBehaviour
{
    // A PlayableGraph can create, connect, and destroy playables.
    // A Playable is a struct that implements the IPlayable interface.
    // A PlayableOutput is a struct that implements the IPlayableOutput interface.
    public AnimationClip _clip, _clip1;
    private PlayableGraph _playableGraph;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playableGraph = PlayableGraph.Create("MyPlayableGraph");
        _playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
        var playable1 = ScriptPlayable<MyPlayable>.Create(_playableGraph);

        var playableOutput = AnimationPlayableOutput.Create(_playableGraph, "MyAnimation", _animator);
        var playableOutput1 = AnimationPlayableOutput.Create(_playableGraph, "MyAnimation1", _animator);

        var clipPlayable = AnimationClipPlayable.Create(_playableGraph, _clip);
        var clipPlayable1 = AnimationClipPlayable.Create(_playableGraph, _clip1);

        playableOutput.SetSourcePlayable(clipPlayable);
        playableOutput1.SetSourcePlayable(clipPlayable1);
        
        _playableGraph.Play();
    }

    private void OnDisable()
    {
        _playableGraph.Destroy();
    }
}

public class MyPlayable : PlayableBehaviour
{
    public AnimationClipPlayable _playableClip;
}
