using System;
using TMPro;
using UnityEngine;

namespace Projects.Physics
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshRenderer))]
    public class OnHitFallOver : MonoBehaviour
    {
        public Color colorToChangeTo;
        private Rigidbody _rb;
        private MeshRenderer _meshRenderer;

        private void Start()
        {
            _rb = this.GetComponent<Rigidbody>();
            _meshRenderer = this.GetComponent<MeshRenderer>();
        }

        
        private void OnCollisionEnter(Collision other)
        {
            //Ignore Floor
            if(other.collider.CompareTag("Floor") == true ) {return;}
            
            _rb.useGravity = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _meshRenderer.material.color = colorToChangeTo;
                this.enabled = false;
            }
        }
    }
}
