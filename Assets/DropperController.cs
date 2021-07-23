using UnityEngine;

public class DropperController : MonoBehaviour {

    // Serialize fields

    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private float variation = 3f;
    [SerializeField]
    private float interval = 0.3f;
    [SerializeField]
    private TMPro.TextMeshProUGUI debugLabel;
    [SerializeField]
    private float refreshStatsInterval = 2f;

    // Vars

    private int cubeNumber = 0;
    
    // Lifecycle

    void Start() {
        InvokeRepeating("Generate", 0f, interval);
        InvokeRepeating("RefreshStats", 0f, refreshStatsInterval);
    }

    // Private methods

    private void Generate() {
        Vector3 position = transform.position;
        position.x = position.x + Random.Range(-variation, variation);
        position.y = position.y + Random.Range(-variation, variation);
        position.z = position.z + Random.Range(-variation, variation);

        GameObject newCube = Instantiate(cube, position, Quaternion.identity);
        newCube.transform.parent = transform;
        newCube.transform.rotation = Random.rotation;

        cubeNumber++;
    }

    private void RefreshStats() {
        float fpsF = 1.0f / Time.deltaTime;
        int fps = (int) fpsF;
        debugLabel.text = "Cubes: " + cubeNumber + "\nFPS: " + fps;
    }
}
