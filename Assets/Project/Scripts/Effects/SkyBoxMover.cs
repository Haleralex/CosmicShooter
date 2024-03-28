using UnityEngine;

namespace Project.Scripts.Effects
{
    public class SkyBoxMover : MonoBehaviour
    {
        public float Speed = -1;
    
        void Update()
        {
            RenderSettings.skybox.SetFloat("_RotationZ", Time.time * Speed);
        }
    }
}
