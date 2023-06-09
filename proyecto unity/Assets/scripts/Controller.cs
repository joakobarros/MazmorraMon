using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
 
public class Controller : MonoBehaviour
{
    public int populationSize = 50;
    public GameObject creaturePrefab;
    public List<GameObject> population;
    public float populationLifetime = 5.0f;
    public int mutationRate; // Chance of a mutation occuring, 0 - 100%
 
    public Text generationText;
    private int currentGeneration = 1;
    public Text timeText;
    private float lifetimeLeft;
 
    // Start is called before the first frame update
    void Start()
    {
        // Initialise a random starting population
        InitialisePopulation();
 
        // For each population Lifetime, breed a new generation, this will repeat indefinitely
        InvokeRepeating("BreedPopulation", populationLifetime, populationLifetime);
 
        // Set the value so we can show a countdown for each population
        lifetimeLeft = populationLifetime;
    }
 
    // Update is called once per frame
    void Update()
    {
        // Update the text showing what generation we're on
        generationText.text = "Generation " + currentGeneration;
 
        // Perform a countdown, showing the lifetime of the current population, reset on breeding
        lifetimeLeft -= Time.deltaTime;
        timeText.text = "Time " + (lifetimeLeft).ToString("0");
    }
 
    /**
     * Initialises the population
     */
    private void InitialisePopulation()
    {
        for (int i = 0; i < populationSize; i++)
        {
            // Choose a random position for the creature to appear
            Vector2 pos = new Vector2(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f));
 
            // Instantiate a new creature
            GameObject creature = Instantiate(creaturePrefab, pos, Quaternion.identity);
 
            // Set the colour of the creature
            DNA creatureDNA = creature.GetComponent<DNA>();
            creatureDNA.r = Random.Range(0.0f, 1.0f);
            creatureDNA.g = Random.Range(0.0f, 1.0f);
            creatureDNA.b = Random.Range(0.0f, 1.0f);
 
            creature.GetComponent<SpriteRenderer>().color = new Color(creatureDNA.r, creatureDNA.g, creatureDNA.b);
 
            // Add the creature to the population
            population.Add(creature);
        }
    }
 
    private void BreedPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject>();
 
        // Remove unfit individuals, by sorting the list by the most red creatures first
        List<GameObject> sortedList = population.OrderByDescending(o => o.GetComponent<DNA>().r).ToList();
 
        population.Clear();
 
        // then breeding only the most red creatures
        int halfOfPopulation = (int)(sortedList.Count / 2.0f);
        for (int i = halfOfPopulation - 1; i < sortedList.Count - 1; i++)
        {
            // Breed two creatures
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i+1], sortedList[i]));
 
        }
 
        // Then destroy all of the original creatures
        for(int i = 0; i < sortedList.Count; i++)
        {
            Destroy(sortedList[i]);
        }
 
        lifetimeLeft = populationLifetime;
        currentGeneration++;
    }
 
    // Breeds a new creature using the DNA of the two parents
    private GameObject Breed(GameObject parent1, GameObject parent2)
    {
        Vector2 pos = new Vector2(Random.Range(-9, 9), Random.Range(-4.5f, 4.5f));
 
        // Create a new creature and get a reference to its DNA
        GameObject offspring = Instantiate(creaturePrefab, pos, Quaternion.identity);
        DNA offspringDNA = offspring.GetComponent<DNA>();
 
        // Get the parents DNA
        DNA dna1 = parent1.GetComponent<DNA>();
        DNA dna2 = parent2.GetComponent<DNA>();
         
        // Get a mix of the parents DNA majority of the time, dependant on mutation chance
        if (mutationRate <= Random.Range(0, 100))
        {
            // Pick a range between 0 - 10, if it's less than 5 then pick parent1's DNA, otherwise pick parent 2's
            offspringDNA.r = Random.Range(0, 10) < 5 ? dna1.r : dna2.r;
            offspringDNA.g = Random.Range(0, 10) < 5 ? dna1.g : dna2.g;
            offspringDNA.b = Random.Range(0, 10) < 5 ? dna1.b : dna2.b;
        }
        else
        {
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                offspringDNA.r = Random.Range(0.0f, 1.0f);
                offspringDNA.g = Random.Range(0, 10) < 5 ? dna1.g : dna2.g;
                offspringDNA.b = Random.Range(0, 10) < 5 ? dna1.b : dna2.b;
            }
            else if (random == 1)
            {
                offspringDNA.r = Random.Range(0, 10) < 5 ? dna1.r : dna2.r;
                offspringDNA.g = Random.Range(0.0f, 1.0f);
                offspringDNA.b = Random.Range(0, 10) < 5 ? dna1.b : dna2.b;
            }
            else
            {
                offspringDNA.r = Random.Range(0, 10) < 5 ? dna1.r : dna2.r;
                offspringDNA.g = Random.Range(0, 10) < 5 ? dna1.g : dna2.g;
                offspringDNA.b = Random.Range(0.0f, 1.0f);
            }
        }
 
        offspring.GetComponent<SpriteRenderer>().color = new Color(offspringDNA.r, offspringDNA.g, offspringDNA.b);
 
        return offspring;
    }
}