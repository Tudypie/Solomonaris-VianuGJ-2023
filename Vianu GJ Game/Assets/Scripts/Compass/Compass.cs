using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{   
    [SerializeField] private GameObject iconPrefab;
    List<PointMarkers> pointMarkers = new List<PointMarkers>();

    [SerializeField] private RawImage compassImage;
    [SerializeField] private Transform Player;

    [SerializeField] private float maxDistance = 200f;

    float compasUnit;

    [SerializeField] private PointMarkers[] markers;

    private void Start()
    {
        compasUnit = compassImage.rectTransform.rect.width / 360f;

        foreach(PointMarkers marker in markers)
        {
            AddPointMarker(marker);
        }
    }

    private void Update()
    {
        compassImage.uvRect = new Rect(Player.localEulerAngles.y / 360, 0, 1, 1);

        foreach(PointMarkers marker in pointMarkers)
        {
            marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);

            float dst = Vector2.Distance(new Vector2(Player.position.x, Player.position.z), marker.Position);
            float scale = 0f;

            if(dst < maxDistance)
            {
                scale = 1f - dst / maxDistance;
            }

            marker.image.rectTransform.localScale = Vector3.one * scale;
        }
    }

    public void AddPointMarker(PointMarkers marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        pointMarkers.Add(marker);
    }

    public void RemovePointMarker(PointMarkers marker)
    {
        if(pointMarkers.Contains(marker))
        {
            pointMarkers.Remove(marker);
            Destroy(marker.image.gameObject);
        }
    }

    Vector2 GetPosOnCompass(PointMarkers marker)
    {
        Vector2 playerPos = new Vector2(Player.position.x, Player.position.z);
        Vector2 playerFwd = new Vector2(Player.forward.x, Player.forward.z);

        float angle = Vector2.SignedAngle(marker.Position - playerPos, playerFwd);

        return new Vector2(compasUnit * angle, 0f);
    }
}
