using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnerController : MonoBehaviour
{
    public GameObject HumanPrefab;
    public GameObject PinkyPrefab;
    public GameObject SpawnPrefab;
    public GameObject BaronPrefab;

    public List<GameObject> Spots;

    private GameObject[] _enemys;
    private int _spawnCount;
    private int _counter;
    private int _spotCounter;

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        _enemys = new GameObject[10];
        //Spots = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _enemys.Length; i++)
        {
            if (_enemys[i] == null)
            {
                if (_spawnCount < 20)
                {
                    _enemys[i] = Instantiate(HumanPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                }
                else if (_spawnCount < 40)
                {
                    if (_counter >= 2)
                    {
                        _enemys[i] = Instantiate(PinkyPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 3);
                    }
                    else
                    {
                        _enemys[i] = Instantiate(HumanPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 3);
                    }
                }
                else if (_spawnCount < 60)
                {
                    if (_counter == 2)
                    {
                        _enemys[i] = Instantiate(SpawnPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 4);
                    }
                    else if (_counter == 3)
                    {
                        _enemys[i] = Instantiate(PinkyPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 4);
                    }
                    else
                    {
                        _enemys[i] = Instantiate(HumanPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 4);
                    }
                }
                else
                {
                    if (_counter == 4 || _counter == 5)
                    {
                        _enemys[i] = Instantiate(SpawnPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 9);
                    }
                    else if (_counter == 6 || _counter == 7)
                    {
                        _enemys[i] = Instantiate(PinkyPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 9);
                    }
                    else if (_counter == 8)
                    {
                        _enemys[i] = Instantiate(BaronPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 9);
                    }
                    else
                    {
                        _enemys[i] = Instantiate(HumanPrefab, Spots[_spotCounter].transform.position, transform.rotation);
                        _counter = Random.Range(0, 9);
                    }
                }
                _spawnCount++;
                _spotCounter++;
                if (_spotCounter >= Spots.Count)
                {
                    _spotCounter= 0;
                }
                _enemys[i].GetComponent<EnemyContoller>().Player = Player;
            }
        }
    }
}
