using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationFrames", menuName = "AnimationFrames")]
public class AnimationFrames : ScriptableObject
{
    public string animationName;
    public List<Sprite> framesList = new List<Sprite>();

    [Range(1.01f, 10.0f)]
    public float animationSpeed = 1.01f;
}
