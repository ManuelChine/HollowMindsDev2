const time1 = 60000; // 1 min
const time2 = 5000;
const time3 = 5000;

//generatore di numeri decimeli casuali compresi tra parametri
function getRandom(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    num = Math.random() * (max - min) + min; //Il max è escluso e il min è incluso
    return Math.floor(num*100)/100
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
const lastDecrement = [];
const n = 21600000; //6 ore

const link = 'https://localhost:44363/api/';

function decrement(time, link) {
    setTimeout(function() {
        const list = await got(link + 'ViewModel');
        for (var i=0; i<list.length; i++){
            
            //creare lista di bool (sensori)
            const sensors = [list[i].measurement.sensor0, list[i].measurement.sensor1, list[i].measurement.sensor2, 
                list[i].measurement.sensor3, list[i].measurement.sensor4, list[i].measurement.sensor5, 
                list[i].measurement.sensor6, list[i].measurement.sensor7
            ];
            
            const now = Date.now();
            //confronto ora per capire se ci sia un decremento:
            if(now-lastDecrement[i]> n){
                //in caso positivo spengo il sensore più in alto e cambio l'ora
                for (var y=1; y<sensors.length && sensors[y-1]; y++){
                    if(!sensors[y] && sensors[y-1]){
                        sensors[y-1] = false;
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
                pressure: getRandom(list[i].limit.preassure*0.95, list[i].limit.preassure*1.05),
                temperatureTop: getRandom(list[i].limit.temperature*0.95, list[i].limit.temperature*1.05),
                temperatureBottom: getRandom(list[i].limit.temperature*0.95, list[i].limit.temperature*1.05),
                umidityTop: getRandom(list[i].limit.umidity*0.95, list[i].limit.umidity*1.05),
                umidityBottom: getRandom(list[i].limit.umidity*0.95, list[i].limit.umidity*1.05),
                time: currentDateTime(),
                dropCheck: 0,//non implementato, il sensore reale non è in grado di gestirlo. Lascio il valore di dafault
                idSilo: list[i].measurement.idSilo
            };

            console.log(result);

            //reply.view(link + 'api', {result})//da rifare e testare (per test -> stampo a console)
            //uso API di inserimento measurement

            //se il contatore dei livelli è a 0 far partire l'incremento 
            if(!sensors[0]){
                //richiamre funzione incremento
                //settare un variabile per fare in modo che la funzione non venga fatta partire più volte, 
                //causa: la funzione è asincrono e ci mette 5 min ma il controllo è ripetuto ogni min
            }
        }
    }, time);
}


//funzione finale in cui partiranno tutte le attese
(async function(){
    try{
        decrement(time1, link);
    } catch(e) {
        console.log('errore');
    }
    
})();
//l'attesa DEVE essere ASINCRONA (da controllare)
