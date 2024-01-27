using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class Speedbuff : PowerUpEffect
{
   public override void Apply(GameObject target)
   {
    target GetComponent<PlayerSpeed>().speed.value += amount;
   }
}
