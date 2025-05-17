using UnityEngine;
using System.Collections.Generic;

namespace Cariacity.Game
{
    /// <summary>
    /// GameManager is a singleton MonoBehaviour that holds global game data and helper methods.
    /// All configurable fields are exposed in the Inspector where possible.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        // Static instance for global access
        public static GameManager Instance { get; private set; }

        [Header("Grid Settings")]
        // The game grid (matrix) of cells.
        // Note: Multi-dimensional arrays cannot be edited in the Inspector, so this field is hidden.
        [HideInInspector]
        public GridCell[,] Matrix;

        [Header("Materials")]
        // Materials used for project validation.
        public Material RightProject;
        public Material WrongProject;

        [Header("City Data")]
        // The current city data.
        public City CurrentCity;

        [Header("Car Models")]
        // Array of car model prefabs.
        public GameObject[] CarModels;

        [Header("Tree Model")]
        // Tree model prefab.
        public GameObject TreeModel;

        [Header("Street Models")]
        // Models for various street types.
        public GameObject EndModel;
        public GameObject LineModel;
        public GameObject CornerModel;
        public GameObject TModel;

        [Header("Global Game Models")]
        // Global list of GameObjects for batch operations or global access.
        public List<GameObject> GameModels = new List<GameObject>();

        [Header("Game Constants")]
        // Various global configuration values.
        public int GridSize = 32;
        public float Hypotenuse = 10f;
        public float HalfHypotenuse = 5f;
        public float BackgroundTimer = 1f;
        public int TreeProbability = 20;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// Implements the singleton pattern and ensures the instance persists between scenes.
        /// </summary>
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// Dummy method to update the game's money.
        /// Replace with your actual implementation.
        /// </summary>
        public void UpdateMoney()
        {
            Debug.Log("Money Updated");
        }

        /// <summary>
        /// Dummy method to update the city's population.
        /// Replace with your actual implementation.
        /// </summary>
        public void UpdatePopulation()
        {
            Debug.Log("Population Updated");
        }

        /// <summary>
        /// Logs a message to the Unity console.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public void Log(string message)
        {
            Debug.Log(message);
        }

        /// <summary>
        /// Adds a GameObject model to the global list if it is not null.
        /// </summary>
        /// <param name="model">The model GameObject to add.</param>
        public void AddGameModel(GameObject model)
        {
            if (model != null)
            {
                GameModels.Add(model);
            }
            else
            {
                Debug.LogWarning("Attempted to add a null model to GameModels.");
            }
        }

        /// <summary>
        /// Dummy method that returns an identifier for the given model.
        /// Replace with your actual logic if needed.
        /// </summary>
        /// <param name="model">The GameObject model.</param>
        /// <returns>An integer representing the instance ID or 0 if null.</returns>
        public int GetGameModelID(GameObject model)
        {
            return model != null ? model.GetInstanceID() : 0;
        }
    }

    /// <summary>
    /// GridCell represents a single cell in the game grid.
    /// Marked as serializable to allow visualization in custom editors (if needed).
    /// </summary>
    [System.Serializable]
    public class GridCell
    {
        // Grid coordinates (i, j).
        public int i, j;
        // The center position of the cell in world space.
        public Vector3 center;
        // The object placed in this cell.
        public GameObject obj;
        // A type identifier for the object in the cell.
        public int type;
    }

    /// <summary>
    /// City holds information about the current city.
    /// Marked as serializable so that its values can be inspected in the Inspector.
    /// </summary>
    [System.Serializable]
    public class City
    {
        // The city's population.
        public int Population;
        // A list of home GameObjects in the city.
        public List<GameObject> HomeList = new List<GameObject>();

        /// <summary>
        /// Dummy method to calculate the progress of a home cell.
        /// Replace with your actual implementation.
        /// </summary>
        /// <param name="home">The home GameObject.</param>
        /// <returns>A dummy progress value (100f).</returns>
        public static float CalculateCellProgress(GameObject home)
        {
            // Dummy value, replace with real logic.
            return 100f;
        }
    }
}
