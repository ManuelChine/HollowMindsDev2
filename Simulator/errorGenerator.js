const got = require('got');
const axios = require('axios')

const time = 900000; // 15 min

//generatore di numeri decimeli casuali compresi tra parametri
function getRandom(min, max) {
    num = Math.random() * (max - min) + min; //Il max è escluso e il min è incluso
    return Math.floor(num*100)/100;
  }

  function getRandomBool() {
    return Math.floor(Math.random() * 2);
  }

  //trovare la data corrente in formato letto da C#
  function currentDateTime(){
    let date_ob = new Date();
    // current date
    // adjust 0 before single digit date
    let day = ("0" + date_ob.getDate()).slice(-2);
    // current month
    let month = ("0" + (date_ob.getMonth() + 1)).slice(-2);
    // current year
    let year = date_ob.getFullYear();
    // current hours
    let hours = date_ob.getHours();
    // current minutes
    let minutes = date_ob.getMinutes();
    // current seconds
    let seconds = date_ob.getSeconds();
    return year+'-'+month+'-'+day+'T'+hours+":"+minutes+":"+seconds+"Z";
  }

const link = 'http://localhost:42079/api/';

//funzione finale in cui partiranno tutte le attese
(async function(){
    try{
        while(true){
            await errorGenerator(time);
        }
    } catch(e) {
        console.log('errore\n', e);
    }
    
})();

async function errorGenerator(time) {
    await sleep(time);
    const res = await got(link + 'ViewModel');
    var list = JSON.parse(res.body);
    //console.log(list[1]); for debug
    for (var i=0; i<list.length; i++){
    
        //composizione dell'oggetto: dati casuali NON compresi tra i limiti
        const result = {
            sensor0: getRandomBool(),
            sensor1: getRandomBool(),
            sensor2: getRandomBool(),
            sensor3: getRandomBool(),
            sensor4: getRandomBool(),
            sensor5: getRandomBool(),
            sensor6: getRandomBool(),
            sensor7: getRandomBool(),
            pressure: getRandom(list[i].limit.pressure*0.85, list[i].limit.pressure*1.15),
            temperatureTop: getRandom(list[i].limit.temperature*0.85, list[i].limit.temperature*1.15),
            temperatureBottom: getRandom(list[i].limit.temperature*0.85, list[i].limit.temperature*1.15),
            umidityTop: getRandom(list[i].limit.umidity*0.85, list[i].limit.umidity*1.15),
            umidityBottom: getRandom(list[i].limit.umidity*0.85, list[i].limit.umidity*1.15),
            time: currentDateTime(),
            dropCheck: 0,//non implementato, il sensore reale non è in grado di gestirlo. Lascio il valore di dafault
            idSilo: list[i].measurement.idSilo
        };

        // console.log(result); only for debug

        //uso API di inserimento measurement
        axios
            .post(link + 'Measurement', result)
            .then((res) => {
                console.log(`statusCode: ${res.statusCode}`)
                console.log(res)
            })
            .catch((error) => {
                console.error(error)
            })
    };
}

// Funzione per dormire
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}