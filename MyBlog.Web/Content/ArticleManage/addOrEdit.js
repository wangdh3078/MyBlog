var article = {
    editor: null,/*编辑器*/
    /*初始化*/
    init: function () {
        $('input[name="iCheck"]').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green',
            increaseArea: '20%'
        });
        this.initEditor();
        this.validExtend();
        this.valid();
        $("#btn_submit").click(this.save);
    },
    /*初始化编辑器*/
    initEditor: function () {
        this.editor = editormd("editormd", {
            width: "100%",
            height: 450,
            path: '/Scripts/plugins/editor.md/lib/',
            emoji: true,
            taskList: true,
            tocm: true,                  // Using [TOCM]
            tex: true,                   // 开启科学公式TeX语言支持，默认关闭
            flowChart: true,             // 开启流程图支持，默认关闭
            sequenceDiagram: true,       // 开启时序/序列图支持，默认关闭,
            imageUpload: true,
            imageFormats: ["jpg", "jpeg", "gif", "png", "bmp", "webp"],
            imageUploadURL: "/Common/FileUpload",
            saveHTMLToTextarea: true,
            //上传的后台只需要返回一个 JSON 数据，结构如下：
            // {
            //    success: 0 | 1,           // 0 表示上传失败，1 表示上传成功
            //    message: "提示的信息，上传成功或上传失败及错误信息等。",
            //    url: "图片地址"        // 上传成功时才返回
            //}
            onresize: function () {
                //this.setMarkdown("state.loaded > bind onresize > window.onresize, editormd watch/unwatch/fullscreen/fullscreenExit/toolbar show|hide " + (new Date).getTime());
                //console.log("onresize =>", this, this.id, this.settings);
            }
        });
    },
    /*验证扩展*/
    validExtend: function () {
        $.validator.addMethod("validEditormd", function (value, element) {
            debugger;
            if (!article.editor || !article.editor.getMarkdown()) {
                return false;
            }
            return true;
        }, '内容不能为空！');

        $.validator.addMethod("validSelect", function (value, element) {
            if (value == 0) {
                return false;
            }
            return true;
        }, '这是必填字段！');
    },
    /*验证*/
    valid: function () {
        $("#addOrEditArticl").validate({
            rules: {
                title: "required",
                classify: {
                    required: true,
                    validSelect: true
                },
                tags: "required",
                editormdContent: "validEditormd"
            },
            errorElement: 'div',
            errorPlacement: function (error, element) {
                debugger;
                error.addClass("tooltip  top in").css({ top: "-30px", left: "90%", opacity: "0.7" });
                var div = '<div class="tooltip-arrow" ></div><div class="tooltip-inner">' + error.text() + '</div>';
                error.empty();
                $(div).appendTo(error);
                error.insertAfter(element);
            }
        });
    },
    /*保存数据*/
    save: function () {
        if (!$("#addOrEditArticl").valid()) {
            return;
        }
        return;
        //console.log(editor.getMarkdown());       // 获取 Markdown 源码
        //console.log(editor.getHTML());           // 获取 Textarea 保存的 HTML 源码
        //console.log(editor.getPreviewedHTML());  // 获取预览窗口里的 HTML，在开启 watch 且没有开启 saveHTMLToTextarea 时使用
        var tags = [];
        var selectedTags = $("#tags").val();
        for (var i = 0; i < selectedTags.length; i++) {
            tags.push({ Id: selectedTags[i] });
        }
        var token = $('input[name="__RequestVerificationToken"]').val();
        var model = {
            Id: $("#id").val(),
            Title: $("#title").val(),
            Classify: $("#classify").val() == 0 ? [] : [{ Id: $("#classify").val() }],
            Tags: tags,
            ShortContext: article.editor.getMarkdown(),
            Context: article.editor.getHTML(),
            IsPublished: $("input[name='iCheck']:checked").val() == 1 ? true : false,
            "__RequestVerificationToken": token
        };
        $.ajax({
            url: "/Admin/ArticleManage/AddOrEditArticle",
            type: "POST",
            data: model,
            success: function (data) {
                if (data.scuuess) {
                    layer.msg(data.message, { time: 2000 }, function () {

                    });
                } else {
                    layer.msg(data.message, { time: 2000 });
                }
            },
            error: function (data) {
                console.log(data);
            }
        });
    }
};

$(function () {
    article.init();
});
