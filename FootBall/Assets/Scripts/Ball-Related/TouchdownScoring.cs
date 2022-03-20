using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TouchdownScoring : MonoBehaviour
{
    public ParticleSystem Particle;
    public TextMeshProUGUI Text;
   public float score; 
    private string _str;
    private GameObject BALL;
    public GameObject spawnpoint;
    public GameObject ballR;
    private bool gone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;
            Particle.Play(true);
            BALL = other.gameObject;
            Destroy(BALL);
            gone = true;
        }

    }
    public void Update()
    {
        _str = score.ToString();
        Text.text = _str;
        if (gone)
        {
            Instantiate(ballR, spawnpoint.transform);
            gone = false;
        }
    }
}
