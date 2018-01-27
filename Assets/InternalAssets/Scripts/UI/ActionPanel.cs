using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ActionPanel : MonoBehaviour {

    private Vector3 anchorPoint;
    private RectTransform selfRectTransform;

    private Image img;

    private Sprite acquire;
	private Sprite transmit;
    private Sprite getLove;
    private Sprite spreadLove;

    private Animator animator; // own animator component 

    // Use to determine which Sreen/World Position to set the panel
    private Camera mainCamera;      
    private RectTransform mainCanvas;

    private void Start()
    {
        // Settings variables
        selfRectTransform = GetComponent<RectTransform>();

        img = GetComponentInChildren<Image>();

        acquire = Resources.Load<Sprite>("Sprites/UI/UI_Acquire");
        transmit = Resources.Load<Sprite>("Sprites/UI/UI_Transmit");
        getLove = Resources.Load<Sprite>("Sprites/UI/UI_GetLove");
        spreadLove = Resources.Load<Sprite>("Sprites/UI/UI_SpreadLove");
        
        animator = GetComponent<Animator>();

        mainCamera = Camera.main;
        mainCanvas = GameObject.Find("MainCanvas").GetComponent<RectTransform>();
    }

    private void Update()
	{
		SetPosition(anchorPoint);
	}

	public void SetPosition(Vector3 worldPosition)
	{
        transform.position = worldPosition;

  //      anchorPoint = worldPosition;
  //      //anchorPoint = Vector3.zero;

  //      if (!mainCamera || !mainCanvas || !selfRectTransform)
		//	return;

  //      Debug.Log("worldPosition : " + worldPosition);
		////selfRectTransform.anchoredPosition = mainCamera.WorldToScreenPoint(anchorPoint);
  //      transform.position = mainCamera.WorldToScreenPoint(anchorPoint);
  //      selfRectTransform.anchoredPosition = mainCamera.WorldToScreenPoint(anchorPoint) / mainCanvas.localScale.x;
    }

	public void SetPanel (Interactiblebutton panelStatus)
	{
		switch(panelStatus)
		{
			case Interactiblebutton.a:
				img.sprite = acquire;
				break;

			case Interactiblebutton.b:
				img.sprite = transmit;
				break;

			case Interactiblebutton.x:
				img.sprite = getLove;
				break;

			case Interactiblebutton.y:
				img.sprite = spreadLove;
				break;
            case Interactiblebutton.none:
                break;
            default:
                break;
		}
	}

	public void ShowPanel (bool show)
	{
		animator.SetBool("visible", show);
	}
}
