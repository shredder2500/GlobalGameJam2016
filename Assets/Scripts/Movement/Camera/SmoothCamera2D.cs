using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour 
{
    [SerializeField]
    private GameObject _playerCharacter;

    public float smoothTime = 0.25f;

    public bool verticalMaxEnabled = false;
    public float verticalMax = 0f;
    public bool verticalMinEnabled = false;
    public float verticalMin = 0f;

    public bool horizontalMaxEnabled = false;
    public float horizontalMax = 0f;
    public bool horizontalMinEnabled = false;
    public float horizontalMin = 0f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        var playerTransform = _playerCharacter.gameObject.transform;
        var playerPosition = playerTransform.position;


        if (verticalMinEnabled && verticalMaxEnabled)
        {
            playerPosition.y = Mathf.Clamp(playerTransform.position.y, verticalMin, verticalMax);
        }
        else if (verticalMinEnabled)
        {
            playerPosition.y = Mathf.Clamp(playerTransform.position.y, verticalMin, playerTransform.position.y);
        }
        else if (verticalMaxEnabled)
        {
            playerPosition.y = Mathf.Clamp(playerTransform.position.y, playerTransform.position.y, verticalMax);
        }

        if (horizontalMinEnabled && horizontalMaxEnabled)
        {
            playerPosition.x = Mathf.Clamp(playerTransform.position.x, horizontalMin, horizontalMax);
        }
        else if (horizontalMinEnabled)
        {
            playerPosition.x = Mathf.Clamp(playerTransform.position.x, horizontalMin, playerTransform.position.x);
        }
        else if (horizontalMaxEnabled)
        {
            playerPosition.x = Mathf.Clamp(playerTransform.position.x, playerTransform.position.x, horizontalMax);
        }

        var distance = Vector3.Distance(playerPosition, this.gameObject.transform.position);
        if (distance < 3)
        {
            return;
        }

        playerPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, (3/distance) * smoothTime * Time.deltaTime);        
    }
}
