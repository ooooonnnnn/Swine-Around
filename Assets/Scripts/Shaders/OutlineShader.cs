using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Renderer))]
public class OutlineShader : MonoBehaviour
{
    public float outlineWidth = 0.1f;
    public Color color = Color.red;

    private Renderer _renderer;
    private MaterialPropertyBlock _mpb;
    
    void OnEnable()
    {
        _renderer = GetComponent<Renderer>();
        _mpb = new MaterialPropertyBlock();
        Apply();
    }

    void OnValidate()
    {
        if (!Application.isPlaying)
            Apply();
    }

    void Apply()
    {
        if (_renderer == null)
            _renderer = GetComponent<Renderer>();

        if (_mpb == null)
            _mpb = new MaterialPropertyBlock();

        _renderer.GetPropertyBlock(_mpb);
        _mpb.SetFloat("_Outline_Scale", outlineWidth + 1.0f);
        _mpb.SetColor("_Outline_Color", color);
        _renderer.SetPropertyBlock(_mpb);
    }
}