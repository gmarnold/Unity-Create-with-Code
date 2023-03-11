using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> TextToDisplay = new List<string>();
    
    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;
        
        RotatingSpeed = 1.0f;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];
        
        SparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Text.transform.Rotate(new Vector3(1, 0, 0) * RotatingSpeed);
        TimeToNextText += Time.deltaTime;
        //Debug.Log(TimeToNextText);

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;
            Text.text = TextToDisplay[CurrentText];
            CurrentText++;
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }
        }
    }
}