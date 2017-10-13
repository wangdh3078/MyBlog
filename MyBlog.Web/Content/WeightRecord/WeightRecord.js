var WeightRecord = {
    layerIndex: 0,
    init: function () {
        $("#add").click(this.addItem);
    },
    addItem: function () {
        WeightRecord.layerIndex = layer.open({
            type: 2,
            content: "/Admin/WeightRecord/Add",
            area: ["40%", "40%"]
        });
    },
    refresh: function () {
        layer.close(WeightRecord.layerIndex);
        WeightRecord.tab.bootstrapTable("refresh");
    }
};
$(function () {
    WeightRecord.init();
})