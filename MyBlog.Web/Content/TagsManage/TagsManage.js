var TagsManage = {
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
        TagsManage.tab = $('#tagsTable');
        TagsManage.tab.bootstrapTable({
            url: '/Admin/TagsManage/GetPagingData',         //请求后台的URL（*）
            queryParams: TagsManage.searchParams,//传递参数（*）
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
        TagsManage.tab.bootstrapTable('destroy');
        TagsManage.tableInit();
    },
    addItem: function () {
        TagsManage.layerIndex = layer.open({
            type: 2,
            content: "/Admin/TagsManage/AddOrEdit",
            area: ["40%", "40%"]
        });
    },
    editItem: function () {
        var rows = TagsManage.tab.bootstrapTable('getSelections');
        if (rows.length != 1) {
            layer.msg("请选择一行数据进行编辑");
            return;
        }
        var id = rows[0].Id;
        TagsManage.layerIndex = layer.open({
            type: 2,
            content: "/Admin/TagsManage/AddOrEdit?id=" + id,
            area: ["40%", "40%"]
        });
    },
    deleteItems: function () {
        var rows = TagsManage.tab.bootstrapTable('getSelections');
        if (rows.length == 0) {
            layer.msg("请选择要删除的数据");
            return;
        }
        TagsManage.layerIndex = layer.confirm("确认删除？",
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
                    url: "/Admin/TagsManage/Delete",
                    type: "POST",
                    data: { ids: ids },
                    success: function (data) {
                        if (data.success) {
                            layer.msg("删除成功", { time: 2000 }, function () {
                                TagsManage.tab.bootstrapTable("refresh");
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
                layer.close(TagsManage.layerIndex);
            }
        );

    },
    refresh: function () {
        layer.close(TagsManage.layerIndex);
        TagsManage.tab.bootstrapTable("refresh");
    }
};
$(function () {
    TagsManage.init();
})