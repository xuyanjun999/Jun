function initTreeGrid(gridId, option) {
    var grid = mini.get(gridId);
    option = option || {};
    if (grid) {
        var o = {
            pageSize: 50,
            ajaxType: 'post',
            idField: 'Id',
            sortField: 'Id',
            sortOrder: 'desc',
            pageIndexField: 'pageIndex',
            pageSizeField: 'pageSize',
            totalField: 'Total',
            dataField: 'Data',
            cellEditAction: 'celldblclick',
            multiSelect: true,
            allowAlternating: true,
            iconField: 'IconCls',
            showEmptyText: true,
            emptyText: '当前查询条件无数据',
            showColumnsMenu: true,
            showSortIcon: true,
            showTreeIcon: true,
            resultAsTree: false
        };
        option = Object.assign(o, option);
        grid.set(option);
        return grid;
    }
}