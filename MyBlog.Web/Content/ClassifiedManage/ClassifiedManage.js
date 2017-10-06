var ClassifiedManage = {
    tab: null,
    layerIndex: 0,
    init: function () {
        this.tableInit();
        $("#btn_search").click(this.searchData);
        $("#add").click(this.addItem);
        $("#edit").click(this.editItem);
        $("#delete").click(this.deleteItems);
    },
    tableInit: function () {
        ClassifiedManage.tab = $('#classifiedTable');
        ClassifiedManage.tab.bootstrapTable({
            url: '/Admin/ClassifiedManage/GetPagingData',         //请求后台的URL（*）
            queryParams: ClassifiedManage.searchParams,//传递参数（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            columns: [{
                checkbox: true
            }, {
                field: 'Name',
                title: '分类名称'
            }, {
                field: 'CreateDate',
                title: '添加时间',
                formatter: function (value, row, index) {
                    return moment(value).format('YYYY-MM-DD HH:mm:ss');
                }
            }
            ]
        });
    },
    searchParams: function (obj) {
        obj.name = $("#searchName").val();
        return obj;
    },
    searchData: function () {
        ClassifiedManage.tab.bootstrapTable('destroy');
        ClassifiedManage.tableInit();
    },
    addItem: function () {
        ClassifiedManage.layerIndex = layer.open({
            type:2,
            content: "/Admin/ClassifiedManage/AddOrEdit",
            area:["40%","40%"]
        });
    },
    editItem: function () {

    },
    deleteItems: function () {

    }
};
$(function () {
    ClassifiedManage.init();
})