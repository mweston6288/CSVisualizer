using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class NQueens : Algorithm
{
    int n;
    bool solution;
    int [,] internalBoard; // tracks how many queens can move to each tile on the board
    GameObject[,] board;
    [SerializeField] GameObject boxPrefab;
    [SerializeField] GameObject canvas;
    protected TMP_Text showText;

    // Start is called before the first frame update
    public void setup(int n)
    {
        this.n = n;
        board = new GameObject[n,n];
        internalBoard = new int[n,n];
        solution = false;
        showText = canvas.transform.GetChild(5).GetComponent<TMP_Text>();

        int i,j;
        TextMeshPro t;

        for(i = 0; i < n; i++){
            for(j = 0; j < n; j++){
                board[i,j] = GameObject.Instantiate(boxPrefab);// CREATE CUBES
                t = board[i,j].GetComponentInChildren<TextMeshPro>();
                t.text = "";
                if ((i + j) % 2 == 1){
                    board[i,j].GetComponent<Renderer>().material.color = Color.gray;
                    internalBoard[i,j] = 0;
                }
                // The sortable's default dimensions are 1.28 x 1.28 so position is adjusted accordingly
                board[i,j].transform.position = new Vector3(i * 1.28f, (n-j) * 1.28f, 0);
            }
        }
        setCam();
    }
    public void setCam()
    {
        Camera.main.transform.position = new Vector3(n / 2, n / 2 + 2, -n * 3 / 2 - 2);
        //Camera.main.farClipPlane = (float)(-1.1*z + 200);
    }
    public IEnumerator build(int column){
        yield return new WaitForSeconds(time);
        showText.text = "Test";
        showText.color = Color.black;
        if (column == n) {
			solution = true;
            yield break;
		}
        int i, j, k;
        TextMeshPro t;

        for (i = 0; i < n; i++){
            board[i, column].GetComponent<Renderer>().material.color = Color.blue;
            yield return new WaitForSeconds(time);
            setColor(i, column);
            // a safe space
            if(internalBoard[i, column] == 0){
                // increment the row and column
                for (j = 0; j < n; j++){
                    internalBoard[i, j]++;
                    internalBoard[j, column]++;
                    if ((i + j) % 2 == 1){
                        board[i,j].GetComponent<Renderer>().material.color = new Color(.67f,0,0);
                    }
                    else{
                        board[i,j].GetComponent<Renderer>().material.color = Color.red;
                    }

                    if((j + column) % 2 == 1 ){
                        board[j,column].GetComponent<Renderer>().material.color = new Color(.67f,0,0);

                    }
                    else{
                        board[j,column].GetComponent<Renderer>().material.color = Color.red;
                    }

                }
                // top left diagonal
				for (j = i, k = column;j >= 0 && k>= 0 ;j--,k--){
					internalBoard[j,k]++;
                    if((j + k) % 2 == 1 ){
                        board[j,k].GetComponent<Renderer>().material.color = new Color(.67f,0,0);

                    }
                    else{
                        board[j,k].GetComponent<Renderer>().material.color = Color.red;
                    }
				}
				// bottom left diagonal
				for (j = i, k = column; j >= 0 && k < n; j--, k++) {
					internalBoard[j,k]++;
                    if((j + k) % 2 == 1 ){
                        board[j,k].GetComponent<Renderer>().material.color = new Color(.67f,0,0);

                    }
                    else{
                        board[j,k].GetComponent<Renderer>().material.color = Color.red;
                    }				}
				// top right diagonal
				for (j = i, k = column; j < n && k >= 0; j++, k--) {
					internalBoard[j,k]++;
                    if((j + k) % 2 == 1 ){
                        board[j,k].GetComponent<Renderer>().material.color = new Color(.67f,0,0);

                    }
                    else{
                        board[j,k].GetComponent<Renderer>().material.color = Color.red;
                    }
				}
				// bottom right diagonal
				for (j = i, k = column; j < n && k < n; j++, k++) {
					internalBoard[j,k]++;
                    if((j + k) % 2 == 1 ){
                        board[j,k].GetComponent<Renderer>().material.color = new Color(.67f,0,0);

                    }
                    else{
                        board[j,k].GetComponent<Renderer>().material.color = Color.red;
                    }
				}

                board[i,column].GetComponent<Renderer>().material.color = Color.green;
                t = board[i,column].GetComponentInChildren<TextMeshPro>();
                t.text = "Q";
                yield return build(column +1 );
                if (solution)
                    yield break;
                 t.text = "";               
                for (j = 0; j < n; j++){
                    internalBoard[i, j]--;
                    if (internalBoard[i,j] == 0){
                        if ((i + j) % 2 == 1){
                            board[i,j].GetComponent<Renderer>().material.color = Color.gray;
                        }
                        else{
                            board[i,j].GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
                    internalBoard[j, column]--;
                    if (internalBoard[j,column] == 0){
                        if ((column + j) % 2 == 1){
                            board[j,column].GetComponent<Renderer>().material.color = Color.gray;
                        }
                        else{
                            board[j,column].GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
                }
                // top left diagonal
				for (j = i, k = column;j >= 0 && k>= 0 ;j--,k--){
					internalBoard[j,k]--;
                    if (internalBoard[j,k] == 0){
                        if ((k + j) % 2 == 1){
                            board[j,k].GetComponent<Renderer>().material.color = Color.gray;
                        }
                        else{
                            board[j,k].GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
				}
				// bottom left diagonal
				for (j = i, k = column; j >= 0 && k < n; j--, k++) {
					internalBoard[j,k]--;
                    if (internalBoard[j,k] == 0){
                        if ((k + j) % 2 == 1){
                            board[j,k].GetComponent<Renderer>().material.color = Color.gray;
                        }
                        else{
                            board[j,k].GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
				}
				// top right diagonal
				for (j = i, k = column; j < n && k >= 0; j++, k--) {
					internalBoard[j,k]--;
                    if (internalBoard[j,k] == 0){
                        if ((k + j) % 2 == 1){
                            board[j,k].GetComponent<Renderer>().material.color = Color.gray;
                        }
                        else{
                            board[j,k].GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
				}
				// bottom right diagonal
				for (j = i, k = column; j < n && k < n; j++, k++) {
					internalBoard[j,k]--;
                    if (internalBoard[j,k] == 0){
                        if ((k + j) % 2 == 1){
                            board[j,k].GetComponent<Renderer>().material.color = Color.gray;
                        }
                        else{
                            board[j,k].GetComponent<Renderer>().material.color = Color.white;
                        }
                    }
				}
            }
        }
    }
    // set the color of one of the board pieces
    // if the internalBoard value is greater than 0, that means at least one queen could move there and another queen cannot be placed
    void setColor(int i, int j){
        if (internalBoard[i,j] > 0){
            if((i + j) % 2 == 1 ){
                board[i,j].GetComponent<Renderer>().material.color = new Color(.67f,0,0);
            }
            else{
                board[i,j].GetComponent<Renderer>().material.color = Color.red;
            }           
        }
        else{
             if ((i+j) % 2 == 1){
                board[i,j].GetComponent<Renderer>().material.color = Color.gray;
            }
            else{
                board[i,j].GetComponent<Renderer>().material.color = Color.white;
            }                 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
