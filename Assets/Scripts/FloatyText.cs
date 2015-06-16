using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatyText : MonoBehaviour {
    Text textElement;
    public string text;
    public Color c = Color.red;
    public Vector3 direction = Vector3.up;
    public float time = 1;
    float timer = 0;

	// Use this for initialization
	void Awake () {
        textElement = GetComponent<Text>();
        textElement.text = text;
        textElement.color = c;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += direction * Time.deltaTime;
        if (timer >= time) {
            Destroy(gameObject);
        }
	}

    public static FloatyText CreateDefaultFloatyText() {
        GameObject go = new GameObject("floaty text");
        go.AddComponent<Canvas>();
        go.AddComponent<CanvasScaler>();
        go.AddComponent<CanvasRenderer>();
        Text t = go.AddComponent<Text>();
        t.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        ContentSizeFitter csf = go.AddComponent<ContentSizeFitter>();
        csf.verticalFit = csf.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        RectTransform rt = go.GetComponent<RectTransform>();
        rt.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        FloatyText ft = go.AddComponent<FloatyText>();
        return ft;
    }

    public static FloatyText Create(string message, Vector3 position, Vector3 velocity, Color color, float time) {
        FloatyText ft = CreateDefaultFloatyText();
        ft.text = message;
        ft.transform.position = position;
        ft.c = color;
        ft.time = time;
        return ft;
    }
}
