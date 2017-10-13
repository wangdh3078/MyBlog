$(function () {
    $("#btn_submit").click(function () {
        if (!$("#addOrEditRecord").valid()) {
            return;
        }
        $.ajax({
            url: "/Admin/WeightRecord/Add",
            type: "POST",
            data: {
                Weight: $("#weight").val()
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
    $("#addOrEditRecord").validate({
        rules: {
            weight: "required"
        },
        messages: {
            weight: "体重不能为空"
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