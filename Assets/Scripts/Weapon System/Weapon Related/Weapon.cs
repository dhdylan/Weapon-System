using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 51)]
public class Weapon : ScriptableObject
{
    public Mesh mesh;
    public Material material;
    public float zoomModifier;
    public int magSize;
    public Projectile projectile;
    public float reloadTime;
    public FiringMode firingMode;
    public float fireRate;

    public Weapon(Mesh mesh, Material material, float zoomModifier, int magSize, Projectile projectile, float reloadTime, FiringMode firingMode, float fireRate)
    {
        this.mesh = mesh;
        this.material = material;
        this.zoomModifier = zoomModifier;
        this.magSize = magSize;
        this.projectile = projectile;
        this.reloadTime = reloadTime;
        this.firingMode = firingMode;
        this.fireRate = fireRate;
    }
}
