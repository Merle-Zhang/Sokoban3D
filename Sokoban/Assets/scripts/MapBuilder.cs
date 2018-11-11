using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBuilder : MonoBehaviour
{

    public Canvas canvas;

    public Canvas canvasmune;

    public Canvas cong;


    public GameObject maphold;
    public char[,,] map;


    // h > worker, w > wall, g > goal,  > blank
    public char[,,] easy = new char[5, 5, 5] {
        {
            {' ', ' ', ' ', ' ', ' '},
            {' ', 'w', 'w', 'w', 'w'},
            {' ', 'w', 'w', 'w', 'w'},
            {' ', 'w', 'w', 'w', 'w'},
            {' ', 'w', 'w', 'w', 'w'}
        },
        {
            {' ', 'w', 'w', 'w', 'w'},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '},
            {'w', 'h', ' ', ' ', ' '}
        },
        {
            {' ', 'w', 'w', 'w', 'w'},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', 'b', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '}
        },
        {
            {' ', 'w', 'w', 'w', 'w'},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '}
        },
        {
            {' ', 'w', 'w', 'w', 'w'},
            {'w', ' ', ' ', ' ', 'g'},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '},
            {'w', ' ', ' ', ' ', ' '}
        },
    };

    public char[,,] noeasy = new char[,,]{
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', 'w', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', 'w', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', ' ', 'h', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'b', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', 'b', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', 'w', 'w', 'w', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' ', ' '},
                {' ', ' ', 'w', 'w', 'w', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', 'g', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', 'b', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', 'w', 'w', 'w', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'g', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', 'w', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', 'w', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '}
            },
            {
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', 'w', 'w', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', 'g', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', 'w', ' '},
                {' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' ', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', 'w', ' ', ' ', ' ', ' '}
            }
        };

    public GameObject worker;
    public GameObject wall;
    public GameObject box;
    public GameObject goal;

    public GameObject[] walls;
    public GameObject[] boxes;
    public GameObject[] goals;

    int blockSize = 1;  // size of each block

    // Use this for initialization
    void Start()
    {
        canvasmune.gameObject.SetActive(false);
        cong.gameObject.SetActive(false);
        // map = noeasy;
        // map = easy;
        // Given an 3D array 

    }

    // Update is called once per frame

    public void backmune(){
        canvas.gameObject.SetActive(true);
        canvasmune.gameObject.SetActive(false);
    }

    public void setmap(int i)
    {
        canvas.gameObject.SetActive(false);
        cong.gameObject.SetActive(false);
        canvasmune.gameObject.SetActive(true);
        if (i == 1)
        {
            map = easy;
        }
        if (i == 2)
        {
            map = noeasy;
        }
        int countbox = 0; // # of boxes / goals
        int countwall = 0;

        foreach (char c in map)
        {
            if (c == 'b')
                countbox++;
            if (c == 'w')
                countwall++;
        }
        if (boxes != null && goals != null)
        {
            wall.SetActive(true);
            box.SetActive(true);
            worker.SetActive(true);
            goal.SetActive(true);
            foreach(Transform child in maphold.transform){
                Destroy(child.gameObject);
            }
            // Deactivate(boxes);
            // Deactivate(goals);
            // Deactivate(walls);
            // foreach (GameObject o in boxes)
            //     o.SetActive(false);
            // foreach (GameObject o in goals)
            //     o.SetActive(false);
            // foreach (GameObject o in walls)
            //     o.SetActive(false);
        }
        boxes = new GameObject[countbox];
        goals = new GameObject[countbox];

        walls = new GameObject[countwall];

        int flagBoxes = 0;
        int flagGoals = 0;
        int flagWall = 0;

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int z = 0; z < map.GetLength(2); z++)
                {
                    GameObject g = null;
                    if (map[y, x, z] == 'w')
                    {
                        g = Instantiate(wall);
                        walls[flagWall] = g;
                        

                        InitializeWall(walls[flagWall], x, y, z);
                        flagWall++;
                    }
                    if (map[y, x, z] == 'b')
                    {
                        g = Instantiate(box);
                        boxes[flagBoxes] = g;
                        InitializeCube(boxes[flagBoxes], x, y, z);
                        flagBoxes++;
                    }
                    if (map[y, x, z] == 'g')
                    {
                        g = Instantiate(goal);
                        goals[flagGoals] = g;
                        InitializeCube(goals[flagGoals], x, y, z);
                        flagGoals++;
                    }
                    if (map[y, x, z] == 'h')
                    {
                        // print("worker");
                        // worker = new GameObject("worker");
                        // worker.AddComponent<Renderer>();
                        InitializeWorker(worker, x, y, z);
                    }
                    if (g != null)
                    g.transform.parent = maphold.transform;
                }
            }
        }
        Deactivate(box);
        Deactivate(wall);
        // Deactivate(worker);
        Deactivate(goal);





        // For each x
        // For each y
        // For each z

        // if box here, then {
        // Instantiate
        //GameObject m = GameObject.Instantiate(model);
        //Transform t = m.transform;
        //Vector3 p = t.position;

        //}
    }

    void Update()
    {
        
        if (goals.Length != 0 && checkwin()){
            cong.gameObject.SetActive(true);
            canvasmune.gameObject.SetActive(true);
            return;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (GameObject tbox in boxes)
            {
                if (worker.GetComponent<Transform>().position + new Vector3(-1, 0, 0) == tbox.GetComponent<Transform>().position)
                {
                    ValidifyMove(tbox, new Vector3(-1, 0, 0));
                }
            }
            ValidifyMove(worker, new Vector3(-1, 0, 0));

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (GameObject tbox in boxes)
            {
                if (worker.GetComponent<Transform>().position + new Vector3(1, 0, 0) == tbox.GetComponent<Transform>().position)
                    ValidifyMove(tbox, new Vector3(1, 0, 0));
            }
            ValidifyMove(worker, new Vector3(1, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (GameObject tbox in boxes)
            {
                if (worker.GetComponent<Transform>().position + new Vector3(0, 0, -1) == tbox.GetComponent<Transform>().position)
                    ValidifyMove(tbox, new Vector3(0, 0, -1));
            }
            ValidifyMove(worker, new Vector3(0, 0, -1));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach (GameObject tbox in boxes)
            {
                if (worker.GetComponent<Transform>().position + new Vector3(0, 0, 1) == tbox.GetComponent<Transform>().position)
                    ValidifyMove(tbox, new Vector3(0, 0, 1));
            }
            ValidifyMove(worker, new Vector3(0, 0, 1));
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            foreach (GameObject tbox in boxes)
            {
                if (worker.GetComponent<Transform>().position + new Vector3(0, 1, 0) == tbox.GetComponent<Transform>().position)
                    ValidifyMove(tbox, new Vector3(0, 1, 0));
            }
            ValidifyMove(worker, new Vector3(0, 1, 0));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach (GameObject tbox in boxes)
            {
                if (worker.GetComponent<Transform>().position + new Vector3(0, -1, 0) == tbox.GetComponent<Transform>().position)
                    ValidifyMove(tbox, new Vector3(0, -1, 0));
            }
            ValidifyMove(worker, new Vector3(0, -1, 0));
        }

    }


    bool checkwin(){
         int goalflags = 0;
        foreach(GameObject tgoal in goals)
            foreach(GameObject tbox in boxes){
                if(tgoal.GetComponent<Transform>().position.Equals(tbox.GetComponent<Transform>().position))
                    goalflags++;
            }
        if (goals.Length == goalflags)
            return true;
        return false;
    }



    void InitializeWall(GameObject box, int x, int y, int z)
    {
        // box.AddComponent<Renderer>();
        Vector3 size = box.GetComponent<Renderer>().bounds.size;
        box.GetComponent<Transform>().localScale = new Vector3(blockSize / size.x, blockSize / size.y, blockSize / size.z);
        box.GetComponent<Transform>().position = new Vector3(x * blockSize, y * blockSize, z * blockSize);
    }

    void InitializeCube(GameObject box, int x, int y, int z)
    {
        // box.AddComponent<MeshRenderer>();
        // // box.AddComponent<LineRenderer>();
        // Vector3 size = box.GetComponent<Renderer>().bounds.size;
        // print( box.GetComponent<Renderer>());
        // box.GetComponent<Transform>().localScale = new Vector3(blockSize / size.x, blockSize / size.y, blockSize / size.z);
        box.GetComponent<Transform>().position += new Vector3(x * blockSize, y * blockSize, z * blockSize);
    }

    void InitializeWorker(GameObject box, int x, int y, int z)
    {
        // box.AddComponent<MeshRenderer>();
        // Vector3 size = box.GetComponent<Renderer>().bounds.size;
        // box.GetComponent<Transform>().localScale = new Vector3(blockSize / size.y, blockSize / size.y, blockSize / size.y);
        box.GetComponent<Transform>().position = new Vector3(x * blockSize, y * blockSize, z * blockSize);
    }

    void Deactivate(GameObject o)
    {
        o.SetActive(false);
    }

    void Deactivate(GameObject[] arr){
        foreach(GameObject o in arr)
            o.SetActive(false);
    }

    void ValidifyMove(GameObject o, Vector3 mov)
    {
        Vector3 pos = o.GetComponent<Transform>().position + mov;
        foreach (GameObject wall in walls)
        {
            if (wall.GetComponent<Transform>().position == pos)
                return;
        }
        // if ((int)pos.y < map.GetLength(0) && (int)pos.x < map.GetLength(1) && (int)pos.z < map.GetLength(2))
        //     if(map[(int)pos.x, (int)pos.y, (int)pos.z] != 'w')
        o.GetComponent<Transform>().position += mov;
    }

}
