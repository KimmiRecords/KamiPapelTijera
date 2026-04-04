using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // ? AGREGAR using para TextMeshPro

public enum ResourceType
{
    hongos,
    flores,
    papel,
    botasAgua,
    botasRapidas,
    tijera,
    tijeraMejorada,
    abuela,
    Count
}

public class LevelManager : Singleton<LevelManager>
{
    public bool agency;
    public bool inDialogue;

    public Dictionary<ResourceType, int> recursosRecolectados = new Dictionary<ResourceType, int>();
    public Player player;
    public bool enablePCheat = false;

    // ========== NUEVAS VARIABLES PARA ASYNC LOADING ==========
    private AsyncOperation currentAsyncOperation;
    private bool _readyToGo;
    private string pendingSceneName = "";

    // ========== VARIABLES PARA DEBUG VISUAL ==========
    [Header("Debug UI")]
    [SerializeField] private TextMeshProUGUI debugText; // Asignar desde Inspector
    [SerializeField] private GameObject debugPanel; // Panel opcional para mostrar/ocultar debug
    [SerializeField] private bool showDebugInBuild = true; // Mostrar debug incluso en build

    private float lastDebugUpdateTime;
    private float debugUpdateInterval = 0.1f; // Actualizar debug cada 0.1 segundos

    protected override void Awake()
    {
        // Singleton pattern con DontDestroyOnLoad
        if (Instance != this && Instance != null)
        {
            Debug.Log("[LevelManager] Destroying duplicate instance");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // ? CRUCIAL para persistencia entre escenas
        Debug.Log("[LevelManager] Instance created with DontDestroyOnLoad");

        // Inicializar diccionario
        for (int i = 0; i < (int)ResourceType.Count; i++)
        {
            recursosRecolectados.Add((ResourceType)i, 0);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;

        //// Buscar debug UI si no está asignada
        //if (debugText == null)
        //{
        //    TryToFindDebugUI();
        //}

        UpdateDebugText("[LevelManager] Awake() completado - Persistente entre escenas");
    }

    private void Start()
    {
        UpdateDebugText("[LevelManager] Start() ejecutado");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateDebugText($"=== ESCENA CARGADA === {scene.name} | Modo: {mode}");

        // Ejecutar lógica específica según la escena
        switch (scene.name)
        {
            case "SampleScene":
                Debug.Log("[LevelManager] Detectada SampleScene - Iniciando audio");
                UpdateDebugText("SampleScene detectada - Iniciando audio");

                if (AudioManager.instance != null)
                {
                    AudioManager.instance.StopByName("IntroStoryboardLoop");
                    AudioManager.instance.PlayByName("MemoFloraMainLoop01");
                    AudioManager.instance.PlayByName("ForestAtDay");
                }
                else
                {
                    UpdateDebugText("WARNING: AudioManager.instance es NULL");
                }
                StartCoroutine(FindPlayerAfterSceneLoad());

                break;

            default:
                UpdateDebugText($"No hay lógica específica para la escena: {scene.name}");
                break;
        }
    }

    private void TryToFindDebugUI()
    {
        // Intentar encontrar automáticamente un TextMeshProUGUI en la escena
        debugText = FindObjectOfType<TextMeshProUGUI>();
        if (debugText != null)
        {
            UpdateDebugText("[LevelManager] Debug UI encontrada automáticamente");
        }
        else
        {
            Debug.LogWarning("[LevelManager] No se encontró TextMeshProUGUI en la escena. El debug visual no estará disponible.");
        }
    }

    private void UpdateDebugText(string message)
    {
        // Siempre loguear a consola
        Debug.Log($"[DEBUG] {message}");

        // Mostrar en UI si está disponible y estamos en build o editor con flag activado
        if (debugText != null && (showDebugInBuild || Application.isEditor))
        {
            // Agregar timestamp para mejor seguimiento
            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
            debugText.text = $"[{timestamp}]\n{message}\n\n{debugText.text}";

            // Limitar líneas para no saturar
            string[] lines = debugText.text.Split('\n');
            if (lines.Length > 30)
            {
                debugText.text = string.Join("\n", lines, 0, 30);
            }
        }

        // Activar panel debug si existe
        if (debugPanel != null && !debugPanel.activeSelf)
        {
            debugPanel.SetActive(true);
        }
    }

    public void Update()
    {
        // Debug visual periódico durante carga asíncrona
        if (currentAsyncOperation != null && Time.time - lastDebugUpdateTime > debugUpdateInterval)
        {
            lastDebugUpdateTime = Time.time;
            string status = $"AsyncOp activo | Progress: {(currentAsyncOperation.progress * 100):F1}% | isDone: {currentAsyncOperation.isDone} | allowSceneActivation: {currentAsyncOperation.allowSceneActivation} | _readyToGo: {_readyToGo} | Scene: {pendingSceneName}";
            UpdateDebugText(status);
        }

        // Cheats
        if (enablePCheat)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                UpdateDebugText("CHEAT: AllItemsCheat() activado");
                AllItemsCheat();
            }
        }

        if (Input.GetKey(KeyCode.LeftControl) && player != null)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                UpdateDebugText("CHEAT: AllItemsCheat() por Ctrl+P");
                AllItemsCheat();
            }

