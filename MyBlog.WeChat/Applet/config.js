var host = "wangdahu.top";
var protocol = "https";
//var host = "localhost:51484";
//var protocol="http";
var config = {

  // 下面的地址配合云端 Server 工作
  host,

  // 获取文章列表地址
  articleListUrl: `${protocol}://${host}/api/Article`,

  // 文章详情地址
  articleDetailesUrl: `${protocol}://${host}/api/Article/get`,
};

module.exports = config
