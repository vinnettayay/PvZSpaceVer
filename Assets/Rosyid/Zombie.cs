using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Zombie
{
    public int spawnTime;
    public ZombieType zombieType;
}
public enum ZombieType
{
    Zombie_Basic,
    Zombie_Flag,
    Zombie_Bucket
}