using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MarcoPolo
{
    public class UnitRandererHandler : MonoBehaviour
    {
        Renderer rend;
        public Renderer outline;
        StatsComponent healthComp;
        Vector3 lastPos;
        Vector3 velocity;
        Vector3 lastRot;
        Vector3 angularVelocity;
        public float MaxWobble = 0.003f;
        public float WobbleSpeed = 1f;
        public float Recovery = 1f;
        float wobbleAmountX;
        float wobbleAmountZ;
        float wobbleAmountToAddX;
        float wobbleAmountToAddZ;
        float pulse;
        float time = 0.5f;
        Color DefaultOutlineColor;
        float DefaultOutlineSize=0;

        // Use this for initialization
        void Start()
        {
            healthComp = GetComponent<StatsComponent>();
            rend = GetComponent<Renderer>();
            DefaultOutlineColor = outline.material.GetColor("_ColorOfOutline");


        }
        private void Update()
        {
            time += Time.deltaTime;
            // decrease wobble over time
            wobbleAmountToAddX = Mathf.Lerp(wobbleAmountToAddX, 0, Time.deltaTime * (Recovery));
            wobbleAmountToAddZ = Mathf.Lerp(wobbleAmountToAddZ, 0, Time.deltaTime * (Recovery));

            // make a sine wave of the decreasing wobble
            pulse = 2 * Mathf.PI * WobbleSpeed;
            wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
            wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

            // send it to the shader
            if ((healthComp.CurrentHP / (float)healthComp.MaxHP) <1)
            {
                rend.material.SetFloat("_WobbleX", wobbleAmountX);
                rend.material.SetFloat("_WobbleZ", wobbleAmountZ);
            }
      
            rend.material.SetFloat("_Fill", (healthComp.CurrentHP/ (float)healthComp.MaxHP));

            // velocity
            velocity = (lastPos - transform.position) / Time.deltaTime;
            angularVelocity = transform.rotation.eulerAngles - lastRot;


            // add clamped velocity to wobble
            wobbleAmountToAddX += Mathf.Clamp((velocity.x + (angularVelocity.z * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);
            wobbleAmountToAddZ += Mathf.Clamp((velocity.z + (angularVelocity.x * 0.2f)) * MaxWobble, -MaxWobble, MaxWobble);

            // keep last position
            lastPos = transform.position;
            lastRot = transform.rotation.eulerAngles;
        }

        public void SelectUnit(bool isSelected)
        {
            if(isSelected)
            {
                outline.material.SetFloat("_SizeOfOutline", 0.1f);
                outline.material.SetColor("_ColorOfOutline", new Color(0, 0, 0, 0.3f));
            }
            else
            {
                outline.material.SetFloat("_SizeOfOutline", DefaultOutlineSize);
                outline.material.SetColor("_ColorOfOutline", DefaultOutlineColor);
            }
           
        }
       

    }
}