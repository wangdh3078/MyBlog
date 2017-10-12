//index.js
//获取应用实例
const app = getApp();
const articleListUrl = require('../../config').articleListUrl;
Page({
  data: {
    articles: [],
    pageIndex: 1,
    name: ''
  },
  onLoad: function () {
    app.showLoading();
    this.loadData();
  },
  loadData: function () {
    var that = this;
    wx.request({
      url: articleListUrl,
      data: {
        pageIndex: that.data.pageIndex,
        name: ''
      },
      success: function (res) {
        console.log(res.data);
        that.setData({
          articles: res.data.Rows
        });
        app.cancelLoading();
      },
      fail: function (data) {
        console.log('请求失败：');
        console.log(data)
      },
      complete:function(data){
        console.log('请求完成：');
        console.log(data)
      }
    });
  },
  jump: function (event) {
    wx.navigateTo({
      url: '/pages/articleDetails/index?id=' + event.currentTarget.dataset.id
    });
  }
})
