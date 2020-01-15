var isProd = false;
var url = isProd ? 'https://moneybag.site' : 'https://localhost:44369';
var settings = {};

console.log('# start');

$(function () {
    console.log('# onload');
    if (localStorage["botSettings"]) settings = JSON.parse(localStorage["botSettings"]);
    chrome.extension.onMessage.addListener(function (request, sender, sendResponse) {
        console.log(request);
        settings = request;
        localStorage["botSettings"] = JSON.stringify(request);
        return true;
    });

    setTimeout(mainWorker, 500);
});

async function mainWorker() {
    await main();
    setTimeout(mainWorker, 5500);
}

async function main() {
    if (!this.settings.isBotEnabled) {
        console.log('# main stopped');
        return;
    }

    if (this.settings.getPlayersInfo) {
        let nextPlayerId = await $.get(url + '/api/Observer/GetNextViewer');
        if (nextPlayerId) {
            const loc = 'https://ts4.travian.ru/spieler.php?uid=' + nextPlayerId;
            if (this.location.href !== loc) {
                this.location = loc;
                return;
            }
            else {
                var par = {};
                par.id = nextPlayerId;
                par.name = $($('.titleInHeader')[0]).text();
                par.rank = $($('#details td')[0]).text();
                par.nation = $($('#details td')[1]).text();
                par.clan = $($('#details td')[2]).text();
                par.countVillages = $($('#details td')[3]).text();

                let population = $($('#details td')[4]).text();
                par.rankPopulation = population.substr(0, population.indexOf(' '));
                population = population.substr(population.indexOf('(') + 1);
                par.countPopulation = population.substr(0, population.indexOf(' '));

                let att = $($('#details td')[5]).text();
                par.rankAtt = att.substr(0, att.indexOf(' '));
                att = att.substr(att.indexOf('(') + 1);
                par.pointAtt = att.substr(0, att.indexOf(' '));

                let def = $($('#details td')[6]).text();
                par.rankDef = def.substr(0, def.indexOf(' '));
                def = def.substr(def.indexOf('(') + 1);
                par.pointDef = def.substr(0, def.indexOf(' '));

                let villages = [];
                for (let i = 0; i < par.countVillages; i++) {
                    let village = {};
                    village.name = $($('#villages td')[i * 4])[0].innerText;
                    village.population = $($('#villages td')[i * 4 + 2]).text().trim();
                    village.coord = $($('#villages td')[i * 4 + 3]).text().trim();
                    villages.push(village);
                }

                par.villagesJson = JSON.stringify(villages);
                
                await $.ajax({
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    data: JSON.stringify(par),
                    url: url + '/api/Observer/SendInfo'
                });
            }
        }
    }

    console.log('# main runned');
}

//function sendChat() {
//    var chat = getMyChat();
//    if (chat.length) {
//        var model = { mess: transformChat(chat), token: 'koko' };
//        $.post(url + '/api/peresmeh/SendChat', model);
//    }
//}

//function getChat() {
//    $.post(url + '/api/peresmeh/ListForCombats', function (data) {
//        for (var i = 0; i < data.length; i++) {
//            setTimeout($.post('https://combats-2.com/ch.php?color=000000&sys=1&om=&lid=&type=&text=' + data[i]), i * 300);
//        }
//    });
//}

//function getMyChat() {
//    var newChat = $(top.frames['chat'].document.all('mes')).children('div:not(.isp)');
//    var result = [];
//    if (newChat.length > 0) {
//        for (var i = 0; i < newChat.length; i++) {
//            if (isFine(newChat[i])) result.push(newChat[i].innerHTML);
//        }
//    }

//    newChat.addClass('isp');
//    return result;
//}

//function isFine(el) {
//    if ($(el).hasClass('flame')) return false;
//    for (var i = 0; i < sucksArr.length; i++) {
//        if (el.innerHTML.indexOf(sucksArr[i]) > -1) return false;
//    }

//    return true;
//}

//function transformChat(arr) {
//    var res = [];
//    for (var i = 0; i < arr.length; i++) {
//        arr[i] = arr[i].replace(/class="private"/g, '');
//        arr[i] = arr[i].replace(/oncontextmenu="return OpenMenu\(event,10\)"/g, '');
//        arr[i] = arr[i].replace(/oncontextmenu="return OpenMenu\(event\)"/g, '');
//        arr[i] = arr[i].replace(/ href='javascript:mytop\.AddTo\(".+"\)'/g, ' class="chatTo"');
//        arr[i] = arr[i].replace(/<img(.*?)\/(.*?)\/(.*?)\.gif">/g, ':$2: ')
//        arr[i] = arr[i].replace(/onclick="\$\(this\)\.next\(\)\.find\(\&quot;a&quot;\)\.click\(\)"/g, '');
//        arr[i] = arr[i].replace(/onclick="mytop\.AddToPrivate(.*?)quot;\)"/g, ' class="chatPrivate"');
//        arr[i] = arr[i].replace('<a  >private [ </a>', 'private [');

//        res.push(arr[i]);
//    }

//    return res;
//}

//var sucksArr = [
//    'Приветствуем тебя в нашем БК-2! Окунись в атмосферу старого Бойцовского клуба!',
//    'img src="i/magic/spell_powerup10.gif"'
//];