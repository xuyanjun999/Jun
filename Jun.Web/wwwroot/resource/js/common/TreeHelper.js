function initTree(treeId, option) {
    var tree = mini.get(treeId);
    option = option || {};
    if (tree) {
        var o = {
            ajaxType: 'post',
            idField: 'Id',
            parentField:'ParentId',
            totalField: 'Total',
            dataField: 'Data',
            textField: 'Text',
            iconField: 'IconCls',
            checkedField:'Checked',
            checkRecursive: true,
            showTreeIcon: true,
            resultAsTree: false
        };
        option = Object.assign(o, option);
        tree.set(option);
        return tree;
    }
}