using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/PlayerAnimLibrary")]
public class PlayerAnimationLibrary : ScriptableObject
{
    List<AnimationData> AnimationList;
}

public class AnimationData
{
    public Animation Animation;

}
