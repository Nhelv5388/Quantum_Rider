using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

// Tile Palette �Ŏg�p�ł��邷�ׂẴu���V���Ǘ�����N���X
public static class TileSample
{
    //����
    private const BindingFlags BINDING_ATTR = BindingFlags.Static | BindingFlags.Public;

    private static readonly Assembly m_assembly = typeof(GridPaintingState).Assembly;
    private static readonly Type m_type = m_assembly.GetType("UnityEditor.Tilemaps.GridPaletteBrushes");
    private static readonly PropertyInfo m_property = m_type.GetProperty("brushes", BINDING_ATTR);

    public static List<GridBrushBase> brushes => m_property.GetValue(null) as List<GridBrushBase>;
}

[InitializeOnLoad]
public static class Example
{
    static Example()
    {
        // �I�𒆂̃u���V���ύX���ꂽ���ɌĂяo�����
        GridPaintingState.brushChanged += OnChanged;
    }
    /*
    [MenuItem("Tools/Log")]
    private static void Log()
    {
        // �I�𒆂̃u���V���擾����
        Debug.Log(GridPaintingState.gridBrush);

        // �I�𒆂̃u���V��ύX����
        var brushes = TileSample.brushes;
        var brush = brushes.Find(c => c.name.Contains("GameObject Brush"));
        GridPaintingState.gridBrush = brush;
    }
    */
    private static void OnChanged(GridBrushBase brush)
    {
        //Debug.Log(brush.name);
    }
}

public class MyWindow : EditorWindow
{

    [MenuItem("Tools/Window")]
    static void Open()
    {
        var window = GetWindow<MyWindow>();
        window.titleContent = new GUIContent("�^�C��");
        
    }

    private void OnGUI()
    {
        if (GUILayout.Button("GUI Button"))
        {
            Log();
        }


    }
    
    private static void Log()
    {
        // �I�𒆂̃u���V���擾����
        Debug.Log(GridPaintingState.gridBrush);

        // �I�𒆂̃u���V��ύX����
        var brushes = TileSample.brushes;
        var brush = brushes.Find(c => c.name.Contains("GameObject Brush"));
        GridPaintingState.gridBrush = brush;
    }
}