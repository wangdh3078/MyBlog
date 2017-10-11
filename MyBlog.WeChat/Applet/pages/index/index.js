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
    this.loadData();
  },
  loadData:function(){
    var that=this;
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
      }
    })
  },
  jump: function (event){
    console.log(event.currentTarget.dataset.id);
    wx.navigateTo({
      url: '/pages/articleDetails/index?id=' + event.currentTarget.dataset.id
    })
  }
})
