using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCharacter : MonoBehaviour
{
    public int CurrentHP;
    public int MaxHP;

    public List<int> moveIDlist;
    private List<int> moveCDlist;

    

    void Start()
    {
        moveCDlist = new List<int>(moveIDlist.Count);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ManageCD();
    }

    private void ManageCD()
    {
        for (int i = 0; i < moveCDlist.Count; i++)
        {
            if(moveCDlist[i] >= 0)
            {
                moveCDlist[i] --;
            }
        }
    }

}
