using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Origin.World;

public class AdvancedStage : Stage {

    public int spawns;
    public float spawnDelay;
    public Shape[] shapes;
    public Transform[] spawnPoints;
    public string nextLevelID;

    private List<GameObject> onlineShapes = new List<GameObject>();
    RaycastHit2D hit;

    private void Start () {
        StartCoroutine (Processing());
    }

    private void Update () {
        if (!Config.isGameAvailable) return;
        if (Analytics.attempts == 0) { StopAllCoroutines (); EndStage(); }
        RepairOnlineShapes();
        Searching();
    }

    public void Spawn () {
        if (shapes.Length == 0) return;
        if (spawnPoints.Length == 0) return;
        onlineShapes.Add (Instantiate (shapes[Random.Range(0, shapes.Length)].gameObject, spawnPoints[Random.Range(0, spawnPoints.Length)]));
        Config.spawns--;
        GameEvents.UpdateSigns.Publish();
    }

    private IEnumerator Processing () {
        Config.isGameAvailable = false;
        Config.spawns = spawns;
        Analytics.attempts = 5;
        yield return new WaitForEndOfFrame();
        GameEvents.StageNameScreen.Publish();
        yield return new WaitForSeconds (2f);
        GameEvents.InGameScreen.Publish();
        GameEvents.UpdateSigns.Publish();
        yield return new WaitForSeconds (spawnDelay * 0.5f);
        Config.isGameAvailable = true;
        while (Analytics.attempts > 0) {
            if (Config.spawns > 0) {
                Spawn();
                yield return new WaitForSeconds (spawnDelay);
                spawns--;
            }
            if (Config.spawns == 0 && onlineShapes.Count == 0) {
                EndStage();
                StopAllCoroutines();
            }
            yield return null;
        }
        EndStage();
        yield return null;
    }

    private void Searching () {
        if (Input.GetMouseButtonDown(0)) {
            hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, LayerMask.NameToLayer("Shapes"));
            if (hit) {
                hit.collider.GetComponent<Shape>().Count();
            }
            else {
                if (Analytics.attempts >= 1) Analytics.attempts--;
            }
        }
    }

    private void RepairOnlineShapes () {
        onlineShapes.RemoveAll(item => item == null);
    }

    private void EndStage () {
        Config.isGameAvailable = false;
        foreach (GameObject shape in onlineShapes) Destroy (shape.gameObject);
        if (nextLevelID != "") {
            Config.stagePrefix = nextLevelID;
            GameEvents.FadeToEvent(GameEvents.StartGame);
        }
        else {
            Config.stagePrefix = "Level 1";
            GameEvents.FadeToEvent(GameEvents.EndGame);
        }
    }
}
