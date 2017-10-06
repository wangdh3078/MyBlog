$(function () {
    $("#btn_submit").click(function () {
        if (!$("#addOrEditTag").valid()) {
            return;
        }
        $.ajax({
            url: "/Admin/TagsManage/AddOrEdit",
            type: "POST",
            data: {
                Id: $("#id").val(),
                Name: $("#tagName").val()
            },
            success: function (data) {
                if (data.success) {
                    layer.msg(data.message, { time: 1000 }, function () {
                        window.parent.TagsManage.refresh();
                    });
                } else {
                    layer.msg(data.message);
                }
            },
            error: function (data) {

            }
        });
    });
    $("#addOrEditTag").validate({
        rules: {
            tagName: "required"
        },
        messages: {
            tagName: "名称不能为空"
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