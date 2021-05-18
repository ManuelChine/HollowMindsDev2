const got = require('got');
const axios = require('axios')

const time = 300000; // 5 min

//generatore di numeri decimeli casuali compresi tra parametri
function getRandom(min, max) {
    num = Math.random() * (max - min) + min; //Il max è escluso e il min è incluso
    return Math.floor(num*100)/100;
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
            await increment();
        }
    } catch(e) {
        console.log('errore\n', e);
    }
    
})();

async function increment() {

    const res = await got(link + 'ViewModel');
    var list = JSON.parse(res.body);
    //console.log(list[1]); for debug
    for (var i=0; i<list.length; i++){
        if(list[i].measurement.sensor0===0){

            await sleep(time);
            //composizione dell'oggetto: dati casuali NON compresi tra i limiti
            const result = {
                sensor0: 1,
                sensor1: 1,
                sensor2: 1,
                sensor3: 1,
                sensor4: 1,
                sensor5: 1,
                sensor6: 1,
                sensor7: 1,
                pressure: getRandom(list[i].limit.pressure*0.95, list[i].limit.pressure*1.05),
                temperatureTop: getRandom(list[i].limit.temperature*0.95, list[i].limit.temperature*1.05),
                temperatureBottom: getRandom(list[i].limit.temperature*0.95, list[i].limit.temperature*1.05),
                umidityTop: getRandom(list[i].limit.umidity*0.95, list[i].limit.umidity*1.05),
                umidityBottom: getRandom(list[i].limit.umidity*0.95, list[i].limit.umidity*1.05),
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
                });

        }
    }
}

// Funzione per dormire
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}