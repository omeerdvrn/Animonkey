using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Animonkey.Animonkey.Test
{
    public class ControlTest : AnimonkeyController
    {
        [FormerlySerializedAs("clip")] public List<AnimationClip> clips;
        private AnimonkeyAnimation _currentAnim;
        public int nextIndex;
        private void Awake()
        {
            Initialize();
            _currentAnim = animonkey.Play(clips[0]);
            nextIndex++;
            animonkey.OnUpdate(() =>
            {
                Debug.Log($"OnUpdate event is working;");
            });
            animonkey.OnComplete(() =>
            {
                Debug.Log($"OnComplete event is working;");
            });
        }

        public void ChangeAnimation()
        {
            animonkey.ClearAllEvents();
            _currentAnim = animonkey.Play(clips[nextIndex]);
            nextIndex++;
            if (nextIndex >= clips.Count)
                nextIndex = 0;
        }
    }
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(ControlTest))]
    public class ControlTest_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            ControlTest script = (ControlTest) target;

        
            if (GUILayout.Button("Change Animation"))
            {
                script.ChangeAnimation();
            }
        }
    }
    #endif
}
