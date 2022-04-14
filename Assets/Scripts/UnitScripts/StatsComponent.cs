using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MarcoPolo
{
    public class StatsComponent : MonoBehaviour
    {
        private int maxHP = 3;
        private int currentHP = 3;
        private float wanderRadius=10;
        private float wanderTimer =3;
        private string m_name = "";
        

        public int CurrentHP { get => currentHP; set => currentHP = value; }
        public int MaxHP { get => maxHP; set => maxHP = value; }
        public float WanderRadius { get => wanderRadius; set =>  wanderRadius = value; }
        public float WanderTimer { get => wanderTimer; set => wanderTimer = value; }
        public string Name { get => m_name; set => m_name = value; }

            public void SetStats(UnitScpObject ob)
        {
            CurrentHP = ob.currentHP;
            MaxHP = ob.maxHP;
            WanderRadius = ob.wanderRadius;
            WanderTimer = ob.wanderTimer;
            Name = ob.m_name;
            this.GetComponent<MeshFilter>().mesh = ob.m_mesh;
            this.transform.Find("Outline").GetComponent<MeshFilter>().mesh = ob.m_mesh;
        }
    }
}

