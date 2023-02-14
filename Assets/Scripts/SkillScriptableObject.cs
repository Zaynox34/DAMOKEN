using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SkillScriptableObject", menuName = "ScriptableObjects/Skill")]
public class SkillScriptableObject : ScriptableObject
{
    //[field: SerializeField]
    //public Animation animation;

    [field: SerializeField]
    public string skillName;
    [field: SerializeField]
    public int skillStartActiveState=-1;// case compris
    [field: SerializeField]
    public int skillEndActiveState=-1;// case compris
    [field: SerializeField]
    public List<SkillScriptableObject> listSJw; // liste des Skill qui peuvent te cance
    [field: SerializeField]
    public List<State> StateLesTermes; // a quel state le skill peut etre cancel;
    /*
     public AudioClip attackSound;
     */

    public State StatusOfSkill(int frame)
    {
        if(skillEndActiveState==-1 && skillEndActiveState == -1)
        {
            return State.Ghost;
        }
        else 
        {
            if(frame<skillStartActiveState)
            {
                return State.Startup;
            }
            else
            {
                if ((frame >= skillStartActiveState) && (frame <= skillEndActiveState))
                {
                    return State.Active;
                }
                else
                {
                    if (frame > skillEndActiveState)
                    {
                        return State.Recovery;
                    }
                    else
                    {
                        return State.Unknow;
                    }
                }
            }

        }
    }
    public bool isCancelable(SkillScriptableObject skill,State state) // skill canceleur et state canceler
    {
        bool res=false;
        foreach(SkillScriptableObject s in listSJw)
        {
            if(skill==s)
            {
                res = true;
            }
        }
        if (!res)
        {
            return false;
        }
        else
        {
            foreach (State s in StateLesTermes)
            {
                if (state == s)
                {
                    return true;
                }
            }
            return false;
        }
    }
    /*public List<string> SkillNameToSkillPArticularName() // 1er element T 2e C
    {
        List<string> result = new List<string>();
        result.Add("T_" + skillName);
        result.Add("C_" + skillName);
        return result;
    }
    public string SkillPArticularNameToSkillName() // 1er element T 2e C
    {
        List<string> result = new List<string>();
        result.Add("T_" + skillName);
        result.Add("C_" + skillName);
        return result;
    }
    */
}
