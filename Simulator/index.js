const time1 = 5000;
const time2 = 5000;
const time3 = 5000;

//funzione che prevede l'attesa di un tempo t prima dello svolgimento del suo contenuto
function wait(time) {
    setTimeout(function() {
        console.log(getRandom(1, 2));
    }, time);
}

//funzione finale in cui partiranno tutte le attese
(async function(){
    try{
        await wait(time1);
        await wait(time1);
    } catch(e) {
        console.log('errore');
    }
    
})();
//l'attesa DEVE essere ASINCRONA (da controllare)


const link = 'https://localhost:44363/api/';

function decrement(time, link) {
    setTimeout(function() {
        const list = await got(link + 'api');
        for (var item of list ){

            //creare lista di bool (sensori)
            //confronto ora per capire se ci sia un decremento:
            //in caso positivo spengo il sensore più in alto e scambio l'ora
            //caso negativo = invariato

            //composizione dell'oggetto: dati casuali compresi tra i limiti
            const result = {
                sensor0: true,
                sensor1: true,
                sensor2: true,
                sensor3: true,
                sensor4: true,
                sensor5: true,
                sensor6: true,
                sensor7: true,
                pressure: 0,
                temperatureTop: 0,
                temperatureBottom: 0,
                umidityTop: 0,
                umidityBottom: 0,
                time: currentDateTime(),
                dropCheck: 0,//non implementato, il sensore reale non è in grado di gestirlo. Lascio il valore di dafault
                idSilo: item.measurement.idSilo
            };

            console.log(result);

            //reply.view(link + 'api', {result})//da rifare e testare (per test -> stampo a console)
            //uso API di inserimento measurement

        }
    }, time);
}

//generatore di numeri decimeli casuali compresi tra parametri
function getRandom(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    num = Math.random() * (max - min) + min; //Il max è escluso e il min è incluso
    return Math.floor(num*100)/100
  }

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