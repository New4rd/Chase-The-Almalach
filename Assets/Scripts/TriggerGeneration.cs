using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGeneration : MonoBehaviour
{
    LevelGenerator generator = LevelGenerator.Inst;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // indice de la dernière partie de niveau générée
        int lastGeneration = generator.lastGeneration;

        // indice de la prochaine partie de niveau à générer, tiré aléatoirement
        int nextGeneration = generator.successiveGenerableParts[lastGeneration-1][Random.Range(0, generator.successiveGenerableParts[lastGeneration - 1].Count)];

        if (generator.flatRoadGeneration) generator.Generation(1);

        else
        {
            generator.Generation(nextGeneration);
        }
    }


    private IEnumerator OnTriggerExit2D(Collider2D collision)
    {
        yield return new WaitForSecondsRealtime(1);
        LevelGenerator.Inst.PopLastGeneration();
    }
}
