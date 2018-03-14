using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]

public class CRT : MonoBehaviour
{
    public Shader shader;
    private Material _material;

    [Range(0.0f, 1.0f)]
    public float m_fScanLineMult;

    [Range(0.0f, 1.0f)]
    public float _redIntensity;

    [Range(0.0f, 1.0f)]
    public float _greenIntensity;

    [Range(0.0f, 1.0f)]
    public float _blueIntensity;

    [Range(-5.0f, 20.0f)]
    public float _contrast;

    [Range(-300.0f, 300.0f)]
    public float _brightness;

    protected Material material
    {
        get
        {
            if (null == _material)
            {
                _material = new Material(shader);
                _material.hideFlags = HideFlags.HideAndDontSave;
            }
            return _material;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (null != shader)
        {
            Material mat = material;
            mat.SetFloat("_Scanline", m_fScanLineMult);
            mat.SetFloat("_RedIntensity", _redIntensity);
            mat.SetFloat("_GreenIntensity", _greenIntensity);
            mat.SetFloat("_BlueIntensity", _blueIntensity);
            mat.SetFloat("_Contrast", _contrast);
            mat.SetFloat("_Brightness", _brightness);
            Graphics.Blit(source, destination, mat);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    void OnDisable()
    {
        if (_material)
            DestroyImmediate(_material);
    }
}