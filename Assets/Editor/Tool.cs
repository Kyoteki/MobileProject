using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Tool : EditorWindow
{
    [SerializeField] GameObject _obstacle;
    [SerializeField] GameObject _oneWay;
    [SerializeField] GameObject _river;
    [SerializeField] GameObject _portal;
    [SerializeField] GameObject _altar;
    [SerializeField] GameObject _soul;
    [SerializeField] GameObject _player;

    [SerializeField] GameObject _level;
    [SerializeField] GameObject _choosen;

    [MenuItem("Tools/Tool")]
    private static void ShowWindow()
    {
        GetWindow(typeof(Tool));
    }

    private void OnGUI()
    {
        _obstacle = EditorGUILayout.ObjectField("Obstacle", _obstacle, typeof(GameObject), false) as GameObject;
        _oneWay = EditorGUILayout.ObjectField("OneWay", _oneWay, typeof(GameObject), false) as GameObject;
        _river = EditorGUILayout.ObjectField("River", _river, typeof(GameObject), false) as GameObject;
        _portal = EditorGUILayout.ObjectField("Portal", _portal, typeof(GameObject), false) as GameObject;
        _altar = EditorGUILayout.ObjectField("Altar", _altar, typeof(GameObject), false) as GameObject;
        _soul = EditorGUILayout.ObjectField("Soul", _soul, typeof(GameObject), false) as GameObject;
        _player = EditorGUILayout.ObjectField("Player", _player, typeof(GameObject), false) as GameObject;

        EditorGUILayout.Space();
        _level = EditorGUILayout.ObjectField("Level to edit", _level, typeof(GameObject), true) as GameObject;

        EditorGUILayout.Space();

        if (_choosen != null) GUILayout.Label("Selected : " + _choosen.name);
        else GUILayout.Label("Selected : Nothing");

        EditorGUILayout.Space();
        if (GUILayout.Button("Select Obstacle"))
        {
            _choosen = _obstacle;
        }
        if (GUILayout.Button("Select OneWay"))
        {
            _choosen = _oneWay;
        }
        if (GUILayout.Button("Select River"))
        {
            _choosen = _river;
        }
        if (GUILayout.Button("Select Portal"))
        {
            _choosen = _portal;
        }
        if (GUILayout.Button("Select Altar"))
        {
            _choosen = _altar;
        }
        if (GUILayout.Button("Select Soul"))
        {
            _choosen = _soul;
        }
        if (GUILayout.Button("Select Player"))
        {
            _choosen = _player;
        }

        EditorGUILayout.Space();
        if (GUILayout.Button("Unselect"))
        {
            _choosen = null;
        }
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        Event e = Event.current;



        Vector3 pos = sceneView.camera.ScreenToWorldPoint(e.mousePosition);

        if (e.type == EventType.MouseDown && e.button == 0 && _choosen != null)
        {
            GameObject instance = Instantiate(_obstacle, _level.transform);
            instance.transform.position = new Vector3((int)pos.x, (int)pos.y, 0);
        }
    }
}
