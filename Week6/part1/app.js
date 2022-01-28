const dog = require("./dog");
const careDogUtility = require("./CareDogUtility");

//console.log(dogObj);
console.log(`Kopek Adı: ${dog.name} \nKopek Boyu: ${dog.height} \nKopek Kilosu: ${dog.width}`);
careDogUtility.bathTheDog();
console.log(`Kopek ilgi saati: ${careDogUtility.dogCareTime}`);