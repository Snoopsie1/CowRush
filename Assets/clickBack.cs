using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class clickBack : MonoBehaviour
{
    public GameObject cube;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (cube == getClickedObject(out RaycastHit hit)) {
                loadScene("worldSelector");
            }
        }
    }

    GameObject getClickedObject (out RaycastHit hit) {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray.origin, ray.direction * 10, out hit)) {
            if (!isPointerOverUIObject()){ target = hit.collider.gameObject; }
        }
        return target;
    }
    private bool isPointerOverUIObject() {
        PointerEventData ped = new PointerEventData(EventSystem.current);
        ped.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(ped, results);
        return results.Count > 0;
    }

    public void loadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

}
