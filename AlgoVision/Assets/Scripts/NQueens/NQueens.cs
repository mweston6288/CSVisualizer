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
    TextMeshPro[] labelText1;
    TextMeshPro[] labelText2;
    GameObject[,] board;
    [SerializeField] GameObject boxPrefab;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject text;

    protected TMP_Text showText;
    private Boolean isPlay;
    // Start is called before the first frame update
    public void setup(int n)
    {
        this.n = n;
        board = new GameObject[n,n];
        internalBoard = new int[n,n];
        labelText1 = new TextMeshPro[n];
        labelText2 = new TextMeshPro[n];
        solution = false;
        showText = canvas.transform.GetChild(5).GetComponent<TMP_Text>();
        isPlay = false;
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
        for(i = 0; i < n; i++){
            labelText1[i] = GameObject.Instantiate(text).GetComponent<TextMeshPro>();
            labelText2[i] = GameObject.Instantiate(text).GetComponent<TextMeshPro>();
            
            labelText1[i].text = ((char)('A'+i)).ToString();
            labelText2[i].text = (i+1).ToString();

            labelText1[i].transform.position = new Vector3(-1.28f, (n-i)*1.28f, 0);
            labelText2[i].transform.position = new Vector3(i * 1.28f, 0, 0);
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
                showText.text = "Placing a Queen on " + ((char)(column+'A')).ToString() + (i+1).ToString();

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
                    board[i,j].GetComponentInChildren<TextMeshPro>().text = internalBoard[i,j].ToString();
                    board[j,column].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,column].ToString();

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
                    board[j,k].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,k].ToString();
				}
				// bottom left diagonal
				for (j = i, k = column; j >= 0 && k < n; j--, k++) {
					internalBoard[j,k]++;
                    if((j + k) % 2 == 1 ){
                        board[j,k].GetComponent<Renderer>().material.color = new Color(.67f,0,0);

                    }
                    else{
                        board[j,k].GetComponent<Renderer>().material.color = Color.red;
                    }
                    board[j,k].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,k].ToString();
                }
                // top right diagonal
				for (j = i, k = column; j < n && k >= 0; j++, k--) {
					internalBoard[j,k]++;
                    if((j + k) % 2 == 1 ){
                        board[j,k].GetComponent<Renderer>().material.color = new Color(.67f,0,0);

                    }
                    else{
                        board[j,k].GetComponent<Renderer>().material.color = Color.red;
                    }
                    board[j,k].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,k].ToString();
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
                    board[j,k].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,k].ToString();
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
                        board[i,j].GetComponentInChildren<TextMeshPro>().text = "";
                    }
                    else{
                        board[i,j].GetComponentInChildren<TextMeshPro>().text = internalBoard[i,j].ToString();

                    }
                    internalBoard[j, column]--;
                    if (internalBoard[j,column] == 0){
                        if ((column + j) % 2 == 1){
                            board[j,column].GetComponent<Renderer>().material.color = Color.gray;
                        }
                        else{
                            board[j,column].GetComponent<Renderer>().material.color = Color.white;
                        }
                        board[j,column].GetComponentInChildren<TextMeshPro>().text = "";
                    }
                    else{
                        board[j,column].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,column].ToString();
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
                        board[j,k].GetComponentInChildren<TextMeshPro>().text = "";
                    }
                    else{
                        board[j,k].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,k].ToString();
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
                        board[j,k].GetComponentInChildren<TextMeshPro>().text = "";
                    }
                    else{
                        board[j,k].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,k].ToString();
                    }				}
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
                        board[j,k].GetComponentInChildren<TextMeshPro>().text = "";
                    }
                    else{
                        board[j,k].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,k].ToString();
                    }				}
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
                        board[j,k].GetComponentInChildren<TextMeshPro>().text = "";
                    }
                    else{
                        board[j,k].GetComponentInChildren<TextMeshPro>().text = internalBoard[j,k].ToString();
                    }				}
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
    public void pauseAndPlay()
    {
        if (isPlay)
        {
            Time.timeScale = 1;
            isPlay = false;
            canvas.transform.GetChild(2).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
        }
        else
        {
            Time.timeScale = 0;
            isPlay = true;
            canvas.transform.GetChild(2).GetComponent<Image>().color = new Color(0.573f, 1f, 0f, 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
