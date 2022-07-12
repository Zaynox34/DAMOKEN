using UnityEngine;

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

    public AudioClip attackSound;
    public int TotalSkillTime()
    {
        return skillStartupTime + skillActiveTime + skillRecoveryTime;
    }
    public State StatusOfSkill(int frame)
    {
        if (frame <= 0)
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
                        return State.Idle;
                    }
                }
            }
        }
    }
}
