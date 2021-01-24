using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    static private LevelGenerator _inst;
    static public LevelGenerator Inst
    {
        get { return _inst; }
    }


    public bool flatRoadGeneration = false;
    public int lastGeneration;


    List<GameObject> levelList;
    int generationIteration = 0;
    float levelPartSize = 30;


    // Liste des parties de niveaux successivement générables
    [SerializeField] public List<List<int>> successiveGenerableParts;


    private void Awake()
    {
        _inst = this;
        levelList = new List<GameObject>();
        SuccessiveGenerablePartsInitialization();
    }


    private void Start()
    {
        InitialGeneration();
    }


    private void InitialGeneration()
    {
        Generation(1);
        Generation(1);
    }


    public void Generation (int partNumber)
    {
        GameObject partPrefab = (GameObject)Resources.Load("Prefabs/Level Parts/Level Part " + partNumber.ToString());
        Vector3 instPos = new Vector3(levelPartSize * generationIteration, 0, 0);
        GameObject partInst = Instantiate(partPrefab, instPos, Quaternion.identity);
        SetAsChild(partInst);
        levelList.Add(partInst);
        generationIteration++;
        lastGeneration = partNumber;
    }


    public void PopLastGeneration()
    {
        Destroy(levelList[0]);
        levelList.RemoveAt(0);
    }


    private void SetAsChild (GameObject obj)
    {
        obj.transform.parent = this.transform;
    }


    private void SuccessiveGenerablePartsInitialization ()
    {
        successiveGenerableParts = new List<List<int>>();

        List<int> successivePart1 = new List<int> { 2 };
        List<int> successivePart2 = new List<int> { 1, 3 };
        List<int> successivePart3 = new List<int> { 1, 2 };

        successiveGenerableParts.Add(successivePart1);
        successiveGenerableParts.Add(successivePart2);
        successiveGenerableParts.Add(successivePart3);
    }
}
