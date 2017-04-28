using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    private float ClipCount = 6;
    public Animator MyAnim;
    public GameObject Muzzle;
    public GameObject Bullet;
    public Ray ray;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            MyAnim.SetTrigger("Fire");
            Invoke("Fire", 0.06f);
        }


        Aim();
	}

    void Aim()
    {
        RaycastHit hit;

        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

     if (Physics.Raycast(ray, out hit))
        {
            Muzzle.transform.LookAt(hit.point);
        }
    }

    void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.name);
           if ( hit.collider.GetComponent<QuickStart>() != null)
            {
                hit.collider.GetComponent<QuickStart>().enabled = true;
            }
        }
    }

    void FireSlowBullet()
    {

    }

    void FireMagnetBullet()
    {

    }
}
