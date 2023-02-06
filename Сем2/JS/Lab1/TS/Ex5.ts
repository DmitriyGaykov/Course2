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
            if(!checkRow(numbers, i, j) || !checkColumn(numbers, i, j))
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