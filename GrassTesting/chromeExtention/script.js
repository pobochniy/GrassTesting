var isProd = false;
var url = isProd ? 'https://moneybag.site' : 'https://localhost:44359';
var isBotEnabled = false;
var getPlayersInfo = false;
var playersView = [{ pid: 3956, viewed: false }, { pid: 3215, viewed: false }];

console.log('# start');

$(function () {
    console.log('# onload');

    chrome.extension.onMessage.addListener(function (request, sender, sendResponse) {
        console.log(request);
        debugger
        isBotEnabled = request.isBotEnabled;
        getPlayersInfo = request.getPlayersInfo;
        return true;
    });

    setTimeout(main, 500);
});

function main() {
    if (!this.isBotEnabled) {
        console.log('# main stopped');
        setTimeout(main, 5500);
        return;
    }

    if (this.getPlayersInfo) {
        let nextPlayer = this.playersView.find(x => x.viewed === false);
        if (nextPlayer) {
            this.location = 'https://ts4.travian.ru/spieler.php?uid=' + nextPlayer.pid;
            debugger;
            setTimeout(main, 5500);
            return;
        }
    }

    console.log('# main runned');
    setTimeout(main, 5500);
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