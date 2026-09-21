using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcesMan : MonoBehaviour
{
    [SerializeField]
    VolumeProfile profile;

    [SerializeField]
    Bloom bloom;
    [SerializeField]
    ChromaticAberration chromaticAB;
    [SerializeField]
    FilmGrain filmGrain;
    [SerializeField]
    Vignette vignette;

    InputAction c1, c2, c3, c4, less, more;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c1 = InputSystem.actions.FindAction("Con1");
        c2 = InputSystem.actions.FindAction("Con2");
        c3 = InputSystem.actions.FindAction("Con3");
        c4 = InputSystem.actions.FindAction("Con4");
        less = InputSystem.actions.FindAction("Less");
        more = InputSystem.actions.FindAction("More");

        profile = FindAnyObjectByType<Volume>().profile;
        profile.TryGet<Bloom>(out bloom);
        profile.TryGet<ChromaticAberration>(out chromaticAB);
        profile.TryGet<FilmGrain>(out filmGrain);
        profile.TryGet<Vignette>(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        if(c1.WasPressedThisFrame())
            bloom.active = !bloom.active;
        if(c2.WasPressedThisFrame())
            chromaticAB.active = !chromaticAB.active;
        if (c3.WasPressedThisFrame())
            filmGrain.active = !filmGrain.active;
        if (c4.WasPressedThisFrame())
            vignette.active = !vignette.active;

        if (less.WasPressedThisFrame())
        {
            bloom.intensity.value -= 0.1f;
            chromaticAB.intensity.value -= 0.1f;
            filmGrain.intensity.value -= 0.1f;
            vignette.intensity.value -= 0.1f;
        }

        if (more.WasPressedThisFrame())
        {
            bloom.intensity.value += 0.1f;
            chromaticAB.intensity.value += 0.1f;
            filmGrain.intensity.value += 0.1f;
            vignette.intensity.value += 0.1f;
        }
    }
}
