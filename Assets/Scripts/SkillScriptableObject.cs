using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SkillScriptableObject", menuName = "ScriptableObjects/Skill")]
public class SkillScriptableObject : ScriptableObject
{
    //[field: SerializeField]
    //public Animation animation;
    [field: SerializeField]
    public float skillRange { get; private set; } = 10;
    [field: SerializeField]
    public int skillStartupTime { get; private set; } = 10;
    [field: SerializeField]
    public int skillActiveTime { get; private set; } = 10;
    [field: SerializeField]
    public int skillRecoveryTime { get; private set; } = 10;

    [field: SerializeField]
    public List<float> compressProportionPerFrame;
    [field: SerializeField]
    public List<float> proportionPerFrame;
    
    [field: SerializeField]
    public List<List<ColidBox>> hurtboxColider;
    [field: SerializeField]
    public List<List<ColidBox>> pushboxColider;
    public AudioClip attackSound;
    public int TotalSkillTime()
    {
        return skillStartupTime + skillActiveTime + skillRecoveryTime;
    }
    public State StatusOfSkill(int frame)
    {
        if (frame < 0)
        {
            return State.Idle;
        }
        else
        {
            if (frame <= skillStartupTime)
            {
                return State.Startup;
            }
            else
            {
                if (frame <= (skillStartupTime + skillActiveTime))
                {
                    return State.Active;
                }
                else
                {
                    if (frame <= (skillStartupTime + skillActiveTime + skillRecoveryTime))
                    {
                        return State.Recovery;
                    }
                    else
                    {
                        return State.Idle;///????
                    }
                }
            }
        }
    }
    public void UncompressProportionPerFrame()
    {
        proportionPerFrame = new List<float>();
        for (int i = 0; i < TotalSkillTime(); i++)
        {
            proportionPerFrame.Add(0);
        }
        for (int i = 0; i < compressProportionPerFrame.Count; i += 2)
        {
            proportionPerFrame[i] = compressProportionPerFrame[i + 1];
        }
    }
}
