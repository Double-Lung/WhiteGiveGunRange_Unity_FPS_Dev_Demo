using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetTexture : MonoBehaviour
{
    Player player;
    MeshRenderer meshRenderer;
    Transform parentTransform;
    public Texture senpai;
    private void Start() {
        player = FindObjectOfType<Player>();
        meshRenderer = GetComponent<MeshRenderer>();
        player.OnAddScore += OnScoreReached;
        parentTransform = transform.parent.parent;
    }

    void OnScoreReached() {
        meshRenderer.material.EnableKeyword("_NORMALMAP");
        meshRenderer.material.EnableKeyword("_METALLICGLOSSMAP");
        StartCoroutine(enableRoutine());
        meshRenderer.material.SetTexture("_BaseMap", senpai);

    }

    IEnumerator enableRoutine() {
        float slerpValue = 0;
        float turnSpeed = 1.5f;
        while (slerpValue < 1f) {
            yield return new WaitForSeconds(Time.deltaTime);
            slerpValue += Time.deltaTime * turnSpeed;
            parentTransform.rotation = Quaternion.Slerp(parentTransform.rotation, Quaternion.identity, slerpValue);
        }
    }
}
