using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace DefaultNamespace
{
    public class SkyBoxShaderManager : MonoBehaviour
    {
        [SerializeField] private Material skyMat;
        [SerializeField] private Light directionalLight;
        private void Start()
        {
            SetLightDirection();
        }

        private void SetLightDirection()
        {
            skyMat.SetVector("_SunDirection", directionalLight.transform.forward);
            skyMat.SetVector("_SunDirection_r", directionalLight.transform.right);
            skyMat.SetVector("_SunDirection_u", directionalLight.transform.up);
            // skyMat.SetColor("_SunColor", directionalLight.color); 
        }

        private void OnValidate()
        {
            if (directionalLight != null && skyMat != null)
            {
                SetLightDirection();

            }
        }

        private void OnDrawGizmos()
        {
            if (directionalLight != null && skyMat != null)
            {
                SetLightDirection();

            }
        }
    }
}