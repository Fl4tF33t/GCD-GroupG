using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class Player2PPScript : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ElectrPPVol;
    [SerializeField] private PostProcessVolume HealthPPVol;

    private void Start()
    {
        Level1GameManager.Instance.health.OnValueChanged += OnValueChangedPostProcess;
    }

    private void OnValueChangedPostProcess(int previous, int current)
    {
        HealthPPVol.weight = (float)(100 - current) / 100;
        StartCoroutine("ElectrEffect");
    }

    private IEnumerator ElectrEffect()
    {
        ElectrPPVol.weight = 1f;
        yield return new WaitForSeconds(0.2f);
        ElectrPPVol.weight = 0f;
    }
}
