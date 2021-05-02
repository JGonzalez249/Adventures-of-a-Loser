using UnityEngine;

public class BGParallax: MonoBehaviour
{

    private float length, startpos;
    public GameObject mainCam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (mainCam.transform.position.x * (1 - parallaxEffect));
        float dist = (mainCam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        // creates an infinte bg scrolling effect
        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
