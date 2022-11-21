using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage;
    public float range;
    public Camera cam;
    public ParticleSystem gunFlash;
    public GameObject gunHitFlash;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
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
    }
}
