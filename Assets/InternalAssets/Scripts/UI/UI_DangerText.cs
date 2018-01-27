using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class UI_DangerText : MonoBehaviour {

	public Image img;

	[Range(0f, 1f)]
	public float alpha = 1f;
	[Range(0f, 1f)]
	public float targetAlpha = 1f;

	private void Awake()
	{
		img.color = new Color();
		alpha = 0f;
	}

	private void Update()
	{
		SetImageColor();
	}

	private void SetImageColor ()
	{
		alpha = Mathf.Lerp(alpha, targetAlpha, Time.deltaTime * 2f);
		img.color = new Color(1, 1, 1, alpha * (Mathf.Cos(Time.time * 4f) + 1f) / 2f / 2f);
	}
}
