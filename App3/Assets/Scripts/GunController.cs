using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage;
    public float range;
    public Camera cam;
    public ParticleSystem gunFlash;
    public GameObject gunHitFlash;
    public bool isPaused;

    public float timeFactor;
    public float timeBetweenShots;
    public float powerFactor;

    void Start()
    {
        if (UpgradeManager.speedUpgrade1)
        {
            timeFactor = 0.5f;
        }
        if (UpgradeManager.speedUpgrade2)
        {
            timeFactor = 0.01f;
        }
        if (UpgradeManager.powerUpgrade1)
        {
            powerFactor = 2f;
        }
        if (UpgradeManager.powerUpgrade2)
        {
            powerFactor = 4f;
        }
        
        isPaused = false;
        timeBetweenShots = timeFactor;
        damage = powerFactor;
    }

    void Update()
    {
        if (timeBetweenShots > 0)
        {
            isPaused = true;
            timeBetweenShots -= Time.deltaTime;
        }
        if (timeBetweenShots <= 0)
        {
            isPaused = false;
        }

        if (!isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        
    }

    void Shoot()
    {
        gunFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            DamageController target = hit.transform.GetComponent<DamageController>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactObject = Instantiate(gunHitFlash, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObject, 0.1f);
        }

        timeBetweenShots = timeFactor;
    }
}
