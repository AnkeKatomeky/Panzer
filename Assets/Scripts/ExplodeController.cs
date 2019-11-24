using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeController : MonoBehaviour
{
    public float TimeOfLife = 2;
    public float FirePower = 1000;

    public GameObject Explode;
    public ExplodeStats Stats;

    public int Shrapnels;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(transform.forward * FirePower);
    }

    // Update is called once per frame
    void Update()
    {
        TimeOfLife -= Time.deltaTime;

        if (TimeOfLife < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<ActorStats>().GetDamage(Stats.Damage);
        }

        if (other.tag != "Player" && other.tag != "Charge" && other.tag != "InvisibWall")
        {
            Instantiate(Explode, transform.position, transform.rotation);

            if (Shrapnels > 0)
            {
                for (float i = 0; i < 360; i += 360 / Shrapnels)
                {
                    Quaternion rotation = Quaternion.Euler(45, i, 0);

                    GameObject obj = Instantiate(gameObject, transform.position + new Vector3(0, 0.3f, 0), rotation);;
                    obj.GetComponent<ExplodeController>().Shrapnels = 0;
                    obj.GetComponent<ExplodeController>().FirePower = 1000;
                    obj.GetComponent<ExplodeStats>().Damage = 25;
                }
            }

            Destroy(gameObject);
        }
    }
}
