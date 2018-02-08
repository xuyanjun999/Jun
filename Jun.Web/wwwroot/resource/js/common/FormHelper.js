

function initForm(formId, option) {
    if (formId[0] !== "#")
        formId = "#" + formId;
    var form = new mini.Form(formId);
    option = option || {};
    if (form) {
        var o = {
        };
        option = Object.assign(o, option);
        form.set(option);
        return form;
    }
}