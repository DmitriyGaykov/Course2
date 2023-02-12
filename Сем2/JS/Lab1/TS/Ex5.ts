const buttonCheck = document.querySelector('.check') as HTMLButtonElement;
const SIZE = 9;

buttonCheck.onclick = () => 
{
    try
    {
        let isSudoku = checkSudoku();
        
        if(isSudoku)
        {
            alert('Sudoku is correct');
        }
        else
        {
            alert('Sudoku is incorrect');
        }
    }
    catch(e : any)
    {
        let error = e as Error;
        alert(error.message);
    }
}

const checkSudoku = () : boolean => {
    let numbers = fillArray();
    let isSudoku = true;

    for(let i = 0; i < SIZE; i++)
    {
        for(let j = 0; j < SIZE; j++)
        {
            if(!checkRow(numbers, i, j) || !checkColumn(numbers, i, j) || !checkInASquare(numbers, i, j))
            {
                isSudoku = false;
                break;
            }
        }
    }

    return isSudoku;
}

const fillArray = () : number[][] => {
    let array : number[][] = new Array<number[]>(SIZE);
    const inputs = document.querySelectorAll('input') as NodeListOf<HTMLInputElement>;

    for (let i = 0; i < SIZE; i++) {
        array[i] = new Array<number>(SIZE);
        
        for (let j = 0; j < SIZE; j++) {
            if(inputs[i * SIZE + j].value !== "")
            {
                if(parseInt(inputs[i * SIZE + j].value) > 9 || parseInt(inputs[i * SIZE + j].value) < 1)
                {
                    throw new Error('Number must be between 1 and 9');
                }

                array[i][j] = parseInt(inputs[i * SIZE + j].value);
            }
            else
            {
                array[i][j] = -1;
            }

            console.log(array[i][j]);
        }
    }

    return array;
}

const checkInASquare = (numbers : number[][], i : number, j : number) : boolean => {
    let numberOfSquare : number = getNumberOfSquare(i, j);
    console.log(numberOfSquare)

    let set = new Set<number>();

    for(let k = 0; k < SIZE; k++)
    {
        for(let m = 0; m < SIZE; m++)
        {
            if(
                getNumberOfSquare(k, m) === numberOfSquare && 
                i !== k && 
                j !== m && 
                numbers[k][m] === numbers[i][j] &&
                numbers[k][m] !== -1)
            {
                return false;
            }
        }
    }

    return true;
}

const getNumberOfSquare = (i : number, j : number) : number => {
    let numberOfSquare : number;
    if(i < 3)
    {
        if(j < 3)
        {
            numberOfSquare = 0;
        }
        else if(j < 6)
        {
            numberOfSquare = 1;
        }
        else
        {
            numberOfSquare = 2;
        }
    } else if (i < 6)
    {
        if(j < 3)
        {
            numberOfSquare = 3;
        }
        else if(j < 6)
        {
            numberOfSquare = 4;
        }
        else
        {
            numberOfSquare = 5;
        }
    } else
    {
        if(j < 3)
        {
            numberOfSquare = 6;
        }
        else if(j < 6)
        {
            numberOfSquare = 7;
        }
        else
        {
            numberOfSquare = 8;
        }
    }
    return numberOfSquare;
}

const checkRow = (numbers : number[][], i : number, j : number) : boolean => {
    let isRow = true;

    let set = new Set<number>();

    for(let k = j; k < SIZE; k++)
    {
        if(numbers[i][k] === -1) continue;

        if(set.has(numbers[i][k]))
        {
            isRow = false;
            break;
        }
        else
        {
            set.add(numbers[i][k]);
        }
    }

    return isRow;
}

const checkColumn = (numbers : number[][], i : number, j : number) : boolean => {
    let isColumn = true;

    let set = new Set<number>();

    for(let k = i; k < SIZE; k++)
    {
        if(numbers[k][j] === -1) continue;

        if(set.has(numbers[k][j]))
        {
            isColumn = false;
            break;
        }
        else
        {
            set.add(numbers[k][j]);
        }
    }

    return isColumn;
}

document.body.addEventListener('keydown', (event) => {
    if(event.key === 'Enter')
    {
        buttonCheck.click();
    }
});