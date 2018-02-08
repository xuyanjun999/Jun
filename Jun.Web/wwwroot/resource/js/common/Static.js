
var yesNos = [{ value: true, text: '是' }, { value: false, text: '否' }];

function onYesNosRenderer(e) {
    for (var i = 0, l = yesNos.length; i < l; i++) {
        var g = yesNos[i];
        if (e.value) {
            if (g.value.toString() == e.value.toString()) return g.text;
        }
    }
    return "未定义";
}