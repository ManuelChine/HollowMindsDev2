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
/*
function decrement(time, link) {
    setTimeout(function() {
        const list = await got(link + 'api');
        for (var item of list ){
            const result = {
                nome: 'bepi',
                eta: 42
            };
            reply.view(link + 'api', {result})
        }
        console.log('timeout');
    }, time);
}*/

//generatore di numeri decimeli casuali compresi tra parametri
function getRandom(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    num = Math.random() * (max - min) + min; //Il max è escluso e il min è incluso
    return Math.floor(num*100)/100
  }