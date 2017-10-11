//index.js
//获取应用实例
const app = getApp();
const articleListUrl = require('../../config').articleListUrl
Page({
  data: {
    articles:[],
    pageIndex:1,
    name:''
  },
  onLoad: function () {
    this.setData({
      articles :[{
        Id:1,
        Title: 'foo',
        Content:"测试时说所所所所所所所所所所所所所所测试时说所所所所所所所所所所所所所所测试时说所所所所所所所所所所所所所所",
        PublishedDate:'2017-10-11 13:25:38'
      }, {
          Id:2,
          Title: 'bar',
          Content: "测试时说所所所所所所所所所所所所所所测试时说所所所所所所所所所所所所所所",
          PublishedDate: '2017-10-11 13:25:38'
      }]
    });
    this.loadData();
  },
  loadData:function(){
    var that=this;
    wx.request({
      url: articleListUrl, //仅为示例，并非真实的接口地址
      data: {
        pageIndex: that.data.pageIndex,
        name: ''
      },
      success: function (res) {
        that.setData({
          articles: res.data.Rows
        });
      }
    })
  }
})
