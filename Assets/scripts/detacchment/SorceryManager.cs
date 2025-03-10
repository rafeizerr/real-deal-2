using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SorceryManager : MonoBehaviour
{

    SealManager[] seals;

    public bool initiate;
    bool firstCast;
    bool secondCast;
    bool thirdCast;
    bool terminate;
    bool begin;
    bool end;


    public bool isRed = false;
    public bool isYel = false;
    public bool isBlu = false;

    int red = 1;
    int yel = 2;
    int blu = 3;

    public static float spellTimer = 0;
    public int spellLimit = 20;

    public static float spellPoints = 0;
    public bool isCasting = false;

    public bool isReCasting = false;

    public int[] _spellArray = new int[4];
    public int sequenceIndex;
    public int recastIndex;
    public float randomNumber;

    [SerializeField] private Sprite[] command;
    public Image commandImage;
    int commandIndex;

    public static int levelIndex = 1;

    public GameObject powerBar;

    public GameObject wand;

    public int levelInspector;

    public GameObject sealPrefab;

    public GameObject magicPrefab;

    GameObject magicPrefabInstance;

    public static bool destroyedSeal;

    int sealRequirement;



    // Start is called before the first frame update
    void Start()
    {
        //os pontos ao realizar um feitico simples = 100;
        //esses pontos sao sempre multiplicados pelo index de repeticao
        //como index de repeticao sem repeticao alguma = 1
        //100 * 1 = 100
        //o level index aumenta sempre que um selo e destruido
        //inicialente o index = 1
        // 100 * 1 = 100
        //o requerimento inicial = pontos recebidos ao realizar um reitico simples
        //quanto mais selos forem destruidos maior o level index e maior o requerimento
        //quanto maior o requerimento maior o numero de repeticoes
        sealRequirement = 100 * levelIndex;
        wand.SetActive(false);
        powerBar.SetActive(false);
        ChangeCommands();
        recastIndex = 1;

        //sequenceindex aumenta sempre que um comando magico e dado
        //como feiticos sao constituidos de 3 comandos o maximo do sequenceindex é 3
        //sequenceindex = 3 determina que o maximo de comandos foi dado
        sequenceIndex = 0;
        for (int i = 0; i <= 3; i++)
        {
            _spellArray[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (destroyedSeal == true)
        {
            destroyedSeal = false;
            DeactivateWand();
            ResetSpell();
            levelIndex++;
        }
        levelInspector = levelIndex;


        initiate = Input.GetKeyDown(KeyCode.X);
        begin = Input.GetKeyDown(KeyCode.RightArrow);
        terminate = Input.GetKeyDown(KeyCode.Z);

        if (randomNumber == 0)
        {
            commandIndex = 0;
            commandImage.sprite = command[commandIndex];
            firstCast = Input.GetKeyDown(KeyCode.Q);
            secondCast = Input.GetKeyDown(KeyCode.W);
            thirdCast = Input.GetKeyDown(KeyCode.E);
        }
        if (randomNumber == 1)
        { //SOV
            commandIndex = 1;
            commandImage.sprite = command[commandIndex];
            firstCast = Input.GetKeyDown(KeyCode.Q);
            secondCast = Input.GetKeyDown(KeyCode.E);
            thirdCast = Input.GetKeyDown(KeyCode.W);

        }
        else if (randomNumber == 2)
        { //VSO
            commandIndex = 2;
            commandImage.sprite = command[commandIndex];
            firstCast = Input.GetKeyDown(KeyCode.W);
            secondCast = Input.GetKeyDown(KeyCode.Q);
            thirdCast = Input.GetKeyDown(KeyCode.E);

        }
        else if (randomNumber == 3)
        { //OVS
            commandIndex = 3;
            commandImage.sprite = command[commandIndex];
            firstCast = Input.GetKeyDown(KeyCode.E);
            secondCast = Input.GetKeyDown(KeyCode.W);
            thirdCast = Input.GetKeyDown(KeyCode.Q);
        }

        if (initiate)
        {
            destroyedSeal = false;
            isCasting = true;
            //ChangeCommands();
        }

        if (terminate)
        {
            if (sequenceIndex == 3)
            {
                isCasting = false;
                if (_spellArray[0] == 1 && _spellArray[1] == 2 && _spellArray[3] == 3)
                {
                    spellPoints = 100;
                    spellPoints *= recastIndex;
                    DisplaySeal();
                }
                else
                {
                    ResetSpell();
                }
            }
            else
            {
                ResetSpell();
            }


        }

        if (isCasting)
        {
            spellTimer += Time.deltaTime;
            if (spellTimer >= spellLimit)
            {
                ResetSpell();
            }
            else
            {
                spellTimer += Time.deltaTime;
            }
        }

        if (isCasting)
        {
            if (Input.GetKeyDown(KeyCode.Space) && _spellArray[0] == 1 && _spellArray[1] == 0 && _spellArray[3] == 0)
            {
                //_spellArray[2] += recastIndex * 2;
                _spellArray[2] += 1;
            }

            if (firstCast || secondCast || thirdCast)
            {
                StartCoroutine(MagicCommand());
            }

            if (firstCast)
            {
                if (sequenceIndex == 0)
                {
                    _spellArray[0] += red;
                    sequenceIndex += 1;
                    //Debug.Log("arroz");
                }
                else if (sequenceIndex == 1)
                {
                    _spellArray[1] += red;
                    sequenceIndex += 1;
                    //Debug.Log("feijao");
                }
                else if (sequenceIndex == 2)
                {
                    _spellArray[3] += red;
                    sequenceIndex += 1;
                    //Debug.Log("batata");
                }
            }

            if (secondCast)
            {
                if (sequenceIndex == 0)
                {
                    _spellArray[0] += yel;
                    sequenceIndex += 1;
                    //Debug.Log("arroz");
                }
                else if (sequenceIndex == 1)
                {
                    _spellArray[1] += yel;
                    sequenceIndex += 1;
                    //Debug.Log("feijao");
                }
                else if (sequenceIndex == 2)
                {
                    _spellArray[3] += yel;
                    sequenceIndex += 1;
                    //Debug.Log("batata");
                }
            }

            if (thirdCast)
            {
                if (sequenceIndex == 0)
                {
                    _spellArray[0] += blu;
                    sequenceIndex += 1;
                    //Debug.Log("arroz");
                }
                else if (sequenceIndex == 1)
                {
                    _spellArray[1] += blu;
                    sequenceIndex += 1;
                    //Debug.Log("feijao");
                }
                else if (sequenceIndex == 2)
                {
                    _spellArray[3] += blu;
                    sequenceIndex += 1;
                    //Debug.Log("batata");
                }
            }

            if (end)
            {
                isReCasting = true;
                recastIndex++;
                //Debug.Log("oi tudo bem");
            }

            if (isReCasting)
            {
                begin = Input.GetKey(KeyCode.RightArrow);
                if (begin)
                {
                    isReCasting = false;
                    spellTimer = 0;
                    sequenceIndex = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        _spellArray[i] = 0;
                    }
                    ChangeCommands();
                }

            }

            if (_spellArray[2] == 1 && _spellArray[3] == 3)
            {
                end = Input.GetKeyDown(KeyCode.LeftArrow);
                //Debug.Log("macarrao");
            }


        }

    }
    public void ResetSpell()
    {
        spellTimer = 0;
        isCasting = false;
        spellPoints = 0;
        for (int i = 0; i <= 3; i++)
        {
            _spellArray[i] = 0;
        }
        sequenceIndex = 0;
        //isYel = isBlu = isRed = false;
    }


    void DisplaySeal()
    {
        if (spellPoints >= sealRequirement)
        {
            //Debug.Log("te amo");
            BeginPurge();
            Instantiate(sealPrefab, transform);
        }
    }


    void ChangeCommands()
    {
        randomNumber = Random.Range(0, 3);
    }

    void BeginPurge()
    {
        wand.SetActive(true);
        powerBar.SetActive(true);
    }

    public void EndPurge()
    {
        wand.SetActive(false);
        powerBar.SetActive(false);
    }

    public void DeactivateWand()
    {
        wand.SetActive(false);
    }

    IEnumerator MagicCommand()
    {
        magicPrefabInstance = Instantiate(magicPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(magicPrefabInstance);
    }
}
