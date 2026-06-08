using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Renderer))]
public class OutlineScript : MonoBehaviour
{
    public float outline = 1.1f;
    public Color color = Color.red;

    private Renderer _renderer;
    private MaterialPropertyBlock _mpb;

    private float _lastOutline;
    private Color _lastColor;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _mpb = new MaterialPropertyBlock();
        Apply();
    }

    void Update()
    {
        if (_lastOutline != outline || _lastColor != color)
            Apply();
    }

    private void Apply()
    {
        if (_renderer)
            _renderer = GetComponent<Renderer>();

        if (_mpb == null)
            _mpb = new MaterialPropertyBlock();

        _renderer.GetPropertyBlock(_mpb);

        _mpb.SetFloat("_Outline_Scale", outline);
        _mpb.SetColor("_Outline_Color", color);

        _renderer.SetPropertyBlock(_mpb);
    }
    
    public void SetOutline(float scale, Color color)
    {
        outline = scale;

        _renderer.GetPropertyBlock(_mpb);
        _mpb.SetFloat("_Outline_Scale", scale);
        _mpb.SetColor("_Outline_Color", color);
        _renderer.SetPropertyBlock(_mpb);
    }
}