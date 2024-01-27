using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HPBuff")]
public class HPBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target){
        
        target.GetComponent<Roomba>().HP += amount;
    }

}
