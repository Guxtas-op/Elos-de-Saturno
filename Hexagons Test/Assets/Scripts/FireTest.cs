using UnityEngine;
using BetaKors.Extensions;
using System.Collections;

public class FireTest : MonoBehaviour
{
    public GameObject bullet;
    public Transform arma;

    public float strength;
    public float forwardFactor = 10f;
    public float cooldown = 0.5f;

    private bool tirin = true;

    private new Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && tirin == true)
        {
            tirin = false;

            float distance = Vector3.Distance(camera.transform.position, arma.position);

            Vector3 spawnPosition = camera.ScreenToWorldPoint(Input.mousePosition.WithZ(distance + forwardFactor));

            GameObject fire = Instantiate(bullet, arma.position, Quaternion.identity);

            Vector3 impulse = (spawnPosition - arma.position).normalized * strength;

            fire.GetComponent<Rigidbody>().velocity = impulse;

            Invoke(nameof(ResetTirin), cooldown);
        }
    }

    void ResetTirin()
    {
        tirin = true;
    }
    // vo se jogar
}
