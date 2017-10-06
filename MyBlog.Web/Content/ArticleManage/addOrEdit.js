var article = {
    editor: null,/*编辑器*/
    validator: null,
    /*初始化*/
    init: function () {
        this.initEditor();
        this.validExtend();
        this.valid();
        $('input[name="iCheck"]').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green',
            increaseArea: '20%'
        });
        $("#title").blur(function () {
            article.validator.element("#title");
        });
        $("#classify").change(function () {
            article.validator.element("#classify");
        });
        $("#tags").change(function () {
            article.validator.element("#tags");
        });
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
            },
            onchange: function () {
                //$("#addOrEditArticl").valid();
                article.validator.element("#editormdContent");
            }
        });
    },
    /*验证扩展*/
    validExtend: function () {
        $.validator.addMethod("validEditormd", function (value, element) {
            if (!article.editor || !article.editor.getMarkdown()) {
                return false;
            }
            return true;
        });

        $.validator.addMethod("validSelect", function (value, element) {
            if (value == 0) {
                return false;
            }
            return true;
        });
    },
    /*验证*/
    valid: function () {
        article.validator = $("#addOrEditArticl").validate({
            rules: {
                title: "required",
                classify: {
                    required: true,
                    validSelect: true
                },
                tags: "required",
                editormdContent: "validEditormd"
            },
            messages: {
                title: "标题不能为空",
                classify: "请选择分类",
                tags: "请选择标签",
                editormdContent: "内容不能为空"
            },
            errorElement: 'div',
            errorPlacement: function (error, element) {
                if (element.prop("tagName") == "SELECT") {
                    error.insertBefore(element.parent());
                } else {
                    error.insertBefore(element);
                }
            },
            success: function (ele) {
                ele.removeClass('error')
            }
        });
    },
    /*保存数据*/
    save: function () {
        if (!$("#addOrEditArticl").valid()) {
            return;
        }
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
            Classify: { id: $("#classify").val() },
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
