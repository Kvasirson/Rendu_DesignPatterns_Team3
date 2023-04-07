using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] AnimationCurve _vignetteAnim;
    Volume volume;
    Vignette m_Vignette;
    [SerializeField] private float speed;
    [SerializeField] private float Intensity;
    private void Start()
    {
        volume = Camera.main.GetComponent<Volume>();
        volume.profile.TryGet(out m_Vignette);
        FindObjectOfType<PlayerHealth>().TakeDamageEvent.AddListener(TriggerAnim);
    }

    public void TriggerAnim()
    {
        StartCoroutine(vigette_anim());
    }
    IEnumerator vigette_anim()
    {
        if (!m_Vignette)
            yield return null;

        float time = 0;
        while (time / speed <= 1)
        {
            // wait a frame
            time += Time.deltaTime * speed;
            m_Vignette.intensity.value = _vignetteAnim.Evaluate(time) * Intensity;
            yield return new WaitForEndOfFrame();
        }
    }
}
