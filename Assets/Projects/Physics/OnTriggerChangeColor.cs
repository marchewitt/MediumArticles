using UnityEngine;

namespace Projects.Physics
{
    public class OnTriggerChangeColor : MonoBehaviour
    {
    
        public Color triggerBoxColor;
        public Color triggerPlayerColor;
        private Color _oldBoxColor;
        private Color _oldPlayerColor;

        public MeshRenderer playerMeshRender;
        private MeshRenderer thisMeshRender;

        void Start()
        {
            thisMeshRender = this.GetComponent<MeshRenderer>();
        
        }
        private void OnTriggerEnter(Collider other)
        {
            _oldBoxColor = thisMeshRender.material.color;
            _oldPlayerColor = playerMeshRender.material.color;
            thisMeshRender.material.color = triggerBoxColor;
            playerMeshRender.material.color = triggerPlayerColor;
        }

        private void OnTriggerExit(Collider other)
        {
            thisMeshRender.material.color = _oldBoxColor;
            playerMeshRender.material.color = _oldPlayerColor;
        }
    }
}
