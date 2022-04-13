using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MarcoPolo
{
    public class RandererHandler : MonoBehaviour
    {
        Renderer rend;
        HPHandler healthComp;
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

        // Use this for initialization
        void Start()
        {
            healthComp = GetComponent<HPHandler>();
            rend = GetComponent<Renderer>();
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
            if ((healthComp.currentHP / (float)healthComp.MaxHP)<1)
            {
                rend.material.SetFloat("_WobbleX", wobbleAmountX);
                rend.material.SetFloat("_WobbleZ", wobbleAmountZ);
            }
      
            rend.material.SetFloat("_Fill", (healthComp.currentHP/ (float)healthComp.MaxHP));

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



    }
}