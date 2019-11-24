using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : MonoBehaviour
{
    public int HP;
    public float ArmorFactor;
    public int Speed;
    public int SpeedRotation;
    public float TowerRotationSpeed;
    public int Frags;

    public int TouchDamage;

    public void GetDamage(float Damage)
    {
        HP -= Mathf.RoundToInt(Damage * ArmorFactor);
    }
}
