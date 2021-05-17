const got = require('got');
const axios = require('axios')

const time1 = 60000; // 1 min
const time2 = 300000; // 5 min
const time3 = 900000; // 15 min

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



//creare lista di date in cui salvare le ultime ore in cui solo avvenuti dei decrementi
var lastDecrement = [];
const n = 21600000; //6 ore
var checkIncr =  [];

const link = 'http://localhost:42079/api/';

async function decrement(time) {
    setTimeout(async function() {
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
                checkIncr.push(true);
            }

            const now = Date.now();
            //confronto ora per capire se ci sia un decremento:
            if(now-lastDecrement[i]> n){
                //in caso positivo spengo il sensore più in alto e cambio l'ora
                for (var y=1; y<sensors.length  && sensors[y-1]===1; y++){
                    if(sensors[y]===0){
                        sensors[y-1] = 0;
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
                .post(link + 'Measurement', JSON.parse(JSON.stringify(result)))
                .then((res) => {
                    console.log(`statusCode: ${res.statusCode}`)
                    console.log(res)
                })
                .catch((error) => {
                    console.error(error)
                })

            //se il contatore dei livelli è a 0 far partire l'incremento
            if(sensors[0]===0 && checkIncr[i]){
                //settare un variabile per fare in modo che la funzione non venga fatta partire più volte, 
                //causa: la funzione è asincrono e ci mette 5 min ma il controllo è ripetuto ogni min
                checkIncr[i] = false;
                //richiamre funzione incremento
                increment(time2, list[i], i);
            }
        };
    }, time);
}


//funzione finale in cui partiranno tutte le attese
(async function(){
    try{
        //while(true){
            decrement(time1);
            errorGenerator(time3);
        //}
    } catch(e) {
        console.log('errore');
    }
    
})();
//l'attesa DEVE essere ASINCRONA (da controllare)

async function errorGenerator(time) {
    setTimeout(async function() {
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
                .post(link + 'Measurement', JSON.parse(JSON.stringify(result)))
                .then((res) => {
                    console.log(`statusCode: ${res.statusCode}`)
                    console.log(res)
                })
                .catch((error) => {
                    console.error(error)
                })
        };
    }, time);
}

async function increment(time, model, i) {
    setTimeout(async function() {
        
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
            pressure: getRandom(model.limit.pressure*0.95, model.limit.pressure*1.05),
            temperatureTop: getRandom(model.limit.temperature*0.95, model.limit.temperature*1.05),
            temperatureBottom: getRandom(model.limit.temperature*0.95, model.limit.temperature*1.05),
            umidityTop: getRandom(model.limit.umidity*0.95, model.limit.umidity*1.05),
            umidityBottom: getRandom(model.limit.umidity*0.95, model.limit.umidity*1.05),
            time: currentDateTime(),
            dropCheck: 0,//non implementato, il sensore reale non è in grado di gestirlo. Lascio il valore di dafault
            idSilo: model.measurement.idSilo
        };

        // console.log(result); only for debug

        //uso API di inserimento measurement
        axios
            .post(link + 'Measurement', JSON.parse(JSON.stringify(result)))
            .then((res) => {
                console.log(`statusCode: ${res.statusCode}`)
                console.log(res)
            })
            .catch((error) => {
                console.error(error)
            });

        checkIncr[i] = true;
    }, time);
}