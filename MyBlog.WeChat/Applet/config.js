var dev=true;
var host = "wangdahu.top";
var protocol = "https";
if (dev){
  host = "localhost:51484";
  protocol = "http";
}
var config = {

  // 下面的地址配合云端 Server 工作
  host,

  // 获取文章列表地址
  articleUrl: `${protocol}://${host}/api/Article`,

  // 文章分类地址
  categoryUrl: `${protocol}://${host}/api/Category/get`,
};

module.exports = config
