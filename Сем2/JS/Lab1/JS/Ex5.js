const buttonCheck = document.querySelector('.check');
const SIZE = 9;
buttonCheck.onclick = () => {
    try {
        let isSudoku = checkSudoku();
        if (isSudoku) {
            alert('Sudoku is correct');
        }
        else {
            alert('Sudoku is incorrect');
        }
    }
    catch (e) {
        let error = e;
        alert(error.message);
    }
};
const checkSudoku = () => {
    let numbers = fillArray();
    let isSudoku = true;
    for (let i = 0; i < SIZE; i++) {
        for (let j = 0; j < SIZE; j++) {
            if (!checkRow(numbers, i, j) || !checkColumn(numbers, i, j)) {
                isSudoku = false;
                break;
            }
        }
    }
    return isSudoku;
};
const fillArray = () => {
    let array = new Array(SIZE);
    const inputs = document.querySelectorAll('input');
    for (let i = 0; i < SIZE; i++) {
        array[i] = new Array(SIZE);
        for (let j = 0; j < SIZE; j++) {
            if (inputs[i * SIZE + j].value !== "") {
                if (parseInt(inputs[i * SIZE + j].value) > 9 || parseInt(inputs[i * SIZE + j].value) < 1) {
                    throw new Error('Number must be between 1 and 9');
                }
                array[i][j] = parseInt(inputs[i * SIZE + j].value);
            }
            else {
                array[i][j] = -1;
            }
            console.log(array[i][j]);
        }
    }
    return array;
};
const checkRow = (numbers, i, j) => {
    let isRow = true;
    let set = new Set();
    for (let k = j; k < SIZE; k++) {
        if (numbers[i][k] === -1)
            continue;
        if (set.has(numbers[i][k])) {
            isRow = false;
            break;
        }
        else {
            set.add(numbers[i][k]);
        }
    }
    return isRow;
};
const checkColumn = (numbers, i, j) => {
    let isColumn = true;
    let set = new Set();
    for (let k = i; k < SIZE; k++) {
        if (numbers[k][j] === -1)
            continue;
        if (set.has(numbers[k][j])) {
            isColumn = false;
            break;
        }
        else {
            set.add(numbers[k][j]);
        }
    }
    return isColumn;
};
document.body.addEventListener('keydown', (event) => {
    if (event.key === 'Enter') {
        buttonCheck.click();
    }
});
