const text = "zeynep";
//Combining the Built-in Methods to Reverse the String
const reverseFunc = (text) => text.split("").reverse().join("");
console.log(reverseFunc(text));

//Using a for Loop to Reverse the String
function reverseFunc1(text){
    let reverseText = "";
    for(let i= text.length -1; i>=0 ; i--){
        reverseText += text[i];
    }
    console.log(reverseText);
}
reverseFunc1(text);

//Using Recursion to Reverse the String
function reverseFunc2 (text){
    return (text === '') ? '' : reverseFunc2(text.substr(1)) + text.charAt(0);
}
console.log(reverseFunc2(text));

// three functions are same in runnung complexty but recursion function faster than. 