const girlsPowerToplam─▒ = (number) =>{
    number = (number / 2)+3;
    //console.log(number);
    return number;
}

function girlsPower (arr) {
    let results = [];
    results = arr.map(num => girlsPowerToplam─▒(num));
    console.log(results);
}

const arr = [2,3,4];
girlsPower(arr);