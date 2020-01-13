var elements = [{
    id: "isBotEnabled",
    enabled: localStorage["isBotEnabled"] === "true"
}, {
    id: "getPlayersInfo",
    enabled: localStorage["getPlayersInfo"] === "true"
}];
chromeSend();

for (let i = 0; i < elements.length; i++) {
    if (elements[i].enabled === true) document.getElementById(elements[i].id).setAttribute("class", "");
    document.querySelector("#" + elements[i].id).addEventListener('click', baseClick);
}

//if (localStorage["isBotEnabled"] === "true") {
//    //mySend(localStorage["textOtvet"]);
//    document.getElementById("isBotEnabled").setAttribute("class", "");
//}

//if (localStorage["textOtvet"]) document.querySelector("#textOtvet").value = localStorage["textOtvet"];

//var isBotEnabled = false;
//var getPlayersInfo = false;
//document.querySelector("#isBotEnabled").addEventListener('click', isBotEnabledClick);
//document.querySelector("#getPlayersInfo").addEventListener('click', getPlayersInfoClick);

function baseClick(e) {
    let el = elements.find(x => x.id === this.id);
    if (!el) {
        console.error("Нет обработчика " + this.id);
        return;
    }

    document.getElementById(el.id).setAttribute("class", el.enabled ? "gray" : "");
    el.enabled = !el.enabled;

    localStorage[el.id] = el.enabled;
    chromeSend();
}

function getPlayersInfoClick(e) {
    if (getPlayersInfo === true) {
        document.getElementById(this.id).setAttribute("class", "gray");
        getPlayersInfo = false;
    }
    else {
        document.getElementById(this.id).setAttribute("class", "");
        getPlayersInfo = true;
    }

    localStorage["getPlayersInfo"] = getPlayersInfo;
    chromeSend();
}

function chromeSend() {
    const params = {
        isBotEnabled: elements.find(x => x.id === "isBotEnabled").enabled,
        getPlayersInfo: elements.find(x => x.id === "getPlayersInfo").enabled
    };

    chrome.tabs.getSelected(null, function (tab) {
        console.log('#3');
        chrome.tabs.sendMessage(tab.id, params);
    });
}