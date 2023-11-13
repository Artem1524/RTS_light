using UnityEngine;
using UnityEngine.UI;

public class UIMask : MonoBehaviour
{
    private Material material;
    private Mask mask;
    public void Start()
    {
        material = GetComponent<ParticleSystem>().GetComponent<Renderer>().material;
        mask = GetComponentInParent<Mask>();
        SetClip();
        //If the cropping area does not change during runtime, you can comment out the following code
        //GetComponentInParent<ScrollRect>().onValueChanged.AddListener(v => { SetClip(); });
    }
    public void SetClip()
    {
        //Get the area that needs to be cropped
        Vector3[] corners = new Vector3[4];
        mask.GetComponent<RectTransform>().GetWorldCorners(corners);
        //Pass the cropping area into the Shader
        material.SetFloat("_MinX", corners[0].x);
        material.SetFloat("_MinY", corners[0].y);
        material.SetFloat("_MaxX", corners[2].x);
        material.SetFloat("_MaxY", corners[2].y);
    }
}
