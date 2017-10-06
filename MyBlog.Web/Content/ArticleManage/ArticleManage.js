var ArticleManage = {
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
        ArticleManage.tab = $('#articleTable');
        ArticleManage.tab.bootstrapTable({
            url: '/Admin/ArticleManage/GetPagingData',         //请求后台的URL（*）
            queryParams: ArticleManage.searchParams,//传递参数（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: 10,                       //每页的记录行数（*）
            columns: [{
                checkbox: true
            }, {
                field: 'Title',
                title: '标题'
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
        ArticleManage.tab.bootstrapTable('destroy');
        ArticleManage.tableInit();
    },
    addItem: function () {
        ArticleManage.layerIndex = layer.open({
            type: 2,
            content: "/Admin/ArticleManage/AddOrEditArticle",
            area: ["100%", "100%"]
        });
    },
    editItem: function () {
        var rows = ArticleManage.tab.bootstrapTable('getSelections');
        if (rows.length != 1) {
            layer.msg("请选择一行数据进行编辑");
            return;
        }
        var id = rows[0].Id;
        ArticleManage.layerIndex = layer.open({
            type: 2,
            content: "/Admin/ArticleManage/AddOrEditArticle?id=" + id,
            area: ["100%", "100%"]
        });
    },
    deleteItems: function () {
        var rows = ArticleManage.tab.bootstrapTable('getSelections');
        if (rows.length == 0) {
            layer.msg("请选择要删除的数据");
            return;
        }
        ArticleManage.layerIndex = layer.confirm("确认删除？",
            {
                btn: ['确定', '取消'],
                icon: 2

            },
            function () {
             
                var ids = [];
                for (var i = 0; i < rows.length; i++) {
                    ids.push(rows[i].Id);
                }
                $.ajax({
                    url: "/Admin/ArticleManage/Delete",
                    type: "POST",
                    data: { ids: ids },
                    success: function (data) {
                        if (data.success) {
                            layer.msg("删除成功", { time: 2000 }, function () {
                                ArticleManage.tab.bootstrapTable("refresh");
                            });
                        } else {
                            layer.msg("删除失败", { time: 2000 }, function () {
                            });
                        }
                    }, error: function (data) {

                    }
                });
            },
            function () {
                layer.close(ArticleManage.layerIndex);
            }
        );

    },
    refresh: function () {
        layer.close(ArticleManage.layerIndex);
        ArticleManage.tab.bootstrapTable("refresh");
    }
};
$(function () {
    ArticleManage.init();
})