using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ActionPanel : MonoBehaviour {

	public Transform anchorPoint;
	public Camera mainCamera;

	public RectTransform mainCanvas;
	public RectTransform selfRectTransform;
	public Image img;

	public Sprite acquire;
	public Sprite transmit;
	public Sprite getLove;
	public Sprite spreadLove;

	public Animator animator;

	private void Update()
	{
		SetPosition();
	}

	private void SetPosition()
	{
		if (!anchorPoint || !mainCamera || !mainCanvas || !selfRectTransform)
			return;

		selfRectTransform.anchoredPosition = mainCamera.WorldToScreenPoint(anchorPoint.position) / mainCanvas.localScale.x;
	}

	public void SetPanel (int panelStatus)
	{
		switch(panelStatus)
		{
			case 1:
				img.sprite = acquire;
				break;

			case 2:
				img.sprite = transmit;
				break;

			case 3:
				img.sprite = getLove;
				break;

			case 4:
				img.sprite = spreadLove;
				break;
		}
	}

	public void ShowPanel (bool show)
	{
		animator.SetBool("visible", show);
	}
}
