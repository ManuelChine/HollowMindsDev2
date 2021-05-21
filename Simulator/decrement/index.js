const got = require('got');
const axios = require('axios')

const time = 60000; // 1 min
const time2 = 300000; // 5 min

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



//creare lista di date in cui salvare le ultime ore in cui solo avvenuti dei decrementi
var lastDecrement = [];
const n = 21600000; //6 ore

const link = 'http://localhost:42079/api/';

async function decrement() {
    await sleep(time);
    const res = await got(link + 'ViewModel');
    var list = JSON.parse(res.body);
    //console.log(list[1]); for debug
    for (var i=0; i<list.length; i++){
        
        //creare lista di bool (sensori)
        const sensors = [list[i].measurement.sensor0, list[i].measurement.sensor1, list[i].measurement.sensor2, 
        list[i].measurement.sensor3, list[i].measurement.sensor4, list[i].measurement.sensor5, 
        list[i].measurement.sensor6, list[i].measurement.sensor7
        ];
        
        if(lastDecrement.length===i){
            lastDecrement.push(1);
        }

        const now = Date.now();
        //confronto ora per capire se ci sia un decremento:
        if(now-lastDecrement[i]> time2){//dopo metti n
            //in caso positivo spengo il sensore più in alto e cambio l'ora
            for (var y=1; y<sensors.length  && sensors[y-1]===1; y++){
                if(sensors[y]===0){
                    sensors[y-1] = 0;
                    break;
                }
                else if(y===sensors.length-1){
                    sensors[y] = 0;
                    break;
                }
            }
            lastDecrement[i] = now;
        }
        //caso negativo = invariato

        //composizione dell'oggetto: dati casuali compresi tra i limiti
        const result = {
            sensor0: sensors[0],
            sensor1: sensors[1],
            sensor2: sensors[2],
            sensor3: sensors[3],
            sensor4: sensors[4],
            sensor5: sensors[5],
            sensor6: sensors[6],
            sensor7: sensors[7],
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
            })

    };
}


//funzione finale in cui partiranno tutte le attese
(async function(){
    try{
        while(true){
            await decrement();
        }
    } catch(e) {
        console.log('errore\n', e);
    }
    
})();


// Funzione per dormire
function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}