            if (Input.GetKeyDown(KeyCode.F12))
            {
                UpdateDebugText("DEBUG: Forzando carga a MainMenu");
                GoToScene("MainMenu");
            }

            // Debug: Tecla F11 para mostrar estado actual
            if (Input.GetKeyDown(KeyCode.F11))
            {
                string debugStatus = $"=== ESTADO ACTUAL ===\nAsyncOp: {(currentAsyncOperation != null ? "EXISTE" : "NULL")}\n";
                if (currentAsyncOperation != null)
                {
                    debugStatus += $"Progress: {currentAsyncOperation.progress}\nallowActivation: {currentAsyncOperation.allowSceneActivation}\nisDone: {currentAsyncOperation.isDone}\n";
                }
                debugStatus += $"_readyToGo: {_readyToGo}\nPendingScene: {pendingSceneName}";
                UpdateDebugText(debugStatus);
            }
        }
    }

    public void GiveSprintBoots()
    {
        UpdateDebugText("Dando botas de velocidad al player");
        if (player != null)
        {
            player.hasSprintBoots = true;
            AddResource(ResourceType.botasRapidas, 1);
        }
        else
        {
            UpdateDebugText("ERROR: player es NULL en GiveSprintBoots");
        }
    }

    public void GiveWaterBoots()
    {
        UpdateDebugText("Dando botas de agua al player");
        if (player != null)
        {
            player.hasWaterBoots = true;
            player.kamiRenderer.material = player.waterBootsMaterial;
            AddResource(ResourceType.botasAgua, 1);
        }
        else
        {
            UpdateDebugText("ERROR: player es NULL en GiveWaterBoots");
        }
    }

    public void GiveTijeraMejorada()
    {
        UpdateDebugText("Dando tijera mejorada al player");
        if (player != null)
        {
            player.hasTijera = true;
            player.GetTijeraMejorada();
            AddResource(ResourceType.tijeraMejorada, 1);
        }
        else
        {
            UpdateDebugText("ERROR: player es NULL en GiveTijeraMejorada");
        }
    }

    public void GoToScene(string sceneName)
    {
        UpdateDebugText($"GoToScene() llamado para: {sceneName} - Carga síncrona");
        SceneManager.LoadScene(sceneName);
    }

    public void StartAsyncLoadingOfNextScene(string sceneName)
    {
        UpdateDebugText($"=== INICIANDO CARGA ASÍNCRONA === Escena: {sceneName}");

        if (currentAsyncOperation != null)
        {
            UpdateDebugText($"WARNING: Ya había una carga en progreso para {pendingSceneName}. Cancelando y reiniciando.");
        }

        pendingSceneName = sceneName;
        _readyToGo = false;

        StartCoroutine(AsyncLoadScene(sceneName));
    }

    IEnumerator AsyncLoadScene(string sceneName)
    {
        UpdateDebugText($"Corrutina AsyncLoadScene iniciada para: {sceneName}");

        currentAsyncOperation = SceneManager.LoadSceneAsync(sceneName);
        currentAsyncOperation.allowSceneActivation = false;

        // Esperar hasta 90%
        while (currentAsyncOperation.progress < 0.9f)
        {
            yield return null;
        }

        UpdateDebugText($"Carga al 90%. Esperando señal _readyToGo...");

        // Esperar señal (con timeout)
        //float timeoutTimer = 0f;
        while (!_readyToGo/* && timeoutTimer < 10f*/)
        {
            //timeoutTimer += Time.deltaTime;
            yield return null;
        }

        // ACTIVAR ESCENA
        UpdateDebugText($"Activando escena {sceneName}...");
        currentAsyncOperation.allowSceneActivation = true;

        // ? LIMPIAR INMEDIATAMENTE - no esperamos isDone
        UpdateDebugText($"Escena activada. Limpiando estado...");
        currentAsyncOperation = null;
        pendingSceneName = "";
        _readyToGo = false;

        UpdateDebugText($"Proceso de carga completado (la escena ya debería ser visible)");
    }

    public void LoadThePreLoadedScene()
    {
        UpdateDebugText($"LoadThePreLoadedScene() llamado. _readyToGo era: {_readyToGo}, pendingScene: {pendingSceneName}");

        if (currentAsyncOperation == null)
        {
            UpdateDebugText($"WARNING: No hay ninguna operación asíncrona en curso. ¿Se llamó StartAsyncLoadingOfNextScene primero?");
            return;
        }

        _readyToGo = true;
    }

    public void AllItemsCheat()
    {
        UpdateDebugText("CHEAT: Activando todos los items y mejoras");
        AddResource(ResourceType.hongos, 100);
        AddResource(ResourceType.papel, 100);
        AddResource(ResourceType.flores, 100);
        GiveWaterBoots();
        GiveSprintBoots();
        GiveTijeraMejorada();
        UpdateDebugText("CHEAT: Todos los items agregados");
    }
    public void AddResource(ResourceType pickupType, int valueToAdd)
    {
        bool isAdding = valueToAdd >= 1;
        recursosRecolectados[pickupType] += valueToAdd;

        if (isAdding && valueToAdd > 0)
        {
            UpdateDebugText($"Recurso agregado: {pickupType} +{valueToAdd} (Total: {recursosRecolectados[pickupType]})");
        }

        EventManager.Trigger(Evento.OnResourceUpdated, pickupType, recursosRecolectados[pickupType], isAdding);
    }
    public void AddHealth(int curacion)
    {
        if (player != null)
        {
            player.GetCured(curacion);
            UpdateDebugText($"Player curado: +{curacion} HP");
        }
        else
        {
            UpdateDebugText($"ERROR: No se puede curar - player es NULL");
        }
    }
    public void GameObjectActivator(List<GameObject> gameObjectsToActivate, List<GameObject> gameObjectsToDeactivate)
    {
        foreach (GameObject go in gameObjectsToActivate)
        {
            if (go != null) go.SetActive(true);
        }
        foreach (GameObject go in gameObjectsToDeactivate)
        {
            if (go != null) go.SetActive(false);
        }
        UpdateDebugText($"GameObjectActivator ejecutado: Activados {gameObjectsToActivate.Count}, Desactivados {gameObjectsToDeactivate.Count}");
    }

    // ========== MÉTODO PARA RESETEAR ESTADO (opcional) ==========
    public void ResetAsyncState()
    {
        UpdateDebugText("ResetAsyncState() llamado - Limpiando estado de carga asíncrona");
        currentAsyncOperation = null;
        _readyToGo = false;
        pendingSceneName = "";
    }
    private IEnumerator FindPlayerAfterSceneLoad()
    {
        // Esperar un frame para que Unity instancie todos los objetos
        yield return null;

        // Buscar al player en la nueva escena
        player = FindObjectOfType<Player>();

        if (player != null)
        {
            UpdateDebugText($"Player encontrado en {gameObject.scene.name}: {player.name}");
        }
        else
        {
            UpdateDebugText("WARNING: No se encontró Player en la escena");
            // Seguir intentando por unos segundos
            float timeout = 0;
            while (player == null && timeout < 3f)
            {
                timeout += Time.deltaTime;
                yield return null;
                player = FindObjectOfType<Player>();
            }

            if (player != null)
            {
                UpdateDebugText($"Player encontrado después de {timeout:F1} segundos");
            }
            else
            {
                UpdateDebugText("ERROR: No se pudo encontrar Player después de 3 segundos");
            }
        }
    }

    private void OnDestroy()
    {
        UpdateDebugText($"LevelManager siendo destruido. Escena actual: {gameObject.scene.name}");

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}