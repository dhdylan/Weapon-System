using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 51)]
public class Weapon : ScriptableObject
{
    public Mesh weaponMesh;
    public float zoomModifier;
    public int magSize;
    public Projectile projectile;
    public float reloadTime;
    public FiringMode firingMode;
    public float fireRate;
}
