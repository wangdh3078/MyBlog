$(function () {
    $("#btn_submit").click(function () {
        if (!$("#addOrEditClassify").valid()) {
            return;
        }
        $.ajax({
            url: "/Admin/ClassifiedManage/AddOrEdit",
            type: "POST",
            data: {
                Id: $("#id").val(),
                Name: $("#classfiyName").val()
            },
            success: function (data) {
                if (data.success) {
                    layer.msg(data.message, { time: 1000 }, function () {
                        window.parent.ClassifiedManage.refresh();
                    });
                } else {
                    layer.msg(data.message);
                }
            },
            error: function (data) {

            }
        });
    });
    $("#addOrEditClassify").validate({
        rules: {
            classfiyName: "required"
        },
        messages: {
            classfiyName: "名称不能为空"
        },
        errorElement: 'div',
        errorPlacement: function (error, element) {
            error.insertBefore(element);
        },
        success: function (ele) {
            ele.removeClass('error')
        }
    });
})