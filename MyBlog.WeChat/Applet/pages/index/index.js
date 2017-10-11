//index.js
//获取应用实例
const app = getApp();
const articleListUrl = require('../../config').articleListUrl
Page({
  data: {
    articles:[]
  },
  onLoad: function () {
    this.setData({
      articles :[{
        Id:1,
        Title: 'foo',
        Content:"测试时说所所所所所所所所所所所所所所测试时说所所所所所所所所所所所所所所测试时说所所所所所所所所所所所所所所"
      }, {
          Id:2,
          Title: 'bar',
          Content: "测试时说所所所所所所所所所所所所所所测试时说所所所所所所所所所所所所所所"
      }]
    });
  }
})
