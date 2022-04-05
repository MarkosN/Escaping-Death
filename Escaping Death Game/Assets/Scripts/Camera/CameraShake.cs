using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour // This Script will Make the Camera Shake when the player contacts a trap 
{
    public float shakeDuration = 0.2f;      // How much time the Camera will Shake
    public float shakeWidth = 1.0f;         // Shake's width
    public float shakeFrequency = 1.5f;     // Shake's frequency
    private float shakeElapsedTime = 0.0f;

    // Camera Shake (Cinemachine Shake) using Noise
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    void Start()
    {
        if (virtualCamera != null)
        {
            virtualCameraNoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    void Update()
    {
        if (virtualCamera != null && virtualCameraNoise != null)
        {
            // When the shake effect is enabled
            if (shakeElapsedTime > 0)
            {
                // Camera's shake main parameters
                virtualCameraNoise.m_AmplitudeGain = shakeWidth;
                virtualCameraNoise.m_FrequencyGain = shakeFrequency;

                // Shake Timer Update Continuously
                shakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                // Reset the main parameters If the Camera Shake Effect has Finished
                virtualCameraNoise.m_AmplitudeGain = 0f;
                shakeElapsedTime = 0f; // No Camera Shake Anymore
            }
        }
    }

    public void ShakeEnabled()  // Calling this Function from a Different Script will Enable Camera Shake
    {
        shakeElapsedTime = shakeDuration;
    }
}